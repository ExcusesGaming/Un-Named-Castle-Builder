
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Excuses.Libraries.UI
{
    public class UIScrollMenu
    {
        public UIImage scrollMenu;
        public ScrollRect scrollMenuData;

        public UIImage viewport;

        public GameObject contentOBJ;
        public RectTransform contentTransform;
        public ContentSizeFitter contentSizeFitter;

        public UIImage horizontalScroll;
        public Scrollbar horizontalScrollData;

        public GameObject horizontalScrollAreaOBJ;
        public RectTransform horizontalScrollAreaTransform;

        public UIImage horizontalScrollHandle;

        public UIImage verticalScroll;
        public Scrollbar verticalScrollData;

        public GameObject verticalScrollAreaOBJ;
        public RectTransform verticalScrollAreaTransform;

        public UIImage verticalScrollHandle;

        public UIScrollMenu(ExcusesUIMaster uiMaster, GameObject parent, string objectName)
        {
            scrollMenu = new UIImage(uiMaster, parent, objectName, true);
            scrollMenu.imageTransform.SetParent(parent.transform);
            scrollMenuData = scrollMenu.imageOBJ.AddComponent<ScrollRect>();

            viewport = new UIImage(uiMaster, parent, objectName + " Viewport", true);
            viewport.imageTransform.SetParent(scrollMenu.imageTransform);
            viewport.imageOBJ.AddComponent<Mask>();
            viewport.imageOBJ.GetComponent<Mask>().showMaskGraphic = false;

            contentOBJ = new GameObject(objectName + " Content", typeof(RectTransform));
            contentTransform = contentOBJ.GetComponent<RectTransform>();
            contentTransform.pivot = new Vector2(0, 1);
            contentSizeFitter = contentOBJ.AddComponent<ContentSizeFitter>();
            contentTransform.SetParent(viewport.imageTransform);

            horizontalScroll = new UIImage(uiMaster, parent, objectName + " Horizontal Scroll", true);
            horizontalScroll.imageTransform.SetParent(scrollMenu.imageTransform);
            horizontalScrollData = horizontalScroll.imageOBJ.AddComponent<Scrollbar>();

            horizontalScrollAreaOBJ = new GameObject(objectName + " Horizontal Scroll Area", typeof(RectTransform));
            horizontalScrollAreaTransform = horizontalScrollAreaOBJ.GetComponent<RectTransform>();
            horizontalScrollAreaTransform.SetParent(horizontalScroll.imageTransform);

            horizontalScrollHandle = new UIImage(uiMaster, parent, objectName + " Horizontal Scroll Handle", true);
            horizontalScrollHandle.imageTransform.SetParent(horizontalScrollAreaTransform);

            verticalScroll = new UIImage(uiMaster, parent, objectName + " Vertical Scroll", true);
            verticalScroll.imageTransform.SetParent(scrollMenu.imageTransform);
            verticalScrollData = verticalScroll.imageOBJ.AddComponent<Scrollbar>();

            verticalScrollAreaOBJ = new GameObject(objectName + " Vertical Scroll Area", typeof(RectTransform));
            verticalScrollAreaTransform = verticalScrollAreaOBJ.GetComponent<RectTransform>();
            verticalScrollAreaTransform.SetParent(verticalScroll.imageTransform);

            verticalScrollHandle = new UIImage(uiMaster, parent, objectName + " Vertical Scroll Handle", true);
            verticalScrollHandle.imageTransform.SetParent(verticalScrollAreaTransform);

            scrollMenuData.content = contentTransform;
            scrollMenuData.viewport = viewport.imageTransform;
            scrollMenuData.horizontalScrollbar = horizontalScrollData;
            scrollMenuData.verticalScrollbar = verticalScrollData;
            horizontalScrollData.direction = Scrollbar.Direction.LeftToRight;
            horizontalScrollData.handleRect = horizontalScrollHandle.imageTransform;
            verticalScrollData.direction = Scrollbar.Direction.BottomToTop;
            verticalScrollData.handleRect = verticalScrollHandle.imageTransform;
        }

        public UIScrollMenu setSprites(SpriteData spriteData, SpriteData spriteData1, SpriteData spriteData2)
        {
            scrollMenu.setSprites(spriteData);
            horizontalScroll.setSprites(spriteData1);
            horizontalScrollHandle.setSprites(spriteData2);
            verticalScroll.setSprites(spriteData1);
            verticalScrollHandle.setSprites(spriteData2);

            return this;
        }
        public UIScrollMenu setSize(ExcusesUIMaster.ScaleType scaleType, Vector2 size)
        {
            scrollMenu.setSize(scaleType, size);

            viewport.imageTransform.anchorMin = Vector2.zero;
            viewport.imageTransform.anchorMax = Vector2.one;
            viewport.imageTransform.offsetMin = new Vector2(8, 8);
            viewport.imageTransform.offsetMax = new Vector2(-8, -8);

            contentTransform.anchorMin = new Vector2(0.5f, 0.5f);
            contentTransform.anchorMax = new Vector2(0.5f, 0.5f);
            contentTransform.sizeDelta = new Vector2(0, 0);

            horizontalScroll.imageTransform.anchorMin = new Vector2(0, 0);
            horizontalScroll.imageTransform.anchorMax = new Vector2(1, 0);
            horizontalScroll.imageTransform.pivot = new Vector2(0.5f, 0);
            horizontalScroll.imageTransform.offsetMin = new Vector2(0, 0);
            horizontalScroll.imageTransform.offsetMax = new Vector2(-20, 0);
            horizontalScroll.imageTransform.sizeDelta = new Vector2(horizontalScroll.imageTransform.sizeDelta.x, 20);

            horizontalScrollAreaTransform.anchorMin = Vector2.zero;
            horizontalScrollAreaTransform.anchorMax = Vector2.one;
            horizontalScrollAreaTransform.offsetMin = new Vector2(10, 10);
            horizontalScrollAreaTransform.offsetMax = new Vector2(-10, -10);

            horizontalScrollHandle.imageTransform.anchorMin = Vector2.zero;
            horizontalScrollHandle.imageTransform.anchorMax = Vector2.one;
            horizontalScrollHandle.imageTransform.offsetMin = new Vector2(-10, -10);
            horizontalScrollHandle.imageTransform.offsetMax = new Vector2(10, 10);

            verticalScroll.imageTransform.anchorMin = new Vector2(1, 0);
            verticalScroll.imageTransform.anchorMax = new Vector2(1, 1);
            verticalScroll.imageTransform.pivot = new Vector2(1f, 0.5f);
            verticalScroll.imageTransform.offsetMin = new Vector2(0, 20);
            verticalScroll.imageTransform.offsetMax = new Vector2(0, 0);
            verticalScroll.imageTransform.sizeDelta = new Vector2(20, verticalScroll.imageTransform.sizeDelta.y);

            verticalScrollAreaTransform.anchorMin = Vector2.zero;
            verticalScrollAreaTransform.anchorMax = Vector2.one;
            verticalScrollAreaTransform.offsetMin = new Vector2(10, 10);
            verticalScrollAreaTransform.offsetMax = new Vector2(-10, -10);

            verticalScrollHandle.imageTransform.anchorMin = Vector2.zero;
            verticalScrollHandle.imageTransform.anchorMax = Vector2.one;
            verticalScrollHandle.imageTransform.offsetMin = new Vector2(-10, -10);
            verticalScrollHandle.imageTransform.offsetMax = new Vector2(10, 10);

            return this;
        }
        public UIScrollMenu setSize(ExcusesUIMaster.ScaleType scaleType, Vector2 size, Vector4 offset)
        {
            scrollMenu.setSize(scaleType, size, offset);

            viewport.imageTransform.anchorMin = Vector2.zero;
            viewport.imageTransform.anchorMax = Vector2.one;
            viewport.imageTransform.offsetMin = new Vector2(8, 8);
            viewport.imageTransform.offsetMax = new Vector2(-8, -8);

            contentTransform.anchorMin = new Vector2(0.5f, 0.5f);
            contentTransform.anchorMax = new Vector2(0.5f, 0.5f);

            horizontalScroll.imageTransform.anchorMin = new Vector2(0, 0);
            horizontalScroll.imageTransform.anchorMax = new Vector2(1, 0);
            horizontalScroll.imageTransform.pivot = new Vector2(0.5f, 0);
            horizontalScroll.imageTransform.offsetMin = new Vector2(0, 0);
            horizontalScroll.imageTransform.offsetMax = new Vector2(-20, 0);
            horizontalScroll.imageTransform.sizeDelta = new Vector2(horizontalScroll.imageTransform.sizeDelta.x, 20);

            horizontalScrollAreaTransform.anchorMin = Vector2.zero;
            horizontalScrollAreaTransform.anchorMax = Vector2.one;
            horizontalScrollAreaTransform.offsetMin = new Vector2(10, 10);
            horizontalScrollAreaTransform.offsetMax = new Vector2(-10, -10);

            horizontalScrollHandle.imageTransform.anchorMin = Vector2.zero;
            horizontalScrollHandle.imageTransform.anchorMax = Vector2.one;
            horizontalScrollHandle.imageTransform.offsetMin = new Vector2(-10, -10);
            horizontalScrollHandle.imageTransform.offsetMax = new Vector2(10, 10);

            verticalScroll.imageTransform.anchorMin = new Vector2(1, 0);
            verticalScroll.imageTransform.anchorMax = new Vector2(1, 1);
            verticalScroll.imageTransform.pivot = new Vector2(1f, 0.5f);
            verticalScroll.imageTransform.offsetMin = new Vector2(0, 20);
            verticalScroll.imageTransform.offsetMax = new Vector2(0, 0);
            verticalScroll.imageTransform.sizeDelta = new Vector2(20, verticalScroll.imageTransform.sizeDelta.y);

            verticalScrollAreaTransform.anchorMin = Vector2.zero;
            verticalScrollAreaTransform.anchorMax = Vector2.one;
            verticalScrollAreaTransform.offsetMin = new Vector2(10, 10);
            verticalScrollAreaTransform.offsetMax = new Vector2(-10, -10);

            verticalScrollHandle.imageTransform.anchorMin = Vector2.zero;
            verticalScrollHandle.imageTransform.anchorMax = Vector2.one;
            verticalScrollHandle.imageTransform.offsetMin = new Vector2(-10, -10);
            verticalScrollHandle.imageTransform.offsetMax = new Vector2(10, 10);



            return this;
        }
        public UIScrollMenu setPosition(int x, int y)
        {
            scrollMenu.setPosition(x, y);
            return this;
        }
       
        public UIScrollMenu setAnchor(Vector2 anchorPosition)
        {
            scrollMenu.setAnchor(anchorPosition);
            return this;
        }

        public UIScrollMenu setContentSize(ContentSizeFitter.FitMode horizontalFitMode, ContentSizeFitter.FitMode verticalFitMode)
        {
            switch (horizontalFitMode)
            {
                case ContentSizeFitter.FitMode.Unconstrained:
                    contentTransform.sizeDelta = new Vector2(scrollMenu.imageTransform.sizeDelta.x - 16, contentTransform.sizeDelta.y);
                    break;
                case ContentSizeFitter.FitMode.MinSize:
                    break;
                case ContentSizeFitter.FitMode.PreferredSize:
                    break;
            }
            switch (verticalFitMode)
            {
                case ContentSizeFitter.FitMode.Unconstrained:
                    contentTransform.sizeDelta = new Vector2(contentTransform.sizeDelta.x, scrollMenu.imageTransform.sizeDelta.y - 16);
                    break;
                case ContentSizeFitter.FitMode.MinSize:
                    break;
                case ContentSizeFitter.FitMode.PreferredSize:
                    break;
            }
            contentSizeFitter.horizontalFit = horizontalFitMode;
            contentSizeFitter.verticalFit = verticalFitMode;
            scrollMenuData.verticalNormalizedPosition = 1f;
            scrollMenuData.horizontalNormalizedPosition = 0f;
            return this;
        }

        public UIScrollMenu setContentSize(ContentSizeFitter.FitMode horizontalFitMode, ContentSizeFitter.FitMode verticalFitMode, Vector2 size)
        {
            switch (horizontalFitMode)
            {
                case ContentSizeFitter.FitMode.Unconstrained:
                    contentTransform.sizeDelta = new Vector2(scrollMenu.imageTransform.sizeDelta.x + size.x, contentTransform.sizeDelta.y);
                    break;
                case ContentSizeFitter.FitMode.MinSize:
                    break;
                case ContentSizeFitter.FitMode.PreferredSize:
                    break;
            }
            switch (verticalFitMode)
            {
                case ContentSizeFitter.FitMode.Unconstrained:
                    contentTransform.sizeDelta = new Vector2(contentTransform.sizeDelta.x, scrollMenu.imageTransform.sizeDelta.y + size.y);
                    break;
                case ContentSizeFitter.FitMode.MinSize:
                    break;
                case ContentSizeFitter.FitMode.PreferredSize:
                    break;
            }
            contentSizeFitter.horizontalFit = horizontalFitMode;
            contentSizeFitter.verticalFit = verticalFitMode;
            return this;
        }

        public UIScrollMenu setLayoutType(ExcusesUIMaster.LayoutType layoutType, LayoutData data, TextAnchor anchor)
        {
            if (layoutType == ExcusesUIMaster.LayoutType.Vertical)
            {
                contentOBJ.AddComponent<VerticalLayoutGroup>();
                contentOBJ.GetComponent<VerticalLayoutGroup>().childAlignment = anchor;
                contentOBJ.GetComponent<VerticalLayoutGroup>().childForceExpandHeight = false;
                contentOBJ.GetComponent<VerticalLayoutGroup>().childForceExpandWidth = false;
                contentOBJ.GetComponent<VerticalLayoutGroup>().childControlWidth = false;
                contentOBJ.GetComponent<VerticalLayoutGroup>().childControlHeight = false;
                contentOBJ.GetComponent<VerticalLayoutGroup>().padding.left = data.left;
                contentOBJ.GetComponent<VerticalLayoutGroup>().padding.top = data.top;
                contentOBJ.GetComponent<VerticalLayoutGroup>().padding.right = data.right;
                contentOBJ.GetComponent<VerticalLayoutGroup>().padding.bottom = data.bottom;
                contentOBJ.GetComponent<VerticalLayoutGroup>().spacing = data.spacing;

            }
            else if (layoutType == ExcusesUIMaster.LayoutType.Horizontal)
            {
                contentOBJ.AddComponent<HorizontalLayoutGroup>();
                contentOBJ.GetComponent<HorizontalLayoutGroup>().childAlignment = anchor;
                contentOBJ.GetComponent<HorizontalLayoutGroup>().childForceExpandHeight = false;
                contentOBJ.GetComponent<HorizontalLayoutGroup>().childForceExpandWidth = false;
                contentOBJ.GetComponent<HorizontalLayoutGroup>().childControlWidth = false;
                contentOBJ.GetComponent<HorizontalLayoutGroup>().childControlHeight = false;
                contentOBJ.GetComponent<HorizontalLayoutGroup>().padding.left = data.left;
                contentOBJ.GetComponent<HorizontalLayoutGroup>().padding.top = data.top;
                contentOBJ.GetComponent<HorizontalLayoutGroup>().padding.right = data.right;
                contentOBJ.GetComponent<HorizontalLayoutGroup>().padding.bottom = data.bottom;
                contentOBJ.GetComponent<HorizontalLayoutGroup>().spacing = data.spacing;
            }
            else if (layoutType == ExcusesUIMaster.LayoutType.Grid)
            {
                contentOBJ.AddComponent<GridLayoutGroup>();
                contentOBJ.GetComponent<GridLayoutGroup>().childAlignment = anchor;
                contentOBJ.GetComponent<GridLayoutGroup>().padding.left = data.left;
                contentOBJ.GetComponent<GridLayoutGroup>().padding.top = data.top;
                contentOBJ.GetComponent<GridLayoutGroup>().padding.right = data.right;
                contentOBJ.GetComponent<GridLayoutGroup>().padding.bottom = data.bottom;
                contentOBJ.GetComponent<GridLayoutGroup>().spacing = data.gridSpacing;
                contentOBJ.GetComponent<GridLayoutGroup>().cellSize = data.gridCellSize;
            }
            return this;
        }

        public UIScrollMenu setScrollContraints(bool horizontal, bool vertical)
        {
            scrollMenuData.horizontal = horizontal; scrollMenuData.vertical = vertical;
            return this;
        }

        public UIScrollMenu setScrollType(ScrollRect.MovementType movementType)
        {
            scrollMenuData.movementType = movementType;
            return this;
        }

        public UIScrollMenu setScrollSensitivity(float sensitivity)
        {
            scrollMenuData.scrollSensitivity = sensitivity;
            return this;
        }

        public UIScrollMenu setNormalizedPosition()
        {
            scrollMenuData.verticalNormalizedPosition = 1f;
            scrollMenuData.horizontalNormalizedPosition = 0f;
            return this;
        }

        public UIScrollMenu setScrollbarsInvisible()
        {
            scrollMenuData.horizontalScrollbar = null;
            scrollMenuData.verticalScrollbar = null;
            horizontalScroll.imageOBJ.SetActive(false);
            verticalScroll.imageOBJ.SetActive(false);
            return this;
        }
    }
}
