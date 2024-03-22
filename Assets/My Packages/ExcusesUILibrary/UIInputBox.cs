using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Excuses.Libraries.UI
{

    public class UIInputBox
    {
        public UIImage inputField;
        public TMP_InputField inputFieldData;

        public GameObject textAreaOBJ;
        public RectTransform textAreaRectTransform;

        public GameObject caretOBJ;
        public RectTransform caretRectTransform;

        public UIText placeholder;

        public UIText text;

        public UIImage hover;

        public string currentInput;

        public bool multiLine;
        public int startingCharacterLimit;
        public float startingHeight;
        public float minHeight;

        public UIInputBox(ExcusesUIMaster uiMaster, GameObject parent, string objectName, bool _multiLine)
        {
            inputField = new UIImage(uiMaster, parent, objectName, true);
            inputField.imageTransform.SetParent(parent.transform);
            inputFieldData = inputField.imageOBJ.AddComponent<TMP_InputField>();

            inputField.imageOBJ.AddComponent<UIHoverableObject>();
            inputField.imageOBJ.GetComponent<UIHoverableObject>().onEnter += onEnter;
            inputField.imageOBJ.GetComponent<UIHoverableObject>().onExit += onExit;

            hover = new UIImage(uiMaster, inputField.imageOBJ, objectName + " Hover", true);
            hover.imageOBJ.SetActive(false);

            textAreaOBJ = new GameObject(objectName + " Text Area", typeof(RectTransform));
            textAreaOBJ.AddComponent<RectMask2D>();
            textAreaOBJ.GetComponent<RectMask2D>().padding = new Vector4(-8, -8, -5, -5);
            textAreaRectTransform = textAreaOBJ.GetComponent<RectTransform>();
            textAreaRectTransform.SetParent(inputField.imageTransform);

            caretOBJ = new GameObject(objectName + " Caret", typeof(RectTransform));
            caretOBJ.AddComponent<TMP_SelectionCaret>();
            caretOBJ.AddComponent<LayoutElement>();
            caretRectTransform = caretOBJ.GetComponent<RectTransform>();
            caretRectTransform.SetParent(textAreaRectTransform);

            placeholder = new UIText(uiMaster, parent, objectName + " Placeholder");
            placeholder.textTransform.SetParent(textAreaRectTransform);

            text = new UIText(uiMaster, parent, objectName + " Text");
            text.textTransform.SetParent(textAreaRectTransform);

            inputFieldData.textViewport = textAreaRectTransform;
            inputFieldData.textComponent = text.textData;
            inputFieldData.placeholder = placeholder.textData;
            inputFieldData.customCaretColor = true;
            inputFieldData.caretColor = Color.gray;
            inputFieldData.caretWidth = 2;
            inputFieldData.enabled = false;
            inputFieldData.enabled = true;

            inputFieldData.onValueChanged.AddListener(GetInput);

            multiLine = _multiLine;
            if (multiLine)
            {
                text.setMultiLine();
                placeholder.setMultiLine();
                inputFieldData.lineType = TMP_InputField.LineType.MultiLineNewline;
                inputFieldData.lineLimit = 20;
                text.textData.overflowMode = TextOverflowModes.Truncate;
                text.textData.textWrappingMode = TextWrappingModes.PreserveWhitespace;

                inputFieldData.text.PadRight(1);
                inputFieldData.textComponent.lineSpacing = 0.5f;
            }
        }

        public UIInputBox setSprites(SpriteData spriteData, SpriteData hoverSprite)
        {
            inputField.setSprites(spriteData);
            hover.setSprites(hoverSprite);

            return this;
        }
        public UIInputBox setSize(ExcusesUIMaster.ScaleType scaleType, Vector2 size)
        {
            if (scaleType == ExcusesUIMaster.ScaleType.Default)
            {
                inputField.imageTransform.sizeDelta = size;
                if (multiLine)
                {
                    startingHeight = size.y;
                }
            }
            else if (scaleType == ExcusesUIMaster.ScaleType.ExpandAll)
            {
                inputField.imageTransform.anchorMin = Vector2.zero;
                inputField.imageTransform.anchorMax = Vector2.one;
                inputField.imageTransform.offsetMin = Vector2.zero;
                inputField.imageTransform.offsetMax = Vector2.zero;
            }
            else if (scaleType == ExcusesUIMaster.ScaleType.ExpandY)
            {
                RectTransform parentRect = inputField.imageOBJ.transform.parent.GetComponent<RectTransform>();
                inputField.imageTransform.anchorMin = Vector2.zero;
                inputField.imageTransform.anchorMax = Vector2.one;
                inputField.imageTransform.offsetMin = new Vector2(0f, parentRect.offsetMin.y);
                inputField.imageTransform.offsetMax = new Vector2(0f, parentRect.offsetMax.y);
                inputField.imageTransform.sizeDelta = new Vector2(size.x, inputField.imageTransform.sizeDelta.y);
            }
            else if (scaleType == ExcusesUIMaster.ScaleType.ExpandX)
            {
                RectTransform parentRect = inputField.imageOBJ.transform.parent.GetComponent<RectTransform>();
                inputField.imageTransform.anchorMin = Vector2.zero;
                inputField.imageTransform.anchorMax = Vector2.one;
                inputField.imageTransform.offsetMin = new Vector2(parentRect.offsetMin.x, 0f);
                inputField.imageTransform.offsetMax = new Vector2(parentRect.offsetMax.x, 0f);
                inputField.imageTransform.sizeDelta = new Vector2(inputField.imageTransform.sizeDelta.x, size.y);
            }

            textAreaRectTransform.anchorMin = Vector2.zero;
            textAreaRectTransform.anchorMax = Vector2.one;
            textAreaRectTransform.offsetMin = new Vector2(13, 6);
            textAreaRectTransform.offsetMax = new Vector2(-11, -6);

            caretRectTransform.anchorMin = Vector2.zero;
            caretRectTransform.anchorMax = Vector2.one;
            caretRectTransform.offsetMin = Vector2.zero;
            caretRectTransform.offsetMax = Vector2.zero;

            placeholder.textTransform.anchorMin = Vector2.zero;
            placeholder.textTransform.anchorMax = Vector2.one;
            placeholder.textTransform.offsetMin = Vector2.zero;
            placeholder.textTransform.offsetMax = Vector2.zero;

            text.textTransform.anchorMin = Vector2.zero;
            text.textTransform.anchorMax = Vector2.one;
            text.textTransform.offsetMin = Vector2.zero;
            text.textTransform.offsetMax = Vector2.zero;

            hover.setSize(ExcusesUIMaster.ScaleType.ExpandAll, new Vector2(0, 0), new Vector4(-4, -4, -4, -4));
            return this;
        }
        public UIInputBox setSize(ExcusesUIMaster.ScaleType scaleType, Vector2 size, Vector4 offset)
        {
            if (scaleType == ExcusesUIMaster.ScaleType.Default)
            {
                inputField.imageTransform.sizeDelta = size;
                if (multiLine)
                {
                    startingHeight = size.y;
                }
            }
            else if (scaleType == ExcusesUIMaster.ScaleType.ExpandAll)
            {
                inputField.imageTransform.anchorMin = Vector2.zero;
                inputField.imageTransform.anchorMax = Vector2.one;
                inputField.imageTransform.offsetMin = new Vector2(offset.x, offset.y);
                inputField.imageTransform.offsetMax = new Vector2(-offset.z, -offset.w);
            }
            else if (scaleType == ExcusesUIMaster.ScaleType.ExpandY)
            {
                RectTransform parentRect = inputField.imageOBJ.transform.parent.GetComponent<RectTransform>();
                inputField.imageTransform.anchorMin = Vector2.zero;
                inputField.imageTransform.anchorMax = Vector2.one;
                inputField.imageTransform.offsetMin = new Vector2(0f, parentRect.offsetMin.y + offset.y);
                inputField.imageTransform.offsetMax = new Vector2(0f, parentRect.offsetMax.y - offset.w);
                inputField.imageTransform.sizeDelta = new Vector2(size.x, inputField.imageTransform.sizeDelta.y);
            }
            else if (scaleType == ExcusesUIMaster.ScaleType.ExpandX)
            {
                RectTransform parentRect = inputField.imageOBJ.transform.parent.GetComponent<RectTransform>();
                inputField.imageTransform.anchorMin = Vector2.zero;
                inputField.imageTransform.anchorMax = Vector2.one;
                inputField.imageTransform.offsetMin = new Vector2(parentRect.offsetMin.x + offset.x, 0f);
                inputField.imageTransform.offsetMax = new Vector2(parentRect.offsetMax.x - offset.z, 0f);
                inputField.imageTransform.sizeDelta = new Vector2(inputField.imageTransform.sizeDelta.x, size.y);
            }

            textAreaRectTransform.anchorMin = Vector2.zero;
            textAreaRectTransform.anchorMax = Vector2.one;
            textAreaRectTransform.offsetMin = new Vector2(8, 6);
            textAreaRectTransform.offsetMax = new Vector2(-8, -6);

            caretRectTransform.anchorMin = Vector2.zero;
            caretRectTransform.anchorMax = Vector2.one;
            caretRectTransform.offsetMin = Vector2.zero;
            caretRectTransform.offsetMax = Vector2.zero;

            placeholder.textTransform.anchorMin = Vector2.zero;
            placeholder.textTransform.anchorMax = Vector2.one;
            placeholder.textTransform.offsetMin = Vector2.zero;
            placeholder.textTransform.offsetMax = Vector2.zero;

            text.textTransform.anchorMin = Vector2.zero;
            text.textTransform.anchorMax = Vector2.one;
            text.textTransform.offsetMin = Vector2.zero;
            text.textTransform.offsetMax = Vector2.zero;

            hover.setSize(ExcusesUIMaster.ScaleType.ExpandAll, new Vector2(0, 0), new Vector4(-4, -4, -4, -4));

            return this;
        }
        public UIInputBox setPosition(int x, int y)
        {
            inputField.setPosition(x, y);
            return this;
        }
        public UIInputBox setChangeValueFunction(Action function)
        {
            inputFieldData.onValueChanged.AddListener(delegate { function(); });
            return this;
        }
        public UIInputBox setChangeValueFunction<T1>(UnityAction<T1> function, T1 input1)
        {
            inputFieldData.onValueChanged.AddListener(delegate { function(input1); });
            return this;
        }
        public UIInputBox setChangeValueFunction<T1, T2>(Action<T1, T2> function, T1 input1, T2 input2)
        {
            inputFieldData.onValueChanged.AddListener(delegate { function(input1, input2); });
            return this;
        }
        public UIInputBox setChangeValueFunction<T1, T2, T3>(Action<T1, T2, T3> function, T1 input1, T2 input2, T3 input3)
        {
            inputFieldData.onValueChanged.AddListener(delegate { function(input1, input2, input3); });
            return this;
        }

        public UIInputBox setText(TextData data, TextData placeholderData)
        {
            text.setText(data);
            placeholder.setText(placeholderData);

            
            return this;
        }

        public UIInputBox setInputType(TMP_InputField.ContentType contentType)
        {
            inputFieldData.contentType = contentType;
            return this;
        }

        public UIInputBox setCharacterLimit(int limit)
        {
            inputFieldData.characterLimit = limit;
            return this;
        }

        public UIInputBox setCharacterLimit(int limit, float _minHeight)
        {
            inputFieldData.characterLimit = limit;
            minHeight = _minHeight;
            return this;
        }

        public UIInputBox setAnchor(Vector2 anchorPosition)
        {
            inputField.setAnchor(anchorPosition);
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

        public void GetInput(string arg0)
        {
            currentInput = arg0;
            SetBoxSize();
        }

        public void SetBoxSize()
        {
            inputField.imageTransform.sizeDelta = new Vector2(inputField.imageTransform.sizeDelta.x, MathF.Max(inputFieldData.preferredHeight, minHeight));
            LayoutRebuilder.ForceRebuildLayoutImmediate(inputField.imageTransform.parent.GetComponent<RectTransform>());
            LayoutRebuilder.ForceRebuildLayoutImmediate(inputField.imageTransform);
        }

        public string GetInputs()
        {
            return currentInput;
        }
    }
}
