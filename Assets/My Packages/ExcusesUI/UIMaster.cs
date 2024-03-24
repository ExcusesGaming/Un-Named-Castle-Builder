using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Excuses.UI
{

    public class LayoutData
=======
    [System.Serializable]
    public class LayoutData
>>>>>>> cc1c53bf7eb5b55d3f2ae3017144b2cdc51da241
    {
<<<<<<< HEAD

=======
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
>>>>>>> cc1c53bf7eb5b55d3f2ae3017144b2cdc51da241
    }

<<<<<<< HEAD

    public class UIMaster : MonoBehaviour
=======
    [System.Serializable]
    public class SpriteData
>>>>>>> cc1c53bf7eb5b55d3f2ae3017144b2cdc51da241
    {
<<<<<<< HEAD
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {

        }
=======
        public Sprite sprite;
        public Color32 color;

        public SpriteData(Sprite sprite, Color32 color)
        {
            this.sprite = sprite;
            this.color = color;
        }
>>>>>>> cc1c53bf7eb5b55d3f2ae3017144b2cdc51da241
    }
<<<<<<< HEAD
=======

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
            BottomRight
        }
    }

    public class UIMaster : MonoBehaviour
    {

        public void Awake()
        {
            ImageUI newImage = new ImageUI("Test", this.gameObject, true);
        }
    }
}
>>>>>>> cc1c53bf7eb5b55d3f2ae3017144b2cdc51da241

}