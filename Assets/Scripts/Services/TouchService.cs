using Assets.Scripts.Interfaces;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Services
{
    public class TouchService : MonoBehaviour, ITouchService, IPointerDownHandler, IPointerUpHandler
    {
        public event Action<bool> OnTouch;

        public void OnPointerDown(PointerEventData eventData)
        {
            OnTouch?.Invoke(true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnTouch?.Invoke(false);
        }
    }
}