using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverableObjectUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Action onEnter;
    public Action onExit;
    public void OnPointerEnter(PointerEventData eventData)
    {
        onEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onExit();
    }
}
