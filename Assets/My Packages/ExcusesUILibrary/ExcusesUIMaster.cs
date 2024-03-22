using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Excuses.Libraries.UI
{

    [System.Serializable]
    public class LayoutData
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
        public int spacing;
        public Vector2 gridSpacing;
        public Vector2 gridCellSize;

        public LayoutData(Vector4 _border)
        {
            left = (int)_border.x;
            top = (int)_border.y;
            right = (int)_border.z;
            bottom = (int)_border.w;
        }

        public LayoutData(Vector4 _border, int _spacing)
        {
            left = (int)_border.x;
            top = (int)_border.y;
            right = (int)_border.z;
            bottom = (int)_border.w;
            spacing = _spacing;
        }

        public LayoutData(Vector4 _border, Vector2 _gridSpacing, Vector2 _gridCellSize)
        {
            left = (int)_border.x;
            top = (int)_border.y;
            right = (int)_border.z;
            bottom = (int)_border.w;
            gridSpacing = _gridSpacing;
            gridCellSize = _gridCellSize;
        }
    }

    [System.Serializable]
    public class SpriteData
    {
        public Sprite sprite;
        public Color32 color;

        public SpriteData(Sprite sprite, Color32 color)
        {
            this.sprite = sprite;
            this.color = color;
        }
    }

    [System.Serializable]
    public class TextData
    {
        public string text;
        public int size;
        public Color32 color;
        public TextAlignmentOptions alignment;

        public TextData(string text, int size, Color32 color, TextAlignmentOptions alignment) 
        { 
            this.text = text;
            this.size = size;
            this.color = color;
            this.alignment = alignment;
        }
    }


    public class ExcusesUIMaster : MonoBehaviour
    {
        public static ExcusesUIMaster Instance;
        public enum ScaleType
        {
            Default,
            ExpandAll,
            ExpandX,
            ExpandY
        }
        public enum LayoutType
        {
            Normal,
            Vertical,
            Horizontal,
            Grid
        }

        public Action<int> buttonFunction1;
        public Action<string, int> buttonFunction2;
        public Action<int, int, int> buttonFunction3;

        public Sprite BackgroundSprite;
        public Sprite BackgroundReverseSprite;
        public Sprite BackgroundReverseLightSprite;
        public Sprite BorderSprite;
        public Sprite FillSprite;
        public Sprite ButtonHover;

        public void Awake()
        {
            Instance = this;
            //buttonFunction1 = _test;
            //buttonFunction2 = _test2;
            //buttonFunction3 = _test3;

            //UIBackground newBackground = new UIBackground(this, this.gameObject, "Test Background")
            //    .setSprites(new SpriteData(BackgroundSprite, new Color32(150, 150, 150, 255)))
            //    .setAnchor(new Vector2(0.5f, 0.5f))
            //    .setSize(ScaleType.Default, new Vector2(400, 100))
            //    .setPosition(0, 0)
            //    .setLayoutType(LayoutType.Vertical, new LayoutData(new Vector4(8,8,8,8), 8), TextAnchor.MiddleCenter)
            //    .setContentSize(ContentSizeFitter.FitMode.Unconstrained, ContentSizeFitter.FitMode.MinSize);

            //UIButton newButton1 = new UIButton(this, newBackground.backgroundOBJ, "Test Button 1")
            //    .setSprites(new SpriteData(BackgroundSprite, new Color32(150, 150, 150, 255)), new SpriteData(BackgroundReverseLightSprite, new Color32(150, 150, 150, 255)), new SpriteData(ButtonHover, new Color32(220, 220, 220, 255)))
            //    .setAnchor(new Vector2(0.5f, 0.5f))
            //    .setSize(ScaleType.Default, new Vector2(100, 50))
            //    .setPosition(-150, 0)
            //    .setClickFunction(buttonFunction1, 0);

            //UIButton newButton2 = new UIButton(this, newBackground.backgroundOBJ, "Test Button 2")
            //    .setSprites(new SpriteData(BackgroundSprite, new Color32(150, 150, 150, 255)), new SpriteData(BackgroundReverseLightSprite, new Color32(150, 150, 150, 255)), new SpriteData(ButtonHover, new Color32(220, 220, 220, 255)))
            //    .setAnchor(new Vector2(0.5f, 0.5f))
            //    .setSize(ScaleType.Default, new Vector2(100, 50))
            //    .setPosition(0, 0)
            //    .setClickFunction(buttonFunction2, "Bet", 1);

            //UICheckbox newCheckbox = new UICheckbox(this, newBackground.backgroundOBJ, "Test Checkbox")
            //    .setSprites(new SpriteData(BackgroundReverseSprite, new Color32(150, 150, 150, 255)), new SpriteData(BackgroundSprite, new Color32(180, 180, 180, 255)), new SpriteData(ButtonHover, new Color32(220, 220, 220, 255)))
            //    .setAnchor(new Vector2(0.5f, 0.5f))
            //    .setSize(ScaleType.Default, new Vector2(60, 60))
            //    .setPosition(0, 0);

            //UISlider newSlider = new UISlider(this, newBackground.backgroundOBJ, "Test Slider", true)
            //    .setSprites(new SpriteData(BackgroundReverseSprite, new Color32(150, 150, 150, 255)), new SpriteData(FillSprite, new Color32(255, 0, 0, 255)), new SpriteData(BorderSprite, new Color32(150, 150, 150, 255)), new SpriteData(BackgroundSprite, new Color32(150, 150, 150, 255)), new SpriteData(ButtonHover, new Color32(220, 220, 220, 255)))
            //    .setAnchor(new Vector2(0.5f, 0.5f))
            //    .setSize(ScaleType.Default, new Vector2(100, 20))
            //    .setPosition(0, 0)
            //    .setSliderValues(0, 100, 50);

            //newSlider.setInteractable(true);

            //UISlider newSlider2 = new UISlider(this, newBackground.backgroundOBJ, "Test Slider 2", false)
            //    .setSprites(new SpriteData(BackgroundReverseSprite, new Color32(150, 150, 150, 255)), new SpriteData(FillSprite, new Color32(255, 0, 0, 255)), new SpriteData(BorderSprite, new Color32(150, 150, 150, 255)), new SpriteData(BackgroundSprite, new Color32(150, 150, 150, 255)), new SpriteData(ButtonHover, new Color32(220, 220, 220, 255)))
            //    .setAnchor(new Vector2(0.5f, 0.5f))
            //    .setSize(ScaleType.Default, new Vector2(100, 20))
            //    .setPosition(0, 0)
            //    .setSliderValues(0, 100, 50);
            //newSlider2.setInteractable(false);

            //UIInputBox newInputBox = new UIInputBox(this, newBackground.backgroundOBJ, "Test Input Box")
            //    .setSprites(new SpriteData(BackgroundReverseSprite, new Color32(150, 150, 150, 255)), new SpriteData(ButtonHover, new Color32(220, 220, 220, 255)))
            //    .setAnchor(new Vector2(0.5f, 0.5f))
            //    .setSize(ScaleType.Default, new Vector2(100, 30))
            //    .setPosition(0, 0)
            //    .setText(new TextData("", 14, new Color32(0, 0, 0, 255), TextAlignmentOptions.Center), new TextData("Placeholder", 14, new Color32(40, 40, 40, 255), TextAlignmentOptions.Center))
            //    .setCharacterLimit(25);

            //UIScrollMenu newScrollMenu = new UIScrollMenu(this, newBackground.backgroundOBJ, "Test Scroll Menu")
            //    .setSprites(new SpriteData(BackgroundReverseLightSprite, new Color32(150, 150, 150, 255)), new SpriteData(BackgroundReverseSprite, new Color32(150, 150, 150, 255)), new SpriteData(BackgroundSprite, new Color32(150, 150, 150, 255)))
            //    .setAnchor(new Vector2(0.5f, 0.5f))
            //    .setSize(ScaleType.Default, new Vector2(150, 100))
            //    .setPosition(0, 0)
            //    .setContentSize(ContentSizeFitter.FitMode.Unconstrained, ContentSizeFitter.FitMode.MinSize)
            //    .setLayoutType(LayoutType.Vertical, new LayoutData(new Vector4(10,10,10,10), 10), TextAnchor.MiddleCenter)
            //    .setScrollSensitivity(30)
            //    .setScrollContraints(false, true)
            //    .setScrollType(ScrollRect.MovementType.Clamped)
            //    .setScrollbarsInvisible();

            //newScrollMenu.setNormalizedPosition();

            //UISlider newSlider3 = new UISlider(this, newScrollMenu.contentOBJ, "Test Slider", true)
            //    .setSprites(new SpriteData(BackgroundReverseSprite, new Color32(150, 150, 150, 255)), new SpriteData(FillSprite, new Color32(255, 0, 0, 255)), new SpriteData(BorderSprite, new Color32(150, 150, 150, 255)), new SpriteData(BackgroundSprite, new Color32(150, 150, 150, 255)), new SpriteData(ButtonHover, new Color32(220, 220, 220, 255)))
            //    .setAnchor(new Vector2(0.5f, 0.5f))
            //    .setSize(ScaleType.Default, new Vector2(100, 20))
            //    .setPosition(0, 0)
            //    .setSliderValues(0, 100, 50);

            //newSlider.setInteractable(true);

            //UISlider newSlider4 = new UISlider(this, newScrollMenu.contentOBJ, "Test Slider 2", false)
            //    .setSprites(new SpriteData(BackgroundReverseSprite, new Color32(150, 150, 150, 255)), new SpriteData(FillSprite, new Color32(255, 0, 0, 255)), new SpriteData(BorderSprite, new Color32(150, 150, 150, 255)), new SpriteData(BackgroundSprite, new Color32(150, 150, 150, 255)), new SpriteData(ButtonHover, new Color32(220, 220, 220, 255)))
            //    .setAnchor(new Vector2(0.5f, 0.5f))
            //    .setSize(ScaleType.Default, new Vector2(100, 20))
            //    .setPosition(0, 0)
            //    .setSliderValues(0, 100, 50);
            //newSlider4.setInteractable(false);

            //UIInputBox newInputBox2 = new UIInputBox(this, newScrollMenu.contentOBJ, "Test Input Box")
            //    .setSprites(new SpriteData(BackgroundReverseSprite, new Color32(150, 150, 150, 255)), new SpriteData(ButtonHover, new Color32(220, 220, 220, 255)))
            //    .setAnchor(new Vector2(0.5f, 0.5f))
            //    .setSize(ScaleType.Default, new Vector2(100, 30))
            //    .setPosition(0, 0)
            //    .setText(new TextData("", 14, new Color32(0, 0, 0, 255), TextAlignmentOptions.Center), new TextData("Placeholder", 14, new Color32(40, 40, 40, 255), TextAlignmentOptions.Center))
            //    .setCharacterLimit(25);

            //UIInputBox newInputBox3 = new UIInputBox(this, newScrollMenu.contentOBJ, "Test Input Box")
            //    .setSprites(new SpriteData(BackgroundReverseSprite, new Color32(150, 150, 150, 255)), new SpriteData(ButtonHover, new Color32(220, 220, 220, 255)))
            //    .setAnchor(new Vector2(0.5f, 0.5f))
            //    .setSize(ScaleType.Default, new Vector2(100, 30))
            //    .setPosition(0, 0)
            //    .setText(new TextData("", 14, new Color32(0, 0, 0, 255), TextAlignmentOptions.Center), new TextData("Placeholder", 14, new Color32(40, 40, 40, 255), TextAlignmentOptions.Center))
            //    .setCharacterLimit(25);
        }

        public void _test(int x)
        {
            Debug.Log("Test 1 " + x);
        }

        public void _test2(string x, int y)
        {
            Debug.Log("Test 2 " + x + " " + y);
        }

        public void _test3(int x, int y, int z)
        {
            Debug.Log("Test 3");
        }
    }
}
