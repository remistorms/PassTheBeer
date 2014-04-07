#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public partial class SP_Source
{
	public List<SP_Rect> Compile()
	{
		var rects     = new List<SP_Rect>();
		var path      = AssetDatabase.GUIDToAssetPath(identifier);
		var texture2D = (Texture2D)AssetDatabase.LoadAssetAtPath(path, typeof(Texture2D));
		
		if (texture2D != null)
		{
			var importer = FixSettings(texture2D, path);
			
			if (importer != null)
			{
				var pixels = new SP_Pixels(texture2D);
				
				if (importer.textureType == TextureImporterType.Sprite && importer.spriteImportMode == SpriteImportMode.Multiple)
				{
					var metaDatas = importer.spritesheet;
					
					for (var i = 0; i < metaDatas.Length; i++)
					{
						var metaData  = metaDatas[i];
						var subPixels = pixels.GetSubset((int)metaData.rect.x, (int)metaData.rect.y, (int)metaData.rect.width, (int)metaData.rect.height);
						var newRect   = new SP_Rect(); rects.Add(newRect);
						
						newRect.Identifier = identifier;
						newRect.Index      = i;
						newRect.Name       = metaData.name;
						newRect.BorderType = borderType;
						newRect.Pixels     = subPixels;
						newRect.KeepPivot  = keepPivot;
						
						TrimRect(newRect, GetPivot(metaData));
					}
				}
				else
				{
					var newRect = new SP_Rect(); rects.Add(newRect);
					
					newRect.Identifier = identifier;
					newRect.Index      = -1;
					newRect.Name       = texture2D.name;
					newRect.BorderType = borderType;
					newRect.Pixels     = pixels;
					newRect.KeepPivot  = keepPivot;
					
					if (importer.textureType == TextureImporterType.Sprite)
					{
						TrimRect(newRect, importer.spritePivot);
					}
					else
					{
						TrimRect(newRect, new Vector2(0.5f, 0.5f));
					}
				}
			}
		}
		
		return rects;
	}
	
	private Vector2 GetPivot(SpriteMetaData metaData)
	{
		switch (metaData.alignment)
		{
			case (int)SpriteAlignment.Center:       return new Vector2(0.5f, 0.5f);
			case (int)SpriteAlignment.TopLeft:      return new Vector2(0.0f, 1.0f);
			case (int)SpriteAlignment.TopCenter:    return new Vector2(0.5f, 1.0f);
			case (int)SpriteAlignment.TopRight:     return new Vector2(1.0f, 1.0f);
			case (int)SpriteAlignment.LeftCenter:   return new Vector2(0.0f, 0.5f);
			case (int)SpriteAlignment.RightCenter:  return new Vector2(0.5f, 0.5f);
			case (int)SpriteAlignment.BottomLeft:   return new Vector2(0.0f, 0.0f);
			case (int)SpriteAlignment.BottomCenter: return new Vector2(0.5f, 0.0f);
			case (int)SpriteAlignment.BottomRight:  return new Vector2(1.0f, 0.0f);
			case (int)SpriteAlignment.Custom:       return metaData.pivot;
		}
		
		return default(Vector2);
	}
	
	private void TrimRect(SP_Rect rect, Vector2 pivot)
	{
		if (trim == true)
		{
			var sourceRect  = new Rect(0.0f, 0.0f, rect.Pixels.Width, rect.Pixels.Height);
			var trimmedRect = default(Rect);
			var pivotX      = pivot.x * sourceRect.width;
			var pivotY      = pivot.y * sourceRect.height;
			
			rect.Pixels = rect.Pixels.GetTrimmed(ref trimmedRect);
			
			pivotX = SP_Helper.Divide(pivotX - trimmedRect.xMin, trimmedRect.width );
			pivotY = SP_Helper.Divide(pivotY - trimmedRect.yMin, trimmedRect.height);
			
			rect.Pivot = new Vector2(pivotX, pivotY);
		}
		else
		{
			rect.Pivot = pivot;
		}
		
		rect.Width  = Mathf.FloorToInt(rect.Pixels.Width)  + borderSize * 2;
		rect.Height = Mathf.FloorToInt(rect.Pixels.Height) + borderSize * 2;
	}
	
	private TextureImporter FixSettings(Texture2D texture2D, string path)
	{
		var importer = SP_Helper.GetAssetImporter<TextureImporter>(path);
		
		if (importer != null)
		{
			if (importer.isReadable != true || importer.textureFormat != TextureImporterFormat.AutomaticTruecolor)
			{
				importer.isReadable    = true;
				importer.textureFormat = TextureImporterFormat.AutomaticTruecolor;
				
				SP_Helper.ReimportAsset(importer.assetPath);
			}
		}
		
		return importer;
	}
}
#endif