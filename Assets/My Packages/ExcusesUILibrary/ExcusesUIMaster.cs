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
        }
    }
}
