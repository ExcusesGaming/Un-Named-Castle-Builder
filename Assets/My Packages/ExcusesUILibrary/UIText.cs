using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace Excuses.Libraries.UI
{

    public class UIText
    {
        public GameObject textOBJ;
        public RectTransform textTransform;
        public TextMeshProUGUI textData;
        public float minHeight;
        public UIText(ExcusesUIMaster uiMaster, GameObject parent, string objectName)
        {
            textOBJ = new GameObject(objectName, typeof(RectTransform));
            textOBJ.transform.SetParent(parent.transform);
            textTransform = textOBJ.GetComponent<RectTransform>();
            textData = textOBJ.AddComponent<TextMeshProUGUI>();
        }

        public UIText setSize(ExcusesUIMaster.ScaleType scaleType, Vector2 size)
        {
            if (scaleType == ExcusesUIMaster.ScaleType.Default)
            {
                textTransform.sizeDelta = size;
            }
            else if (scaleType == ExcusesUIMaster.ScaleType.ExpandAll)
            {
                textTransform.anchorMin = Vector2.zero;
                textTransform.anchorMax = Vector2.one;
                textTransform.offsetMin = Vector2.zero;
                textTransform.offsetMax = Vector2.zero;
            }
            else if (scaleType == ExcusesUIMaster.ScaleType.ExpandY)
            {
                RectTransform parentRect = textOBJ.transform.parent.GetComponent<RectTransform>();
                textTransform.anchorMin = Vector2.zero;
                textTransform.anchorMax = Vector2.one;
                textTransform.offsetMin = new Vector2(0f, parentRect.offsetMin.y);
                textTransform.offsetMax = new Vector2(0f, parentRect.offsetMax.y);
                textTransform.sizeDelta = new Vector2(size.x, textTransform.sizeDelta.y);
            }
            else if (scaleType == ExcusesUIMaster.ScaleType.ExpandX)
            {
                RectTransform parentRect = textOBJ.transform.parent.GetComponent<RectTransform>();
                textTransform.anchorMin = Vector2.zero;
                textTransform.anchorMax = Vector2.one;
                textTransform.offsetMin = new Vector2(parentRect.offsetMin.x, 0f);
                textTransform.offsetMax = new Vector2(parentRect.offsetMax.x, 0f);
                textTransform.sizeDelta = new Vector2(textTransform.sizeDelta.x, size.y);
            }
            return this;
        }

        public UIText setSize(ExcusesUIMaster.ScaleType scaleType, Vector2 size, Vector4 offset)
        {
            if (scaleType == ExcusesUIMaster.ScaleType.Default)
            {
                textTransform.sizeDelta = size;
            }
            else if (scaleType == ExcusesUIMaster.ScaleType.ExpandAll)
            {
                textTransform.anchorMin = Vector2.zero;
                textTransform.anchorMax = Vector2.one;
                textTransform.offsetMin = new Vector2(offset.x, offset.y);
                textTransform.offsetMax = new Vector2(offset.z, offset.w);
            }
            else if (scaleType == ExcusesUIMaster.ScaleType.ExpandY)
            {
                RectTransform parentRect = textOBJ.transform.parent.GetComponent<RectTransform>();
                textTransform.anchorMin = Vector2.zero;
                textTransform.anchorMax = Vector2.one;
                textTransform.offsetMin = new Vector2(0f, parentRect.offsetMin.y + offset.y);
                textTransform.offsetMax = new Vector2(0f, parentRect.offsetMax.y - offset.w);
                textTransform.sizeDelta = new Vector2(size.x, textTransform.sizeDelta.y);
            }
            else if (scaleType == ExcusesUIMaster.ScaleType.ExpandX)
            {
                RectTransform parentRect = textOBJ.transform.parent.GetComponent<RectTransform>();
                textTransform.anchorMin = Vector2.zero;
                textTransform.anchorMax = Vector2.one;
                textTransform.offsetMin = new Vector2(parentRect.offsetMin.x + offset.x, 0f);
                textTransform.offsetMax = new Vector2(parentRect.offsetMax.x - offset.z, 0f);
                textTransform.sizeDelta = new Vector2(textTransform.sizeDelta.x, size.y);
            }
            return this;
        }

        public UIText setPosition(int x, int y)
        {
            textTransform.anchoredPosition = new Vector2(x, y);
            return this;
        }

        public UIText setText(TextData data)
        {
            textData.text = data.text;
            textData.color = data.color;
            textData.fontSize = data.size;
            textData.alignment = data.alignment;
            return this;
        }

        public UIText setMinHeight(float height)
        {
            minHeight = height;
            return this;
        }

        public UIText setAnchor(Vector2 anchorPosition)
        {
            textTransform.anchorMin = anchorPosition;
            textTransform.anchorMax = anchorPosition;

            textTransform.pivot = anchorPosition;

            textTransform.anchoredPosition = new Vector2(0, 0);
            return this;
        }

        public UIText setMultiLine()
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
