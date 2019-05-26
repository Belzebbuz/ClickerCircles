using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;


public class CheckRing : MonoBehaviour
{
    public static CheckRing Instance { get; private set; }

    public bool checker;

    private Color colorSwitchGreen = new Color(0.172f, 0.849f, 0.471f);
    private Color colorSwitchRed = new Color(0.858f, 0.117f, 0.117f);

    public Arrow triggerIcon { get; private set; }
    
    public SpriteRenderer colorRing;

    private void Awake()
    {
        checker = false;
        Instance = this;
    }
    private void OnValidate()
    {
        colorRing = GetComponent<SpriteRenderer>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        checker = true;
        triggerIcon = collision.gameObject.GetComponent<Arrow>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameManager.Instance.countArrow++;
        checker = false;
        triggerIcon = null;
    }
    
    public void ColorRingGreen()
    {
        colorRing.DOColor(colorSwitchGreen, 0.5f).OnComplete(() =>
        {
            colorRing.DOColor(Color.black, 0.5f);
        });
    }
    public void ColorRingRed()
    {
        colorRing.DOColor(colorSwitchRed, 0.5f).OnComplete(() =>
        {
            colorRing.DOColor(Color.black, 0.5f);
        });
    }
}
