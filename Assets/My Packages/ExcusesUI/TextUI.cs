using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Excuses.UI
{
    public class TextUI
    {
        public GameObject textOBJ;
        public RectTransform textTransform;
        public TextMeshProUGUI textData;
        public float minHeight;
        public TextUI(string objectName, GameObject parent)
        {
            textOBJ = new GameObject(objectName, typeof(RectTransform));
            textOBJ.transform.SetParent(parent.transform);
            textTransform = textOBJ.GetComponent<RectTransform>();
            textData = textOBJ.AddComponent<TextMeshProUGUI>();
        }

        public TextUI setAnchor(Anchors.AnchorTypes anchor)
        {
            if (anchor == Anchors.AnchorTypes.Center)
            {
                textTransform.anchorMin = new Vector2(0.5f, 0.5f);
                textTransform.anchorMax = new Vector2(0.5f, 0.5f);
            }
            else if (anchor == Anchors.AnchorTypes.TopMiddle)
            {
                textTransform.anchorMin = new Vector2(0.5f, 1f);
                textTransform.anchorMax = new Vector2(0.5f, 1f);
            }
            else if (anchor == Anchors.AnchorTypes.TopLeft)
            {
                textTransform.anchorMin = new Vector2(0f, 1f);
                textTransform.anchorMax = new Vector2(0f, 1f);
            }
            else if (anchor == Anchors.AnchorTypes.TopRight)
            {
                textTransform.anchorMin = new Vector2(1f, 1f);
                textTransform.anchorMax = new Vector2(1f, 1f);
            }
            else if (anchor == Anchors.AnchorTypes.BottomMiddle)
            {
                textTransform.anchorMin = new Vector2(0.5f, 0f);
                textTransform.anchorMax = new Vector2(0.5f, 0f);
            }
            else if (anchor == Anchors.AnchorTypes.BottomLeft)
            {
                textTransform.anchorMin = new Vector2(0f, 0f);
                textTransform.anchorMax = new Vector2(0f, 0f);
            }
            else if (anchor == Anchors.AnchorTypes.BottomRight)
            {
                textTransform.anchorMin = new Vector2(1f, 0f);
                textTransform.anchorMax = new Vector2(1f, 0f);
            }
            else if (anchor == Anchors.AnchorTypes.CenterLeft)
            {
                textTransform.anchorMin = new Vector2(0f, 0.5f);
                textTransform.anchorMax = new Vector2(0f, 0.5f);
            }
            else if (anchor == Anchors.AnchorTypes.CenterRight)
            {
                textTransform.anchorMin = new Vector2(1f, 0.5f);
                textTransform.anchorMax = new Vector2(1f, 0.5f);
            }
            else if (anchor == Anchors.AnchorTypes.ScaleHorizontal)
            {
                RectTransform parentRect = textOBJ.transform.parent.GetComponent<RectTransform>();
                textTransform.anchorMin = Vector2.zero;
                textTransform.anchorMax = Vector2.one;
                textTransform.offsetMin = new Vector2(parentRect.offsetMin.x, 0f);
                textTransform.offsetMax = new Vector2(parentRect.offsetMax.x, 0f);
                textTransform.sizeDelta = new Vector2(textTransform.sizeDelta.x, textTransform.sizeDelta.y);
            }
            else if (anchor == Anchors.AnchorTypes.ScaleVertical)
            {
                RectTransform parentRect = textOBJ.transform.parent.GetComponent<RectTransform>();
                textTransform.anchorMin = Vector2.zero;
                textTransform.anchorMax = Vector2.one;
                textTransform.offsetMin = new Vector2(0f, parentRect.offsetMin.y);
                textTransform.offsetMax = new Vector2(0f, parentRect.offsetMax.y);
                textTransform.sizeDelta = new Vector2(textTransform.sizeDelta.x, textTransform.sizeDelta.y);
            }
            else if (anchor == Anchors.AnchorTypes.ScaleAll)
            {
                textTransform.anchorMin = Vector2.zero;
                textTransform.anchorMax = Vector2.one;
                textTransform.offsetMin = Vector2.zero;
                textTransform.offsetMax = Vector2.zero;
            }
            return this;
        }

        public TextUI setAnchor(Anchors.AnchorTypes anchor, Vector4 offset)
        {
            if (anchor == Anchors.AnchorTypes.Center)
            {
                textTransform.anchorMin = new Vector2(0.5f, 0.5f);
                textTransform.anchorMax = new Vector2(0.5f, 0.5f);
            }
            else if (anchor == Anchors.AnchorTypes.TopMiddle)
            {
                textTransform.anchorMin = new Vector2(0.5f, 1f);
                textTransform.anchorMax = new Vector2(0.5f, 1f);
            }
            else if (anchor == Anchors.AnchorTypes.TopLeft)
            {
                textTransform.anchorMin = new Vector2(0f, 1f);
                textTransform.anchorMax = new Vector2(0f, 1f);
            }
            else if (anchor == Anchors.AnchorTypes.TopRight)
            {
                textTransform.anchorMin = new Vector2(1f, 1f);
                textTransform.anchorMax = new Vector2(1f, 1f);
            }
            else if (anchor == Anchors.AnchorTypes.BottomMiddle)
            {
                textTransform.anchorMin = new Vector2(0.5f, 0f);
                textTransform.anchorMax = new Vector2(0.5f, 0f);
            }
            else if (anchor == Anchors.AnchorTypes.BottomLeft)
            {
                textTransform.anchorMin = new Vector2(0f, 0f);
                textTransform.anchorMax = new Vector2(0f, 0f);
            }
            else if (anchor == Anchors.AnchorTypes.BottomRight)
            {
                textTransform.anchorMin = new Vector2(1f, 0f);
                textTransform.anchorMax = new Vector2(1f, 0f);
            }
            else if (anchor == Anchors.AnchorTypes.CenterLeft)
            {
                textTransform.anchorMin = new Vector2(0f, 0.5f);
                textTransform.anchorMax = new Vector2(0f, 0.5f);
            }
            else if (anchor == Anchors.AnchorTypes.CenterRight)
            {
                textTransform.anchorMin = new Vector2(1f, 0.5f);
                textTransform.anchorMax = new Vector2(1f, 0.5f);
            }
            else if (anchor == Anchors.AnchorTypes.ScaleHorizontal)
            {
                RectTransform parentRect = textOBJ.transform.parent.GetComponent<RectTransform>();
                textTransform.anchorMin = Vector2.zero;
                textTransform.anchorMax = Vector2.one;
                textTransform.offsetMin = new Vector2(parentRect.offsetMin.x + offset.x, 0f);
                textTransform.offsetMax = new Vector2(parentRect.offsetMax.x - offset.z, 0f);
                textTransform.sizeDelta = new Vector2(textTransform.sizeDelta.x, textTransform.sizeDelta.y);
            }
            else if (anchor == Anchors.AnchorTypes.ScaleVertical)
            {
                RectTransform parentRect = textOBJ.transform.parent.GetComponent<RectTransform>();
                textTransform.anchorMin = Vector2.zero;
                textTransform.anchorMax = Vector2.one;
                textTransform.offsetMin = new Vector2(0f, parentRect.offsetMin.y + offset.y);
                textTransform.offsetMax = new Vector2(0f, parentRect.offsetMax.y - offset.w);
                textTransform.sizeDelta = new Vector2(textTransform.sizeDelta.x, textTransform.sizeDelta.y);
            }
            else if (anchor == Anchors.AnchorTypes.ScaleAll)
            {
                textTransform.anchorMin = Vector2.zero;
                textTransform.anchorMax = Vector2.one;
                textTransform.offsetMin = new Vector2(offset.x, offset.y);
                textTransform.offsetMax = new Vector2(-offset.z, -offset.w);
            }
            return this;
        }

        public TextUI SetSize(Scales.ScaleTypes scaleType)
        {
            if (scaleType == Scales.ScaleTypes.ExpandAll)
            {
                setAnchor(Anchors.AnchorTypes.ScaleAll);
            }
            return this;
        }
        public TextUI SetSize(Scales.ScaleTypes scaleType, Vector4 offset)
        {
            if (scaleType == Scales.ScaleTypes.ExpandAll)
            {
                setAnchor(Anchors.AnchorTypes.ScaleAll, offset);
            }
            return this;
        }
        public TextUI SetSize(Scales.ScaleTypes scaleType, Vector2 size)
        {
            if (scaleType == Scales.ScaleTypes.Default)
            {
                textTransform.sizeDelta = size;
            }
            if (scaleType == Scales.ScaleTypes.ExpandX)
            {
                setAnchor(Anchors.AnchorTypes.ScaleHorizontal);
                textTransform.sizeDelta = new Vector2(textTransform.sizeDelta.x, size.y);
            }
            if (scaleType == Scales.ScaleTypes.ExpandY)
            {
                setAnchor(Anchors.AnchorTypes.ScaleVertical);
                textTransform.sizeDelta = new Vector2(size.x, textTransform.sizeDelta.y);

            }
            return this;
        }
        public TextUI SetSize(Scales.ScaleTypes scaleType, Vector2 size, Vector4 offset)
        {
            if (scaleType == Scales.ScaleTypes.Default)
            {
                textTransform.sizeDelta = size;
            }
            if (scaleType == Scales.ScaleTypes.ExpandX)
            {
                setAnchor(Anchors.AnchorTypes.ScaleHorizontal, offset);
                textTransform.sizeDelta = new Vector2(textTransform.sizeDelta.x, size.y);
            }
            if (scaleType == Scales.ScaleTypes.ExpandY)
            {
                setAnchor(Anchors.AnchorTypes.ScaleVertical, offset);
                textTransform.sizeDelta = new Vector2(size.x, textTransform.sizeDelta.y);

            }
            return this;
        }

        public TextUI setPosition(int x, int y)
        {
            textTransform.anchoredPosition = new Vector2(x, y);
            return this;
        }

        public TextUI setText(TextData data)
        {
            textData.text = data.text;
            textData.color = data.color;
            textData.fontSize = data.size;
            textData.alignment = data.alignment;
            return this;
        }

        public TextUI setMinHeight(float height)
        {
            minHeight = height;
            return this;
        }

        public TextUI setMultiLine()
        {
            textData.textWrappingMode = TextWrappingModes.PreserveWhitespace;
            textTransform.sizeDelta = new Vector2(textTransform.sizeDelta.x, MathF.Max(textData.preferredHeight, textData.textInfo.lineCount * 26));
            textTransform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(textTransform.parent.gameObject.GetComponent<RectTransform>().sizeDelta.x, MathF.Max(textData.preferredHeight + 8, minHeight));
            LayoutRebuilder.ForceRebuildLayoutImmediate(textTransform.parent.gameObject.GetComponent<RectTransform>());
            LayoutRebuilder.ForceRebuildLayoutImmediate(textTransform);
            return this;
        }
    }
}
