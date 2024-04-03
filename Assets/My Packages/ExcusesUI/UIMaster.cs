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

        public void Start()
        {
            ImageUI newImage = new ImageUI("Test", this.gameObject, true)
                .setSprites(new SpriteData(SpriteDatabase.instance.BackgroundSprite, new Color32(100, 100, 100, 200)))
                .setAnchor(Anchors.AnchorTypes.CenterLeft)
                .SetSize(Scales.ScaleTypes.Default, new Vector2(100,50))
                .setPosition(100, 0);

            ButtonUI newButton = new ButtonUI("Button", this.gameObject)
                .setSprites(new SpriteData(SpriteDatabase.instance.BackgroundSprite, new Color32(150, 150, 150, 200)), new SpriteData(SpriteDatabase.instance.ReverseBackgroundSprite, new Color32(150, 150, 150, 200)), new SpriteData(SpriteDatabase.instance.HoverSprite, new Color32(220, 220, 220, 200)))
                .setAnchor(Anchors.AnchorTypes.CenterLeft)
                .SetSize(Scales.ScaleTypes.Default, new Vector2(200, 50))
                .setPosition(150, 100)
                .addText(new TextData("Testing", 24, new Color32(0,0,0,255), TextAlignmentOptions.Left), new Vector4(10,10,10,10));

            ButtonUI newButton2 = new ButtonUI("Button2", this.gameObject)
                .setSprites(new SpriteData(SpriteDatabase.instance.BackgroundSprite, new Color32(150, 150, 150, 200)), new SpriteData(SpriteDatabase.instance.ReverseBackgroundSprite, new Color32(150, 150, 150, 200)), new SpriteData(SpriteDatabase.instance.HoverSprite, new Color32(220, 220, 220, 200)))
                .setAnchor(Anchors.AnchorTypes.CenterLeft)
                .SetSize(Scales.ScaleTypes.Default, new Vector2(200, 50))
                .setPosition(150, 250)
                .addIcon(new SpriteData(SpriteDatabase.instance.icon, new Color32(255, 255, 255, 200)), new Vector4(84,10,84,10), false);
        }
    }
}