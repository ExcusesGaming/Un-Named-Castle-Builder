using System;
using UnityEngine;
using UnityEngine.UI;

namespace Excuses.Libraries.UI
{

    public class UISlider
    {
        public UIImage slider;
        public GameObject sliderOBJ;
        public RectTransform sliderTransform;
        public Slider sliderData;

        public GameObject fillAreaOBJ;
        public RectTransform fillAreaTransform;

        public UIImage fill;

        public UIImage border;

        public GameObject handleAreaOBJ;
        public RectTransform handleAreaTransform;

        public UIImage handle;

        public UIImage hover;

        public UISlider(ExcusesUIMaster uiMaster, GameObject parent, string objectName, bool hoverable)
        {
            slider = new UIImage(uiMaster, parent, objectName, true);
            sliderOBJ = slider.imageOBJ;
            sliderTransform = sliderOBJ.GetComponent<RectTransform>();
            sliderOBJ.transform.SetParent(parent.transform);
            sliderData = sliderOBJ.AddComponent<Slider>();

            fillAreaOBJ = new GameObject(objectName + " Fill Area", typeof(RectTransform));
            fillAreaTransform = fillAreaOBJ.GetComponent<RectTransform>();
            fillAreaTransform.SetParent(sliderTransform);

            fill = new UIImage(uiMaster, parent, objectName + " Fill", true);
            fill.imageTransform.SetParent(fillAreaTransform);

            border = new UIImage(uiMaster, parent, objectName + " Border", true);
            border.imageTransform.SetParent(sliderTransform);

            handleAreaOBJ = new GameObject(objectName + " Handle Area", typeof(RectTransform));
            handleAreaTransform = handleAreaOBJ.GetComponent<RectTransform>();
            handleAreaTransform.SetParent(sliderTransform);

            handle = new UIImage(uiMaster, parent, objectName + " Handle", true);
            handle.imageTransform.SetParent(handleAreaTransform);

            sliderData.fillRect = fill.imageTransform;
            sliderData.handleRect = handle.imageTransform;
            
            sliderData.transition = Selectable.Transition.None;


            if (hoverable)
            {
                sliderOBJ.AddComponent<UIHoverableObject>();
                sliderOBJ.GetComponent<UIHoverableObject>().onEnter += onEnter;
                sliderOBJ.GetComponent<UIHoverableObject>().onExit += onExit;
                hover = new UIImage(uiMaster, slider.imageOBJ, objectName + " Hover", true);
                hover.imageOBJ.SetActive(false);
            }
        }

        public UISlider setSprites(SpriteData spriteData, SpriteData spriteData1, SpriteData spriteData2, SpriteData spriteData3, SpriteData hoverSprite)
        {
            slider.setSprites(spriteData);
            fill.setSprites(spriteData1);
            border.setSprites(spriteData2);
            handle.setSprites(spriteData3);
            if (hover != null)
            {
                hover.setSprites(hoverSprite);
            }

            return this;
        }
        public UISlider setSize(ExcusesUIMaster.ScaleType scaleType, Vector2 size)
        {
            slider.setSize(scaleType, size);

            fillAreaTransform.anchorMin = Vector2.zero;
            fillAreaTransform.anchorMax = Vector2.one;
            fillAreaTransform.offsetMin = new Vector2(4, 2f);
            fillAreaTransform.offsetMax = new Vector2(-4, -2f);

            fill.imageTransform.anchorMin = Vector2.zero;
            fill.imageTransform.anchorMax = Vector2.one;
            fill.imageTransform.offsetMin = Vector2.zero;
            fill.imageTransform.offsetMax = Vector2.zero;

            border.imageTransform.anchorMin = Vector2.zero;
            border.imageTransform.anchorMax = Vector2.one;
            border.imageTransform.offsetMin = Vector2.zero;
            border.imageTransform.offsetMax = Vector2.zero;

            handleAreaTransform.anchorMin = Vector2.zero;
            handleAreaTransform.anchorMax = Vector2.one;
            handleAreaTransform.offsetMin = new Vector2(10, 0);
            handleAreaTransform.offsetMax = new Vector2(-10, 0);

            handle.imageTransform.anchorMin = Vector2.zero;
            handle.imageTransform.anchorMax = Vector2.one;
            handle.imageTransform.offsetMin = new Vector2(0, handleAreaTransform.offsetMin.y);
            handle.imageTransform.offsetMax = new Vector2(0, handleAreaTransform.offsetMax.y);
            handle.imageTransform.sizeDelta = new Vector2(size.y, handleAreaTransform.sizeDelta.y);

            if (hover != null)
            {
                hover.setSize(ExcusesUIMaster.ScaleType.ExpandAll, new Vector2(0, 0), new Vector4(-4, -4, -4, -4));
            }

            return this;
        }
        public UISlider setSize(ExcusesUIMaster.ScaleType scaleType, Vector2 size, Vector4 offset)
        {
            slider.setSize(scaleType, size, offset);

            fillAreaTransform.anchorMin = Vector2.zero;
            fillAreaTransform.anchorMax = Vector2.one;
            fillAreaTransform.offsetMin = new Vector2(4, 2f);
            fillAreaTransform.offsetMax = new Vector2(-4, -2f);

            fill.imageTransform.anchorMin = Vector2.zero;
            fill.imageTransform.anchorMax = Vector2.one;
            fill.imageTransform.offsetMin = Vector2.zero;
            fill.imageTransform.offsetMax = Vector2.zero;

            border.imageTransform.anchorMin = Vector2.zero;
            border.imageTransform.anchorMax = Vector2.one;
            border.imageTransform.offsetMin = Vector2.zero;
            border.imageTransform.offsetMax = Vector2.zero;

            handleAreaTransform.anchorMin = Vector2.zero;
            handleAreaTransform.anchorMax = Vector2.one;
            handleAreaTransform.offsetMin = new Vector2(10, 0);
            handleAreaTransform.offsetMax = new Vector2(-10, 0);

            handle.imageTransform.anchorMin = Vector2.zero;
            handle.imageTransform.anchorMax = Vector2.one;
            handle.imageTransform.offsetMin = new Vector2(0, handleAreaTransform.offsetMin.y);
            handle.imageTransform.offsetMax = new Vector2(0, handleAreaTransform.offsetMax.y);
            handle.imageTransform.sizeDelta = new Vector2(size.y, handleAreaTransform.sizeDelta.y);

            if (hover != null)
            {
                hover.setSize(ExcusesUIMaster.ScaleType.ExpandAll, new Vector2(0, 0), new Vector4(-4, -4, -4, -4));
            }
            return this;
        }
        public UISlider setPosition(int x, int y)
        {
            slider.setPosition(x, y);
            return this;
        }
        public UISlider setAnchor(Vector2 anchorPosition)
        {
            slider.setAnchor(anchorPosition);
            return this;
        }

        public UISlider setSliderValues(float min, float max, float current)
        {
            sliderData.minValue = min;
            sliderData.maxValue = max;
            sliderData.value = current;
            return this;
        }

        public UISlider useWholeNumbers(bool useWholeNumbers)
        {
            sliderData.wholeNumbers = useWholeNumbers;
            return this;
        }

        public UISlider setOrientation(Slider.Direction sliderDirection)
        {
            sliderData.direction = sliderDirection;
            return this;
        }

        public UISlider setChangeValueFunction(Action function)
        {
            sliderData.onValueChanged.AddListener(delegate { function(); });
            return this;
        }
        public UISlider setChangeValueFunction<T1>(Action<T1> function, T1 input1)
        {
            sliderData.onValueChanged.AddListener(delegate { function(input1); });
            return this;
        }
        public UISlider setChangeValueFunction<T1, T2>(Action<T1, T2> function, T1 input1, T2 input2)
        {
            sliderData.onValueChanged.AddListener(delegate { function(input1, input2); });
            return this;
        }
        public UISlider setChangeValueFunction<T1, T2, T3>(Action<T1, T2, T3> function, T1 input1, T2 input2, T3 input3)
        {
            sliderData.onValueChanged.AddListener(delegate { function(input1, input2, input3); });
            return this;
        }

        public UISlider setInteractable(bool interactable)
        {
            sliderData.interactable = interactable;
            if (!interactable)
            {
                handle.imageOBJ.SetActive(false);
            }
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
    }
}
