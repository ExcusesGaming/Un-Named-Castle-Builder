using System;
using UnityEngine;
using UnityEngine.EventSystems;
namespace Excuses.Libraries.UI
{

    public class UIHoverableObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
}
