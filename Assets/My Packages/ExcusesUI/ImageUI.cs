using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Excuses.UI
{
    public class ImageUI
    {
        public GameObject imageOBJ;
        public RectTransform imageTransform;
        public Image image;
        public ImageUI(string objectName, GameObject parent, bool tiled)
        {
            imageOBJ = new GameObject(objectName, typeof(RectTransform));
            imageOBJ.AddComponent<ImageData>();
            imageTransform = imageOBJ.GetComponent<RectTransform>();
            imageOBJ.transform.SetParent(parent.transform);
            imageOBJ.AddComponent<Image>();
            image = imageOBJ.GetComponent<Image>();
            if (tiled)
            {
                image.type = Image.Type.Tiled;
            }

            imageOBJ.GetComponent<ImageData>().imageOBJ = imageOBJ;
            imageOBJ.GetComponent<ImageData>().imageTransform = imageTransform;
            imageOBJ.GetComponent<ImageData>().image = image;
        }
        public ImageUI setSprites(SpriteData spriteData){
            image.sprite = spriteData.sprite;
            image.color = spriteData.color;
        }

        public ImageUI setAnchor(AnchorTypes anchor)
        {
            if(anchor == AnchorTypes.Center){
                imageTransform.anchorMin = new Vector2(0.5f, 0.5f);
                imageTransform.anchorMax = new Vector2(0.5f, 0.5f);
            }
            else if(anchor == AnchorTypes.TopMiddle){
                imageTransform.anchorMin = new Vector2(0.5f, 1f);
                imageTransform.anchorMax = new Vector2(0.5f, 1f);
            }
            else if(anchor == AnchorTypes.TopLeft){
                imageTransform.anchorMin = new Vector2(0f, 1f);
                imageTransform.anchorMax = new Vector2(0f, 1f);
            }
            else if(anchor == AnchorTypes.TopRight){
                imageTransform.anchorMin = new Vector2(1f, 1f);
                imageTransform.anchorMax = new Vector2(1f, 1f);
            }
            else if(anchor == AnchorTypes.BottomMiddle){
                imageTransform.anchorMin = new Vector2(0.5f, 0f);
                imageTransform.anchorMax = new Vector2(0.5f, 0f);
            }
            else if(anchor == AnchorTypes.BottomLeft){
                imageTransform.anchorMin = new Vector2(0f, 0f);
                imageTransform.anchorMax = new Vector2(0f, 0f);
            }
            else if(anchor == AnchorTypes.BottomRight){
                imageTransform.anchorMin = new Vector2(1f, 0f);
                imageTransform.anchorMax = new Vector2(1f, 0f);
            }
            else if(anchor == AnchorTypes.CenterLeft){
                imageTransform.anchorMin = new Vector2(0f, 0.5f);
                imageTransform.anchorMax = new Vector2(0f, 0.5f);
            }
            else if(anchor == AnchorTypes.CenterRight){
                imageTransform.anchorMin = new Vector2(1f, 0.5f);
                imageTransform.anchorMax = new Vector2(1f, 0.5f);
            }
        }
    }
}
