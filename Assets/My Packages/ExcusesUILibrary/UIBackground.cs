using UnityEngine;
using UnityEngine.UI;
using System;

namespace Excuses.Libraries.UI
{
    public class UIBackground 
    {
        public UIImage background;
        public GameObject backgroundOBJ;
        public RectTransform backgroundTransform;
        public Image backgroundImage;

        public UIBackground(ExcusesUIMaster uiMaster, GameObject parent, string objectName)
        {
            background = new UIImage(uiMaster, parent, objectName, true);
            backgroundOBJ = background.imageOBJ;
            backgroundTransform = backgroundOBJ.GetComponent<RectTransform>();
            backgroundOBJ.transform.SetParent(parent.transform);
        }

        public UIBackground setSprites(SpriteData spriteData)
        {
            background.setSprites(spriteData);
            return this;
        }
        public UIBackground setSize(ExcusesUIMaster.ScaleType scaleType, Vector2 size)
        {
            background.setSize(scaleType, size);
            return this;
        }
        public UIBackground setSize(ExcusesUIMaster.ScaleType scaleType, Vector2 size, Vector4 offset)
        {
            background.setSize(scaleType, size, offset);
            return this;
        }
        public UIBackground setPosition(int x, int y)
        {
            background.setPosition(x, y);
            return this;
        }

        public UIBackground setLayoutType(ExcusesUIMaster.LayoutType layoutType, LayoutData data, TextAnchor anchor)
        {
            if (layoutType == ExcusesUIMaster.LayoutType.Vertical)
            {
                backgroundOBJ.AddComponent<VerticalLayoutGroup>();
                backgroundOBJ.GetComponent<VerticalLayoutGroup>().childAlignment = anchor;
                backgroundOBJ.GetComponent<VerticalLayoutGroup>().childForceExpandHeight = false;
                backgroundOBJ.GetComponent<VerticalLayoutGroup>().childForceExpandWidth = false;
                backgroundOBJ.GetComponent<VerticalLayoutGroup>().childControlWidth = false;
                backgroundOBJ.GetComponent<VerticalLayoutGroup>().childControlHeight = false;
                backgroundOBJ.GetComponent<VerticalLayoutGroup>().padding.left = data.left;
                backgroundOBJ.GetComponent<VerticalLayoutGroup>().padding.top = data.top;
                backgroundOBJ.GetComponent<VerticalLayoutGroup>().padding.right = data.right;
                backgroundOBJ.GetComponent<VerticalLayoutGroup>().padding.bottom = data.bottom;
                backgroundOBJ.GetComponent<VerticalLayoutGroup>().spacing = data.spacing;

            }
            else if (layoutType == ExcusesUIMaster.LayoutType.Horizontal)
            {
                backgroundOBJ.AddComponent<HorizontalLayoutGroup>();
                backgroundOBJ.GetComponent<HorizontalLayoutGroup>().childAlignment = anchor;
                backgroundOBJ.GetComponent<HorizontalLayoutGroup>().childForceExpandHeight = false;
                backgroundOBJ.GetComponent<HorizontalLayoutGroup>().childForceExpandWidth = false;
                backgroundOBJ.GetComponent<HorizontalLayoutGroup>().childControlWidth = false;
                backgroundOBJ.GetComponent<HorizontalLayoutGroup>().childControlHeight = false;
                backgroundOBJ.GetComponent<HorizontalLayoutGroup>().padding.left = data.left;
                backgroundOBJ.GetComponent<HorizontalLayoutGroup>().padding.top = data.top;
                backgroundOBJ.GetComponent<HorizontalLayoutGroup>().padding.right = data.right;
                backgroundOBJ.GetComponent<HorizontalLayoutGroup>().padding.bottom = data.bottom;
                backgroundOBJ.GetComponent<HorizontalLayoutGroup>().spacing = data.spacing;
            }
            else if (layoutType == ExcusesUIMaster.LayoutType.Grid)
            {
                backgroundOBJ.AddComponent<GridLayoutGroup>();
                backgroundOBJ.GetComponent<GridLayoutGroup>().childAlignment = anchor;
                backgroundOBJ.GetComponent<GridLayoutGroup>().padding.left = data.left;
                backgroundOBJ.GetComponent<GridLayoutGroup>().padding.top = data.top;
                backgroundOBJ.GetComponent<GridLayoutGroup>().padding.right = data.right;
                backgroundOBJ.GetComponent<GridLayoutGroup>().padding.bottom = data.bottom;
                backgroundOBJ.GetComponent<GridLayoutGroup>().spacing = data.gridSpacing;
                backgroundOBJ.GetComponent<GridLayoutGroup>().cellSize = data.gridCellSize;
            }
            return this;
        }

        public UIBackground setContentSize(ContentSizeFitter.FitMode horizontalFitMode, ContentSizeFitter.FitMode verticalFitMode)
        {
            ContentSizeFitter fitter = backgroundOBJ.AddComponent<ContentSizeFitter>();
            switch (horizontalFitMode)
            {
                case ContentSizeFitter.FitMode.Unconstrained:
                    break;
                case ContentSizeFitter.FitMode.MinSize:
                    break;
                case ContentSizeFitter.FitMode.PreferredSize:
                    break;
            }
            switch (verticalFitMode)
            {
                case ContentSizeFitter.FitMode.Unconstrained:
                    break;
                case ContentSizeFitter.FitMode.MinSize:
                    break;
                case ContentSizeFitter.FitMode.PreferredSize:
                    break;
            }
            fitter.horizontalFit = horizontalFitMode;
            fitter.verticalFit = verticalFitMode;
            return this;
        }

        public UIBackground setAnchor(Vector2 anchorPosition)
        {
            background.setAnchor(anchorPosition);
            return this;
        }
    }
}
