using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardHoover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool isPointerOver = false; // Fare objenin üstünde mi kontrolü için

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Fare objenin üzerine geldi: " + gameObject.name);
        isPointerOver = true;
        HoverEffect(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Fare objeden çıktı: " + gameObject.name);
        isPointerOver = false;
        HoverEffect(false);
    }

    private void HoverEffect(bool isHovering)
    {
        if (isHovering)
        {
            transform.DOScale(new Vector3(0.6f, 0.6f, 0.6f), 0.25f);
        }
        else
        {
            transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.25f);
        }
    }
}
