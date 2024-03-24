using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Excuses.UI
{
    public class ImageUI
    {
        public GameObject imageOBJ;
        public RectTransform imageTransform;
        public Image image;
        public ImageUI(string objectName, GameObject parent, bool tiled)
        {
            imageOBJ = new GameObject(objectName, typeof(RectTransform));
            imageOBJ.AddComponent<ImageData>();
            imageTransform = imageOBJ.GetComponent<RectTransform>();
            imageOBJ.transform.SetParent(parent.transform);
            imageOBJ.AddComponent<Image>();
            image = imageOBJ.GetComponent<Image>();
            if (tiled)
            {
                image.type = Image.Type.Tiled;
            }

            imageOBJ.GetComponent<ImageData>().imageOBJ = imageOBJ;
            imageOBJ.GetComponent<ImageData>().imageTransform = imageTransform;
            imageOBJ.GetComponent<ImageData>().image = image;
        }
    }
}
