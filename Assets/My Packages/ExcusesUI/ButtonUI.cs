using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Excuses.UI
{
    public class ButtonUI
    {
        public GameObject buttonOBJ;
        public RectTransform buttonTransform;
        public Image buttonImage;
        public Button buttonData;
        public ButtonUI(string objectName, GameObject parent)
        {
            ImageUI image = new ImageUI(objectName, parent, true);
            buttonOBJ = image.imageOBJ;
            buttonTransform = image.imageTransform;
            buttonImage = image.image;
            buttonData = buttonOBJ.addComponent<Button>();
        }
    }
}