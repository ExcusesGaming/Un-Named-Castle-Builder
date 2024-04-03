using System;
using UnityEngine;
using UnityEngine.UI;

namespace Excuses.UI
{
    public class ButtonUI
    {
        public GameObject buttonOBJ;
        public RectTransform buttonTransform;
        public Image buttonImage;
        public Button buttonData;

        public ImageUI hover;

        public TextUI buttonText;

        public ImageUI buttonIcon;


        public ButtonUI(string objectName, GameObject parent)
        {
            ImageUI image = new ImageUI(objectName, parent, true);
            buttonOBJ = image.imageOBJ;
            buttonTransform = image.imageTransform;
            buttonImage = image.image;
            buttonData = buttonOBJ.AddComponent<Button>();
            buttonOBJ.AddComponent<HoverableObjectUI>();
            buttonOBJ.GetComponent<HoverableObjectUI>().onEnter += onEnter;
            buttonOBJ.GetComponent<HoverableObjectUI>().onExit += onExit;

            hover = new ImageUI(objectName + "Hover", buttonOBJ, true);
            hover.imageOBJ.SetActive(false);
        }

        public ButtonUI setSprites(SpriteData normal, SpriteData click, SpriteData hoverOver)
        {
            buttonImage.sprite = normal.sprite;
            buttonImage.color = normal.color;

            buttonData.transition = Selectable.Transition.SpriteSwap;
            SpriteState spriteState = new SpriteState();
            spriteState.pressedSprite = click.sprite;

            buttonData.spriteState = spriteState;

            hover.setSprites(hoverOver);
            return this;
        }

        public ButtonUI setAnchor(Anchors.AnchorTypes anchor)
        {
            if (anchor == Anchors.AnchorTypes.Center)
            {
                buttonTransform.anchorMin = new Vector2(0.5f, 0.5f);
                buttonTransform.anchorMax = new Vector2(0.5f, 0.5f);
            }
            else if (anchor == Anchors.AnchorTypes.TopMiddle)
            {
                buttonTransform.anchorMin = new Vector2(0.5f, 1f);
                buttonTransform.anchorMax = new Vector2(0.5f, 1f);
            }
            else if (anchor == Anchors.AnchorTypes.TopLeft)
            {
                buttonTransform.anchorMin = new Vector2(0f, 1f);
                buttonTransform.anchorMax = new Vector2(0f, 1f);
            }
            else if (anchor == Anchors.AnchorTypes.TopRight)
            {
                buttonTransform.anchorMin = new Vector2(1f, 1f);
                buttonTransform.anchorMax = new Vector2(1f, 1f);
            }
            else if (anchor == Anchors.AnchorTypes.BottomMiddle)
            {
                buttonTransform.anchorMin = new Vector2(0.5f, 0f);
                buttonTransform.anchorMax = new Vector2(0.5f, 0f);
            }
            else if (anchor == Anchors.AnchorTypes.BottomLeft)
            {
                buttonTransform.anchorMin = new Vector2(0f, 0f);
                buttonTransform.anchorMax = new Vector2(0f, 0f);
            }
            else if (anchor == Anchors.AnchorTypes.BottomRight)
            {
                buttonTransform.anchorMin = new Vector2(1f, 0f);
                buttonTransform.anchorMax = new Vector2(1f, 0f);
            }
            else if (anchor == Anchors.AnchorTypes.CenterLeft)
            {
                buttonTransform.anchorMin = new Vector2(0f, 0.5f);
                buttonTransform.anchorMax = new Vector2(0f, 0.5f);
            }
            else if (anchor == Anchors.AnchorTypes.CenterRight)
            {
                buttonTransform.anchorMin = new Vector2(1f, 0.5f);
                buttonTransform.anchorMax = new Vector2(1f, 0.5f);
            }
            else if (anchor == Anchors.AnchorTypes.ScaleHorizontal)
            {
                RectTransform parentRect = buttonOBJ.transform.parent.GetComponent<RectTransform>();
                buttonTransform.anchorMin = Vector2.zero;
                buttonTransform.anchorMax = Vector2.one;
                buttonTransform.offsetMin = new Vector2(parentRect.offsetMin.x, 0f);
                buttonTransform.offsetMax = new Vector2(parentRect.offsetMax.x, 0f);
                buttonTransform.sizeDelta = new Vector2(buttonTransform.sizeDelta.x, buttonTransform.sizeDelta.y);
            }
            else if (anchor == Anchors.AnchorTypes.ScaleVertical)
            {
                RectTransform parentRect = buttonOBJ.transform.parent.GetComponent<RectTransform>();
                buttonTransform.anchorMin = Vector2.zero;
                buttonTransform.anchorMax = Vector2.one;
                buttonTransform.offsetMin = new Vector2(0f, parentRect.offsetMin.y);
                buttonTransform.offsetMax = new Vector2(0f, parentRect.offsetMax.y);
                buttonTransform.sizeDelta = new Vector2(buttonTransform.sizeDelta.x, buttonTransform.sizeDelta.y);
            }
            else if (anchor == Anchors.AnchorTypes.ScaleAll)
            {
                buttonTransform.anchorMin = Vector2.zero;
                buttonTransform.anchorMax = Vector2.one;
                buttonTransform.offsetMin = Vector2.zero;
                buttonTransform.offsetMax = Vector2.zero;
            }
            hover.setAnchor(Anchors.AnchorTypes.ScaleAll, new Vector4(-4, -4, -4, -4));
            return this;
        }

        public ButtonUI setAnchor(Anchors.AnchorTypes anchor, Vector4 offset)
        {
            if (anchor == Anchors.AnchorTypes.Center)
            {
                buttonTransform.anchorMin = new Vector2(0.5f, 0.5f);
                buttonTransform.anchorMax = new Vector2(0.5f, 0.5f);
            }
            else if (anchor == Anchors.AnchorTypes.TopMiddle)
            {
                buttonTransform.anchorMin = new Vector2(0.5f, 1f);
                buttonTransform.anchorMax = new Vector2(0.5f, 1f);
            }
            else if (anchor == Anchors.AnchorTypes.TopLeft)
            {
                buttonTransform.anchorMin = new Vector2(0f, 1f);
                buttonTransform.anchorMax = new Vector2(0f, 1f);
            }
            else if (anchor == Anchors.AnchorTypes.TopRight)
            {
                buttonTransform.anchorMin = new Vector2(1f, 1f);
                buttonTransform.anchorMax = new Vector2(1f, 1f);
            }
            else if (anchor == Anchors.AnchorTypes.BottomMiddle)
            {
                buttonTransform.anchorMin = new Vector2(0.5f, 0f);
                buttonTransform.anchorMax = new Vector2(0.5f, 0f);
            }
            else if (anchor == Anchors.AnchorTypes.BottomLeft)
            {
                buttonTransform.anchorMin = new Vector2(0f, 0f);
                buttonTransform.anchorMax = new Vector2(0f, 0f);
            }
            else if (anchor == Anchors.AnchorTypes.BottomRight)
            {
                buttonTransform.anchorMin = new Vector2(1f, 0f);
                buttonTransform.anchorMax = new Vector2(1f, 0f);
            }
            else if (anchor == Anchors.AnchorTypes.CenterLeft)
            {
                buttonTransform.anchorMin = new Vector2(0f, 0.5f);
                buttonTransform.anchorMax = new Vector2(0f, 0.5f);
            }
            else if (anchor == Anchors.AnchorTypes.CenterRight)
            {
                buttonTransform.anchorMin = new Vector2(1f, 0.5f);
                buttonTransform.anchorMax = new Vector2(1f, 0.5f);
            }
            else if (anchor == Anchors.AnchorTypes.ScaleHorizontal)
            {
                RectTransform parentRect = buttonOBJ.transform.parent.GetComponent<RectTransform>();
                buttonTransform.anchorMin = Vector2.zero;
                buttonTransform.anchorMax = Vector2.one;
                buttonTransform.offsetMin = new Vector2(parentRect.offsetMin.x + offset.x, 0f);
                buttonTransform.offsetMax = new Vector2(parentRect.offsetMax.x - offset.z, 0f);
                buttonTransform.sizeDelta = new Vector2(buttonTransform.sizeDelta.x, buttonTransform.sizeDelta.y);
            }
            else if (anchor == Anchors.AnchorTypes.ScaleVertical)
            {
                RectTransform parentRect = buttonOBJ.transform.parent.GetComponent<RectTransform>();
                buttonTransform.anchorMin = Vector2.zero;
                buttonTransform.anchorMax = Vector2.one;
                buttonTransform.offsetMin = new Vector2(0f, parentRect.offsetMin.y + offset.y);
                buttonTransform.offsetMax = new Vector2(0f, parentRect.offsetMax.y - offset.w);
                buttonTransform.sizeDelta = new Vector2(buttonTransform.sizeDelta.x, buttonTransform.sizeDelta.y);
            }
            else if (anchor == Anchors.AnchorTypes.ScaleAll)
            {
                buttonTransform.anchorMin = Vector2.zero;
                buttonTransform.anchorMax = Vector2.one;
                buttonTransform.offsetMin = new Vector2(offset.x, offset.y);
                buttonTransform.offsetMax = new Vector2(-offset.z, -offset.w);
            }
            hover.setAnchor(Anchors.AnchorTypes.ScaleAll, new Vector4(-4, -4, -4, -4));
            return this;
        }

        public ButtonUI SetSize(Scales.ScaleTypes scaleType)
        {
            if (scaleType == Scales.ScaleTypes.ExpandAll)
            {
                setAnchor(Anchors.AnchorTypes.ScaleAll);
                hover.SetSize(Scales.ScaleTypes.ExpandAll, new Vector2(0, 0), new Vector4(-4, -4, -4, -4));
            }
            return this;
        }
        public ButtonUI SetSize(Scales.ScaleTypes scaleType, Vector4 offset)
        {
            if (scaleType == Scales.ScaleTypes.ExpandAll)
            {
                setAnchor(Anchors.AnchorTypes.ScaleAll, offset);
                hover.SetSize(Scales.ScaleTypes.ExpandAll, new Vector2(0, 0), new Vector4(-4, -4, -4, -4));
            }
            return this;
        }
        public ButtonUI SetSize(Scales.ScaleTypes scaleType, Vector2 size)
        {
            if (scaleType == Scales.ScaleTypes.Default)
            {
                buttonTransform.sizeDelta = size;
                hover.SetSize(Scales.ScaleTypes.ExpandAll, new Vector2(0, 0), new Vector4(-4, -4, -4, -4));
            }
            if (scaleType == Scales.ScaleTypes.ExpandX)
            {
                setAnchor(Anchors.AnchorTypes.ScaleHorizontal);
                buttonTransform.sizeDelta = new Vector2(buttonTransform.sizeDelta.x, size.y);
                hover.SetSize(Scales.ScaleTypes.ExpandAll, new Vector2(0, 0), new Vector4(-4, -4, -4, -4));
            }
            if (scaleType == Scales.ScaleTypes.ExpandY)
            {
                setAnchor(Anchors.AnchorTypes.ScaleVertical);
                buttonTransform.sizeDelta = new Vector2(size.x, buttonTransform.sizeDelta.y);
                hover.SetSize(Scales.ScaleTypes.ExpandAll, new Vector2(0, 0), new Vector4(-4, -4, -4, -4));

            }
            return this;
        }
        public ButtonUI SetSize(Scales.ScaleTypes scaleType, Vector2 size, Vector4 offset)
        {
            if (scaleType == Scales.ScaleTypes.Default)
            {
                buttonTransform.sizeDelta = size;
            }
            if (scaleType == Scales.ScaleTypes.ExpandX)
            {
                setAnchor(Anchors.AnchorTypes.ScaleHorizontal, offset);
                buttonTransform.sizeDelta = new Vector2(buttonTransform.sizeDelta.x, size.y);
            }
            if (scaleType == Scales.ScaleTypes.ExpandY)
            {
                setAnchor(Anchors.AnchorTypes.ScaleVertical, offset);
                buttonTransform.sizeDelta = new Vector2(size.x, buttonTransform.sizeDelta.y);

            }
            return this;
        }

        public ButtonUI setPosition(int x, int y)
        {
            buttonTransform.anchoredPosition = new Vector2(x, y);
            return this;
        }

        public void onEnter()
        {
            hover.imageOBJ.SetActive(true);
        }

        public void onExit()
        {
            hover.imageOBJ.SetActive(false);
        }

        public ButtonUI setClickFunction(Action function)
        {
            buttonData.onClick.AddListener(delegate { function(); });
            return this;
        }
        public ButtonUI setClickFunction<T1>(Action<T1> function, T1 input1)
        {
            buttonData.onClick.AddListener(delegate { function(input1); });
            return this;
        }
        public ButtonUI setClickFunction<T1, T2>(Action<T1, T2> function, T1 input1, T2 input2)
        {
            buttonData.onClick.AddListener(delegate { function(input1, input2); });
            return this;
        }
        public ButtonUI setClickFunction<T1, T2, T3>(Action<T1, T2, T3> function, T1 input1, T2 input2, T3 input3)
        {
            buttonData.onClick.AddListener(delegate { function(input1, input2, input3); });
            return this;
        }
        public ButtonUI setClickFunction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> function, T1 input1, T2 input2, T3 input3, T4 input4)
        {
            buttonData.onClick.AddListener(delegate { function(input1, input2, input3, input4); });
            return this;
        }

        public ButtonUI setClickFunction<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> function, T1 input1, T2 input2, T3 input3, T4 input4, T5 input5)
        {
            buttonData.onClick.AddListener(delegate { function(input1, input2, input3, input4, input5); });
            return this;
        }

        public ButtonUI addText(TextData data, Vector4 offset)
        {
            buttonText = new TextUI(buttonOBJ.gameObject.name + " Text", buttonOBJ.gameObject)
                .setAnchor(Anchors.AnchorTypes.ScaleAll, offset)
                .setText(data);
            return this;
        }

        public ButtonUI addIcon(SpriteData iconData, Vector4 offset, bool tiled)
        {
            buttonIcon = new ImageUI(buttonOBJ.gameObject.name + " icon", buttonOBJ.gameObject, tiled)
                .setAnchor(Anchors.AnchorTypes.ScaleAll, offset)
                .setSprites(iconData);
            return this;
        }
    }
}