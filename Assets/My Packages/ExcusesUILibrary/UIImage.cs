using UnityEngine;
using UnityEngine.UI;

namespace Excuses.Libraries.UI
{
    public class UIImage
    {
        public GameObject imageOBJ;
        public RectTransform imageTransform;
        public Image image;
        public UIImage(ExcusesUIMaster uiMaster, GameObject parent, string objectName, bool tiled)
        {
            imageOBJ = new GameObject(objectName, typeof(RectTransform));
            imageTransform = imageOBJ.GetComponent<RectTransform>();
            imageOBJ.transform.SetParent(parent.transform);
            imageOBJ.AddComponent<Image>();
            image = imageOBJ.GetComponent<Image>();
            if (tiled)
            {
                image.type = Image.Type.Tiled;
            }
        }

        public UIImage setSprites(SpriteData data)
        {
            image.sprite = data.sprite;
            image.color = data.color;
            return this;
        }

        public UIImage setSize(ExcusesUIMaster.ScaleType scaleType, Vector2 size)
        {
            if (scaleType == ExcusesUIMaster.ScaleType.Default)
            {
                imageTransform.sizeDelta = size;
            }
            else if (scaleType == ExcusesUIMaster.ScaleType.ExpandAll)
            {
                imageTransform.anchorMin = Vector2.zero;
                imageTransform.anchorMax = Vector2.one;
                imageTransform.offsetMin = Vector2.zero;
                imageTransform.offsetMax = Vector2.zero;
            }
            else if (scaleType == ExcusesUIMaster.ScaleType.ExpandY)
            {
                RectTransform parentRect = imageOBJ.transform.parent.GetComponent<RectTransform>();
                imageTransform.anchorMin = Vector2.zero;
                imageTransform.anchorMax = Vector2.one;
                imageTransform.offsetMin = new Vector2(0f, parentRect.offsetMin.y);
                imageTransform.offsetMax = new Vector2(0f, parentRect.offsetMax.y);
                imageTransform.sizeDelta = new Vector2(size.x, imageTransform.sizeDelta.y);
            }
            else if (scaleType == ExcusesUIMaster.ScaleType.ExpandX)
            {
                RectTransform parentRect = imageOBJ.transform.parent.GetComponent<RectTransform>();
                imageTransform.anchorMin = Vector2.zero;
                imageTransform.anchorMax = Vector2.one;
                imageTransform.offsetMin = new Vector2(parentRect.offsetMin.x, 0f);
                imageTransform.offsetMax = new Vector2(parentRect.offsetMax.x, 0f);
                imageTransform.sizeDelta = new Vector2(imageTransform.sizeDelta.x, size.y);
            }
            return this;
        }

        public UIImage setSize(ExcusesUIMaster.ScaleType scaleType, Vector2 size, Vector4 offset)
        {
            if (scaleType == ExcusesUIMaster.ScaleType.Default)
            {
                imageTransform.sizeDelta = size;
            }
            else if (scaleType == ExcusesUIMaster.ScaleType.ExpandAll)
            {
                imageTransform.anchorMin = Vector2.zero;
                imageTransform.anchorMax = Vector2.one;
                imageTransform.offsetMin = new Vector2(offset.x, offset.y);
                imageTransform.offsetMax = new Vector2(-offset.z, -offset.w);
            }
            else if (scaleType == ExcusesUIMaster.ScaleType.ExpandY)
            {
                RectTransform parentRect = imageOBJ.transform.parent.GetComponent<RectTransform>();
                imageTransform.anchorMin = Vector2.zero;
                imageTransform.anchorMax = Vector2.one;
                imageTransform.offsetMin = new Vector2(0f, parentRect.offsetMin.y + offset.y);
                imageTransform.offsetMax = new Vector2(0f, parentRect.offsetMax.y - offset.w);
                imageTransform.sizeDelta = new Vector2(size.x, imageTransform.sizeDelta.y);
            }
            else if (scaleType == ExcusesUIMaster.ScaleType.ExpandX)
            {
                RectTransform parentRect = imageOBJ.transform.parent.GetComponent<RectTransform>();
                imageTransform.anchorMin = Vector2.zero;
                imageTransform.anchorMax = Vector2.one;
                imageTransform.offsetMin = new Vector2(parentRect.offsetMin.x + offset.x, 0f);
                imageTransform.offsetMax = new Vector2(parentRect.offsetMax.x - offset.z, 0f);
                imageTransform.sizeDelta = new Vector2(imageTransform.sizeDelta.x, size.y);
            }
            return this;
        }

        public UIImage setPosition(int x, int y)
        {
            imageTransform.anchoredPosition = new Vector2(x, y);
            return this;
        }

        public UIImage setAnchor(Vector2 anchorPosition)
        {
            imageTransform.anchorMin = anchorPosition;
            imageTransform.anchorMax = anchorPosition;

            imageTransform.pivot = anchorPosition;

            imageTransform.anchoredPosition = new Vector2(0, 0);
            return this;
        }
    }
}
