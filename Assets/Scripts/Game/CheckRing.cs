using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CheckRing : MonoBehaviour
{
    public static CheckRing Instance { get; private set; }

    public bool checker;

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

        checker = false;
        triggerIcon = null;
    }

}
