using System;
using UnityEngine;
using UnityEngine.UI;

namespace Excuses.Libraries.UI
{

    public class UICheckbox
    {
        public UIImage checkbox;
        public GameObject checkboxOBJ;
        public RectTransform checkboxTransform;
        public Button checkboxData;
        public Image checkboxImage;

        public UIImage checkboxCenter;

        public UIImage hover;

        public UICheckbox(ExcusesUIMaster uiMaster, GameObject parent, string objectName, bool startingState)
        {
            checkbox = new UIImage(uiMaster, parent, objectName, true);
            checkboxOBJ = checkbox.imageOBJ;
            checkboxTransform = checkboxOBJ.GetComponent<RectTransform>();
            checkboxOBJ.transform.SetParent(parent.transform);
            checkboxData = checkboxOBJ.AddComponent<Button>();
            checkboxOBJ.AddComponent<ToggleData>();
            checkboxCenter = new UIImage(uiMaster, parent, "Center", true);
            checkboxCenter.imageTransform.SetParent(checkboxOBJ.transform);
            checkboxData.onClick.AddListener(delegate { checkboxOBJ.GetComponent<ToggleData>().ChangeActiveState(checkboxCenter); }) ;
            checkboxCenter.imageOBJ.SetActive(startingState);
            checkboxData.onClick.AddListener(delegate { onClick(); });

            checkboxOBJ.AddComponent<UIHoverableObject>();
            checkboxOBJ.GetComponent<UIHoverableObject>().onEnter += onEnter;
            checkboxOBJ.GetComponent<UIHoverableObject>().onExit += onExit;

            hover = new UIImage(uiMaster, checkboxOBJ, objectName + " Hover", true);
            hover.imageOBJ.SetActive(false);
        }

        public UICheckbox setSprites(SpriteData spriteData, SpriteData spriteData1, SpriteData hoverSprite)
        {
            checkbox.setSprites(spriteData);
            checkboxData.transition = Selectable.Transition.SpriteSwap;
            checkboxCenter.setSprites(spriteData1);
            hover.setSprites(hoverSprite);

            return this;
        }
        public UICheckbox setSize(ExcusesUIMaster.ScaleType scaleType, Vector2 size)
        {
            checkbox.setSize(scaleType, size);
            checkboxCenter.setSize(ExcusesUIMaster.ScaleType.ExpandAll, new Vector2(8, 8), new Vector4(6, 6, 6, 6));
            hover.setSize(ExcusesUIMaster.ScaleType.ExpandAll, new Vector2(0, 0), new Vector4(-4, -4, -4, -4));
            return this;
        }
        public UICheckbox setSize(ExcusesUIMaster.ScaleType scaleType, Vector2 size, Vector4 offset)
        {
            checkbox.setSize(scaleType, size, offset);
            checkboxCenter.setSize(ExcusesUIMaster.ScaleType.ExpandAll, new Vector2(8, 8), new Vector4(6, 6, 6, 6));
            hover.setSize(ExcusesUIMaster.ScaleType.ExpandAll, new Vector2(0, 0), new Vector4(-4, -4, -4, -4));
            return this;
        }
        public UICheckbox setPosition(int x, int y)
        {
            checkbox.setPosition(x, y);
            return this;
        }
        public UICheckbox setAnchor(Vector2 anchorPosition)
        {
            checkbox.setAnchor(anchorPosition);
            return this;
        }

        public UICheckbox setClickFunction(Action function)
        {
            checkboxData.onClick.AddListener(delegate { function(); });
            return this;
        }
        public UICheckbox setClickFunction<T1>(Action<T1> function, T1 input1)
        {
            checkboxData.onClick.AddListener(delegate { function(input1); });
            return this;
        }
        public UICheckbox setClickFunction<T1, T2>(Action<T1, T2> function, T1 input1, T2 input2)
        {
            checkboxData.onClick.AddListener(delegate { function(input1, input2); });
            return this;
        }
        public UICheckbox setClickFunction<T1, T2, T3>(Action<T1, T2, T3> function, T1 input1, T2 input2, T3 input3)
        {
            checkboxData.onClick.AddListener(delegate { function(input1, input2, input3); });
            return this;
        }
        public UICheckbox setClickFunction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> function, T1 input1, T2 input2, T3 input3, T4 input4)
        {
            checkboxData.onClick.AddListener(delegate { function(input1, input2, input3, input4); });
            return this;
        }

        public UICheckbox setClickFunction<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> function, T1 input1, T2 input2, T3 input3, T4 input4, T5 input5)
        {
            checkboxData.onClick.AddListener(delegate { function(input1, input2, input3, input4, input5); });
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

        public void onClick()
        {
            AudioManager.instance.PlaySFX("Button Click");
        }
    }
}
