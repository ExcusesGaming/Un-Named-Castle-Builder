using UnityEngine;
using UnityEngine.UI;
using System;

namespace Excuses.Libraries.UI
{

    public class UIButton
    {
        public UIImage button;
        public GameObject buttonOBJ;
        public RectTransform buttonTransform;
        public Button buttonData;

        public UIImage hover;

        public UIButton(ExcusesUIMaster uiMaster, GameObject parent, string objectName)
        {
            button = new UIImage(uiMaster, parent, objectName, true);
            buttonOBJ = button.imageOBJ;
            buttonTransform = buttonOBJ.GetComponent<RectTransform>();
            buttonOBJ.transform.SetParent(parent.transform);
            buttonData = buttonOBJ.AddComponent<Button>();
            buttonOBJ.AddComponent<UIHoverableObject>();
            buttonOBJ.GetComponent<UIHoverableObject>().onEnter += onEnter;
            buttonOBJ.GetComponent<UIHoverableObject>().onExit += onExit;
            buttonData.onClick.AddListener(delegate { onClick(); });

            hover = new UIImage(uiMaster, button.imageOBJ, objectName + " Hover", true);
            hover.imageOBJ.SetActive(false);
        }

        public UIButton setSprites(SpriteData spriteData, SpriteData spriteData1, SpriteData hoverSprite)
        {
            button.setSprites(spriteData);
            buttonData.transition = Selectable.Transition.SpriteSwap;
            SpriteState spriteState = new SpriteState();
            spriteState.pressedSprite = spriteData1.sprite;

            buttonData.spriteState = spriteState;
            hover.setSprites(hoverSprite);
            return this;
        }
        public UIButton setSize(ExcusesUIMaster.ScaleType scaleType, Vector2 size)
        {
            button.setSize(scaleType, size);
            hover.setSize(ExcusesUIMaster.ScaleType.ExpandAll, new Vector2(0, 0), new Vector4(-4, -4, -4, -4));
            return this;
        }
        public UIButton setSize(ExcusesUIMaster.ScaleType scaleType, Vector2 size, Vector4 offset)
        {
            button.setSize(scaleType, size, offset);
            hover.setSize(ExcusesUIMaster.ScaleType.ExpandAll, new Vector2(0, 0), new Vector4(-4, -4, -4, -4));
            return this;
        }
        public UIButton setPosition(int x, int y)
        {
            button.setPosition(x, y);
            return this;
        }
        public UIButton setClickFunction(Action function)
        {
            buttonData.onClick.AddListener(delegate { function(); });
            return this;
        }
        public UIButton setClickFunction<T1>(Action<T1> function, T1 input1)
        {
            buttonData.onClick.AddListener(delegate { function(input1); });
            return this;
        }
        public UIButton setClickFunction<T1, T2>(Action<T1, T2> function, T1 input1, T2 input2)
        {
            buttonData.onClick.AddListener(delegate { function(input1, input2); });
            return this;
        }
        public UIButton setClickFunction<T1, T2, T3>(Action<T1, T2, T3> function, T1 input1, T2 input2, T3 input3)
        {
            buttonData.onClick.AddListener(delegate { function(input1, input2, input3); });
            return this;
        }
        public UIButton setClickFunction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> function, T1 input1, T2 input2, T3 input3, T4 input4)
        {
            buttonData.onClick.AddListener(delegate { function(input1, input2, input3, input4); });
            return this;
        }

        public UIButton setClickFunction<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> function, T1 input1, T2 input2, T3 input3, T4 input4, T5 input5)
        {
            buttonData.onClick.AddListener(delegate { function(input1, input2, input3, input4, input5); });
            return this;
        }
        public UIButton setAnchor(Vector2 anchorPosition)
        {
            button.setAnchor(anchorPosition);
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

        internal UIButton setClickFunction(object v)
        {
            throw new NotImplementedException();
        }
    }
}
