using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomLayoutGroup : MonoBehaviour
{
    float currentChildCount;
    RectTransform rectTransform;

    public enum layoutType
    {
        Horizontal,
        Vertical,
        Grid,
        Radial
    }

    public layoutType CustomLayoutType;

    public float Spacing;

    public Vector4 Border;

    [Header("Content Size Fitter")]
    public bool FitToContent;
    public enum FitType
    {
        Unconstrained,
        FitToContent,
        StarterThenFitToContent
    }

    public FitType HorizontalFitType;
    public FitType VerticalFitType;

    public float HorizontalStartingWidth;
    public float VerticalStartingHeight;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        currentChildCount = transform.childCount;
        InvokeRepeating("UpdateLayout", 0, 0.02f);
    }

    public void LayoutUpdateCheck()
    {
        if(transform.childCount != currentChildCount)
        {
            currentChildCount = transform.childCount;
            UpdateLayout();
        }
    }

    public void UpdateLayout()
    {
        float endOfLastChild = transform.position.y;
        float endOfLastChildWidth = transform.position.x;
        float totalHeight = 0f;
        float totalWidth = 0f;
        for (int i = 0; i < transform.childCount; i++)
        {
            if(CustomLayoutType == layoutType.Vertical)
            {
                transform.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
                transform.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
                transform.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1f);
                if (i == 0)
                {
                    transform.GetChild(i).GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
                    transform.GetChild(i).GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
                    transform.GetChild(i).GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1f);
                    transform.GetChild(i).GetComponent<RectTransform>().position = new Vector3(transform.position.x, (endOfLastChild) - Border.y, 0f);
                    endOfLastChild = transform.GetChild(i).GetComponent<RectTransform>().position.y - (transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.y / 2);
                    totalHeight += transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.y;
                    
                }
                else
                {
                    transform.GetChild(i).GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
                    transform.GetChild(i).GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
                    transform.GetChild(i).GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1f);
                    transform.GetChild(i).GetComponent<RectTransform>().position = new Vector3(transform.position.x, (endOfLastChild - Spacing - (transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.y / 2)), 0f);
                    endOfLastChild = transform.GetChild(i).GetComponent<RectTransform>().position.y - (transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.y / 2);
                    totalHeight += transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.y + Spacing;
                }
            }

            else if (CustomLayoutType == layoutType.Horizontal)
            {
                transform.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
                transform.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
                transform.GetComponent<RectTransform>().pivot = new Vector2(0, 0.5f);
                if (i == 0)
                {
                    transform.GetChild(i).GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.5f);
                    transform.GetChild(i).GetComponent<RectTransform>().anchorMax = new Vector2(0, 0.5f);
                    transform.GetChild(i).GetComponent<RectTransform>().pivot = new Vector2(0, 0.5f);
                    transform.GetChild(i).GetComponent<RectTransform>().position = new Vector3((endOfLastChildWidth) + Border.x, transform.position.y, 0f);
                    endOfLastChildWidth = transform.GetChild(i).GetComponent<RectTransform>().position.x + (transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x / 2);
                    totalWidth += transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x;
                }
                else
                {
                    transform.GetChild(i).GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.5f);
                    transform.GetChild(i).GetComponent<RectTransform>().anchorMax = new Vector2(0, 0.5f);
                    transform.GetChild(i).GetComponent<RectTransform>().pivot = new Vector2(0, 0.5f);
                    transform.GetChild(i).GetComponent<RectTransform>().position = new Vector3((endOfLastChildWidth + Spacing + (transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x / 2)), transform.position.y, 0f);
                    endOfLastChildWidth = transform.GetChild(i).GetComponent<RectTransform>().position.x + (transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x / 2);
                    totalWidth += transform.GetChild(i).GetComponent<RectTransform>().sizeDelta.x + Spacing;
                }
            }
        }

        if(FitToContent)
        {
            float height = rectTransform.sizeDelta.y;
            float width = rectTransform.sizeDelta.x;
            if (VerticalFitType == FitType.FitToContent)
            {
                height = totalHeight + Border.w + Border.y;
            }
            else if (VerticalFitType == FitType.StarterThenFitToContent)
            {
                if (totalHeight + Border.w + Border.y > VerticalStartingHeight)
                {
                    height = totalHeight + Border.w + Border.y;
                }
            }

            if (HorizontalFitType == FitType.FitToContent)
            {
                width = totalWidth + Border.x + Border.z;
            }
            else if (HorizontalFitType == FitType.StarterThenFitToContent)
            {
                if (totalWidth + Border.x + Border.z > HorizontalStartingWidth)
                {
                    width = totalWidth + Border.x + Border.z;
                }
            }

            rectTransform.sizeDelta = new Vector2(width, height);
        }
    }
}
