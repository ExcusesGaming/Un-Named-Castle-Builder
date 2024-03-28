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
        public ImageUI setSprites(SpriteData spriteData){
            image.sprite = spriteData.sprite;
            image.color = spriteData.color;
            return this;
        }

        public ImageUI setAnchor(Anchors.AnchorTypes anchor)
        {
            if(anchor == Anchors.AnchorTypes.Center){
                imageTransform.anchorMin = new Vector2(0.5f, 0.5f);
                imageTransform.anchorMax = new Vector2(0.5f, 0.5f);
            }
            else if(anchor == Anchors.AnchorTypes.TopMiddle){
                imageTransform.anchorMin = new Vector2(0.5f, 1f);
                imageTransform.anchorMax = new Vector2(0.5f, 1f);
            }
            else if(anchor == Anchors.AnchorTypes.TopLeft){
                imageTransform.anchorMin = new Vector2(0f, 1f);
                imageTransform.anchorMax = new Vector2(0f, 1f);
            }
            else if(anchor == Anchors.AnchorTypes.TopRight){
                imageTransform.anchorMin = new Vector2(1f, 1f);
                imageTransform.anchorMax = new Vector2(1f, 1f);
            }
            else if(anchor == Anchors.AnchorTypes.BottomMiddle){
                imageTransform.anchorMin = new Vector2(0.5f, 0f);
                imageTransform.anchorMax = new Vector2(0.5f, 0f);
            }
            else if(anchor == Anchors.AnchorTypes.BottomLeft){
                imageTransform.anchorMin = new Vector2(0f, 0f);
                imageTransform.anchorMax = new Vector2(0f, 0f);
            }
            else if(anchor == Anchors.AnchorTypes.BottomRight){
                imageTransform.anchorMin = new Vector2(1f, 0f);
                imageTransform.anchorMax = new Vector2(1f, 0f);
            }
            else if(anchor == Anchors.AnchorTypes.CenterLeft){
                imageTransform.anchorMin = new Vector2(0f, 0.5f);
                imageTransform.anchorMax = new Vector2(0f, 0.5f);
            }
            else if(anchor == Anchors.AnchorTypes.CenterRight){
                imageTransform.anchorMin = new Vector2(1f, 0.5f);
                imageTransform.anchorMax = new Vector2(1f, 0.5f);
            }
            else if(anchor == Anchors.AnchorTypes.ScaleHorizontal){
                RectTransform parentRect = imageOBJ.transform.parent.GetComponent<RectTransform>();
                imageTransform.anchorMin = Vector2.zero;
                imageTransform.anchorMax = Vector2.one;
                imageTransform.offsetMin = new Vector2(parentRect.offsetMin.x, 0f);
                imageTransform.offsetMax = new Vector2(parentRect.offsetMax.x, 0f);
                imageTransform.sizeDelta = new Vector2(imageTransform.sizeDelta.x, imageTransform.sizeDelta.y);
            }
            else if(anchor == Anchors.AnchorTypes.ScaleVertical){
                RectTransform parentRect = imageOBJ.transform.parent.GetComponent<RectTransform>();
                imageTransform.anchorMin = Vector2.zero;
                imageTransform.anchorMax = Vector2.one;
                imageTransform.offsetMin = new Vector2(0f, parentRect.offsetMin.y);
                imageTransform.offsetMax = new Vector2(0f, parentRect.offsetMax.y);
                imageTransform.sizeDelta = new Vector2(imageTransform.sizeDelta.x, imageTransform.sizeDelta.y);
            }
            else if(anchor == Anchors.AnchorTypes.ScaleAll){
                imageTransform.anchorMin = Vector2.zero;
                imageTransform.anchorMax = Vector2.one;
                imageTransform.offsetMin = Vector2.zero;
                imageTransform.offsetMax = Vector2.zero;
            }
            return this;
        }

        public ImageUI setAnchor(Anchors.AnchorTypes anchor, Vector4 offset)
        {
            if(anchor == Anchors.AnchorTypes.Center){
                imageTransform.anchorMin = new Vector2(0.5f, 0.5f);
                imageTransform.anchorMax = new Vector2(0.5f, 0.5f);
            }
            else if(anchor == Anchors.AnchorTypes.TopMiddle)
            {
                imageTransform.anchorMin = new Vector2(0.5f, 1f);
                imageTransform.anchorMax = new Vector2(0.5f, 1f);
            }
            else if(anchor == Anchors.AnchorTypes.TopLeft)
            {
                imageTransform.anchorMin = new Vector2(0f, 1f);
                imageTransform.anchorMax = new Vector2(0f, 1f);
            }
            else if(anchor == Anchors.AnchorTypes.TopRight)
            {
                imageTransform.anchorMin = new Vector2(1f, 1f);
                imageTransform.anchorMax = new Vector2(1f, 1f);
            }
            else if(anchor == Anchors.AnchorTypes.BottomMiddle)
            {
                imageTransform.anchorMin = new Vector2(0.5f, 0f);
                imageTransform.anchorMax = new Vector2(0.5f, 0f);
            }
            else if(anchor == Anchors.AnchorTypes.BottomLeft)
            {
                imageTransform.anchorMin = new Vector2(0f, 0f);
                imageTransform.anchorMax = new Vector2(0f, 0f);
            }
            else if(anchor == Anchors.AnchorTypes.BottomRight)
            {
                imageTransform.anchorMin = new Vector2(1f, 0f);
                imageTransform.anchorMax = new Vector2(1f, 0f);
            }
            else if(anchor == Anchors.AnchorTypes.CenterLeft)
            {
                imageTransform.anchorMin = new Vector2(0f, 0.5f);
                imageTransform.anchorMax = new Vector2(0f, 0.5f);
            }
            else if(anchor == Anchors.AnchorTypes.CenterRight)
            {
                imageTransform.anchorMin = new Vector2(1f, 0.5f);
                imageTransform.anchorMax = new Vector2(1f, 0.5f);
            }
            else if(anchor == Anchors.AnchorTypes.ScaleHorizontal)
            {
                RectTransform parentRect = imageOBJ.transform.parent.GetComponent<RectTransform>();
                imageTransform.anchorMin = Vector2.zero;
                imageTransform.anchorMax = Vector2.one;
                imageTransform.offsetMin = new Vector2(parentRect.offsetMin.x + offset.x, 0f);
                imageTransform.offsetMax = new Vector2(parentRect.offsetMax.x - offset.z, 0f);
                imageTransform.sizeDelta = new Vector2(imageTransform.sizeDelta.x, imageTransform.sizeDelta.y);
            }
            else if(anchor == Anchors.AnchorTypes.ScaleVertical)
            {
                RectTransform parentRect = imageOBJ.transform.parent.GetComponent<RectTransform>();
                imageTransform.anchorMin = Vector2.zero;
                imageTransform.anchorMax = Vector2.one;
                imageTransform.offsetMin = new Vector2(0f, parentRect.offsetMin.y + offset.y);
                imageTransform.offsetMax = new Vector2(0f, parentRect.offsetMax.y - offset.w);
                imageTransform.sizeDelta = new Vector2(imageTransform.sizeDelta.x, imageTransform.sizeDelta.y);
            }
            else if(anchor == Anchors.AnchorTypes.ScaleAll)
            {
                imageTransform.anchorMin = Vector2.zero;
                imageTransform.anchorMax = Vector2.one;
                imageTransform.offsetMin = new Vector2(offset.x, offset.y);
                imageTransform.offsetMax = new Vector2(-offset.z, -offset.w);
            }
            return this;
        }    

        public ImageUI SetSize(Scales.ScaleTypes scaleType)
        {
            if(scaleType == Scales.ScaleTypes.ExpandAll)
            {
                setAnchor(Anchors.AnchorTypes.ScaleAll);
            }
            return this;
        }
        public ImageUI SetSize(Scales.ScaleTypes scaleType, Vector4 offset)
        {
            if (scaleType == Scales.ScaleTypes.ExpandAll)
            {
                setAnchor(Anchors.AnchorTypes.ScaleAll, offset);
            }
            return this;
        }
        public ImageUI SetSize(Scales.ScaleTypes scaleType, Vector2 size)
        {
            if(scaleType == Scales.ScaleTypes.Default)
            {
                imageTransform.sizeDelta = size;
            }
            if(scaleType == Scales.ScaleTypes.ExpandX)
            {
                setAnchor(Anchors.AnchorTypes.ScaleHorizontal);
                imageTransform.sizeDelta = new Vector2(imageTransform.sizeDelta.x, size.y);
            }
            if(scaleType == Scales.ScaleTypes.ExpandY)
            {
                setAnchor(Anchors.AnchorTypes.ScaleVertical);
                imageTransform.sizeDelta = new Vector2(size.x, imageTransform.sizeDelta.y);
            
            }
            return this;
        }
        public ImageUI SetSize(Scales.ScaleTypes scaleType, Vector2 size, Vector4 offset)
        {
            if (scaleType == Scales.ScaleTypes.Default)
            {
                imageTransform.sizeDelta = size;
            }
            if (scaleType == Scales.ScaleTypes.ExpandX)
            {
                setAnchor(Anchors.AnchorTypes.ScaleHorizontal, offset);
                imageTransform.sizeDelta = new Vector2(imageTransform.sizeDelta.x, size.y);
            }
            if (scaleType == Scales.ScaleTypes.ExpandY)
            {
                setAnchor(Anchors.AnchorTypes.ScaleVertical, offset);
                imageTransform.sizeDelta = new Vector2(size.x, imageTransform.sizeDelta.y);

            }
            return this;
        }

        public ImageUI setPosition(int x, int y)
        {
            imageTransform.anchoredPosition = new Vector2(x, y);
            return this;
        }
    }
}
