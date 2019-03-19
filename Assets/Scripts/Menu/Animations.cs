using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Animations : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
