#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public partial class SP_SpritePacker
{
	public List<SP_Source> Sources
	{
		get
		{
			return sources;
		}
	}
	
	public SP_Source AddSource(string identifier)
	{
		if (string.IsNullOrEmpty(identifier) == false)
		{
			foreach (var source in sources)
			{
				if (source != null && source.Identifier == identifier)
				{
					return null;
				}
			}
			
			var newSource = new SP_Source(); sources.Add(newSource);
			
			newSource.Identifier = identifier;
			
			return newSource;
		}
		
		return null;
	}
	
	public void Rebuild()
	{
		var rects = CompileSources();
		
		if (rects.Count > 0)
		{
			var area   = CalculateTotalArea(rects);
			var side   = Mathf.NextPowerOfTwo(Mathf.FloorToInt(Mathf.Sqrt(area))) / 2;
			var width  = Mathf.Max(side, 4);
			var height = Mathf.Max(side, 4);
			
			if (AutoPack(width, height, rects) == false)
			{
				Debug.LogError("Failed to pack textures! Try increasing the max width & height."); return;
			}
		}
		else
		{
			Clear();
		}
	}
	
	public void Clear()
	{
		AssetDatabase.DeleteAsset(AssetDatabase.GUIDToAssetPath(identifier));
	}
	
	private bool AutoPack(int width, int height, List<SP_Rect> rects)
	{
		while (width <= (int)maxSize && height <= (int)maxSize)
		{
			var bin = CreateBin(width, height);
			
			if (bin.Pack(rects) == true)
			{
				CompileBin(bin, rects);
				
				return true;
			}
			
			if (forceSquare == true)
			{
				width  *= 2;
				height *= 2;
			}
			else
			{
				if (width == height)
				{
					width *= 2;
				}
				else
				{
					height *= 2;
				}
			}
		}
		
		return false;
	}
	
	private int CalculateTotalArea(List<SP_Rect> rects)
	{
		var total = 0;
		
		foreach (var rect in rects)
		{
			total += rect.Width * rect.Height;
		}
		
		return total;
	}
	
	private SP_Bin CreateBin(int width, int height)
	{
		var bin = default(SP_Bin);
		
		switch (algorithm)
		{
			case SP_Algorithm.Guillotine: bin = new SP_Guillotine(width, height); break;
			case SP_Algorithm.MaxRects:   bin = new SP_MaxRects(width, height);   break;
		}
		
		return bin;
	}
	
	private void RemoveInvalidSources()
	{
		var newSources = new List<SP_Source>();
		
		foreach (var source in sources)
		{
			if (source != null)
			{
				if (string.IsNullOrEmpty(source.Identifier) == false)
				{
					if (newSources.Find(s => s.Identifier == source.Identifier) == null)
					{
						newSources.Add(source);
					}
				}
			}
		}
		
		sources = newSources;
	}
	
	private SpriteMetaData GetMetaData(TextureImporter importer, int index)
	{
		if (importer != null)
		{
			var metaDatas = importer.spritesheet;
			
			if (index < metaDatas.Length)
			{
				return metaDatas[index];
			}
		}
		
		var newMetaData = new SpriteMetaData();
		
		newMetaData.alignment = (int)SpriteAlignment.Center;
		newMetaData.pivot     = new Vector2(0.5f, 0.5f);
		
		return newMetaData;
	}
	
	private List<SpriteMetaData> CompileResults()
	{
		var metaDatas = new List<SpriteMetaData>(results.Count);
		var importer  = SP_Helper.GetAssetImporter<TextureImporter>(AssetDatabase.GUIDToAssetPath(identifier));
		
		for (var i = 0 ; i < results.Count; i++)
		{
			var metaData = GetMetaData(importer, i);
			
			metaData.name = "Missing";
			metaData.rect = new Rect();
			
			metaDatas.Add(metaData);
		}
		
		return metaDatas;
	}
	
	private int FindOrAddResult(List<SpriteMetaData> metaDatas, string identifier, int index)
	{
		var resultIndex = results.FindIndex(r => r != null && r.Identifier == identifier && r.Index == index);
		
		if (resultIndex == -1)
		{
			resultIndex = results.Count;
			
			var metaData = new SpriteMetaData();
			var result   = new SP_Result();
			
			metaData.pivot     = new Vector2(0.5f, 0.5f);
			metaData.alignment = (int)SpriteAlignment.Center;
			
			result.Identifier = identifier;
			result.Index      = index;
			
			metaDatas.Add(metaData);
			results.Add(result);
		}
		
		return resultIndex;
	}
	
	private List<SP_Rect> CompileSources()
	{
		RemoveInvalidSources();
		
		var rects = new List<SP_Rect>();
		
		foreach (var source in sources)
		{
			if (source != null)
			{
				rects.AddRange(source.Compile());
			}
		}
		
		return rects;
	}
	
	private string GetPath()
	{
		var path = AssetDatabase.GUIDToAssetPath(identifier);
		
		//if (AssetDatabase.LoadAssetAtPath(path, typeof(Texture2D)) == null)
		if (string.IsNullOrEmpty(path) == true)
		{
			var directory = SP_Helper.GetPathDirectory(AssetDatabase.GetAssetPath(this));
			
			path = AssetDatabase.GenerateUniqueAssetPath(directory + "/" + name + ".png");
		}
		
		return path;
	}
	
	private void CompileBin(SP_Bin bin, List<SP_Rect> rects)
	{
		var pixels    = new SP_Pixels(bin.Width, bin.Height);
		var metaDatas = CompileResults();
		
		foreach (var rect in rects)
		{
			var x        = rect.X + rect.BorderX;
			var y        = rect.Y + rect.BorderY;
			var index    = FindOrAddResult(metaDatas, rect.Identifier, rect.Index);
			var metaData = metaDatas[index];
			
			metaData.name = rect.Name; if (suffixAtlasName == true) metaData.name += " (" + name + ")";
			metaData.rect = new Rect(x, y, rect.Pixels.Width, rect.Pixels.Height);
			
			if (rect.KeepPivot == true)
			{
				metaData.alignment = (int)SpriteAlignment.Custom;
				metaData.pivot     = rect.Pivot;
			}
			else
			{
				metaData.alignment = (int)SpriteAlignment.Center;
				metaData.pivot     = new Vector2(0.5f, 0.5f);
			}
			
			metaDatas[index] = metaData;
			
			pixels.SetPixels(rect.X, rect.Y, rect.ExpandedPixels);
		}
		
		var texture  = pixels.Apply();
		var importer = SP_Helper.SaveTextureAsset(texture, GetPath(), true);
		
		importer.maxTextureSize   = 4096;
		importer.textureType      = TextureImporterType.Sprite;
		importer.spriteImportMode = SpriteImportMode.Multiple;
		importer.spritesheet      = metaDatas.ToArray();
		
		identifier = AssetDatabase.AssetPathToGUID(importer.assetPath);
		
		SP_Helper.ReimportAsset(importer.assetPath);
		SP_Helper.SafeDestroy(texture);
	}
	
	[ContextMenu("Remove Missing Sprites")]
	private void RemoveMissing()
	{
		if (EditorUtility.DisplayDialog("Are you sure?", "Doing this may break the other sprites in this atlas.", "Yes", "Cancel") == true)
		{
			RemoveInvalidSources();
			
			results.RemoveAll(r => sources.Find(s => s.Identifier == r.Identifier) == null);
			
			Rebuild();
		}
	}
}
#endif