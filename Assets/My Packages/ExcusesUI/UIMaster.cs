using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Excuses.UI
{

    [System.Serializable]
    public class LayoutData
    {
        public Vector4 Border;
        public float Spacing;
        public Vector2 GridSpacing;
        public Vector2 GridCellSize;

        public LayoutData(Vector4 _border)
        {
            Border = _border;
        }

        public LayoutData(Vector4 _border, float _spacing)
        {
            Border = _border;
            Spacing = _spacing;
        }

        public LayoutData(Vector4 _border, Vector2 _gridSpacing, Vector2 _gridCellSize)
        {
            Border = _border;
            GridSpacing = _gridSpacing;
            GridCellSize = _gridCellSize;
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

    [System.Serializable]
    public class Anchors
    {
        public enum AnchorTypes
        {
            Center,
            TopMiddle,
            TopLeft,
            TopRight,
            CenterLeft,
            CenterRight,
            BottomMiddle,
            BottomLeft,
            BottomRight,
            ScaleHorizontal,
            ScaleVertical,
            ScaleAll
        }
    }

    [System.Serializable]
    public class Scales 
    {
        public enum ScaleTypes
        {
            Default,
            ExpandAll,
            ExpandX,
            ExpandY
        }
    }

    public class UIMaster : MonoBehaviour
    {

        public void Awake()
        {
            ImageUI newImage = new ImageUI("Test", this.gameObject, true)
                .setSprites(new SpriteData(SpriteDatabase.instance.BackgroundSprite, new Color32(100, 100, 100, 100)))
                .setAnchor(Anchors.AnchorTypes.CenterLeft)
                .SetSize(Scales.ScaleTypes.Default, new Vector2(100,50))
                .setPosition(100, 0);
        }
    }
}