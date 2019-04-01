using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackgroundColor : MonoBehaviour
{
    public static BackgroundColor Instance { get; private set; }
    private Camera camera;
    private Color _1Back = new Color(0.946f, 1,0.75f);
    private Color _2Back = new Color(0.8374f, 1,0.75f);
    private Color _3Back = new Color(0.75f,1,0.77f);
    private Color _4Back = new Color(0.5f,1,0.844f);
    private Color _5Back = new Color(0.544f,0.9725f,1);
    private Color _6Back = new Color(0.544f,0.8157f,1);
    private Color _7Back = new Color(0.544f, 0.5513f,1);
    private Color _8Back = new Color(0.7684f,0.545f,1);
    private Color _9Back = new Color(1,0.545f,0.989f);
    private Color _10Back = new Color(1,0.545f,0.718f);
    private Color _11Back = new Color(1,0.545f,0.557f);
    private Color _12Back = new Color(1,0.7052f,0.533f);
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        camera = GetComponent<Camera>();
    }

   
    public void BackgroundColorSwitch()
    {
        if (GameManager.Instance.countCombo >= 0 && GameManager.Instance.countCombo < 2)
            camera.backgroundColor = Color.white;
        if (GameManager.Instance.countCombo >= 2 && GameManager.Instance.countCombo < 5)
            camera.DOColor(_1Back, 1.2f);
        else if (GameManager.Instance.countCombo >= 5 && GameManager.Instance.countCombo < 8)
            camera.DOColor(_2Back, 1.2f);
        else if (GameManager.Instance.countCombo >= 8 && GameManager.Instance.countCombo < 12)
            camera.DOColor(_3Back, 1.2f);
        else if (GameManager.Instance.countCombo >= 12 && GameManager.Instance.countCombo < 15)
            camera.DOColor(_4Back, 1.2f);
        else if (GameManager.Instance.countCombo >= 15 && GameManager.Instance.countCombo < 17)
            camera.DOColor(_5Back, 1.2f);
        else if (GameManager.Instance.countCombo >= 17 && GameManager.Instance.countCombo < 20)
            camera.DOColor(_6Back, 1.2f);
        else if (GameManager.Instance.countCombo >= 20 && GameManager.Instance.countCombo < 23)
            camera.DOColor(_7Back, 1.2f);
        else if (GameManager.Instance.countCombo >= 23 && GameManager.Instance.countCombo < 25)
            camera.DOColor(_9Back, 1.2f);
        else if (GameManager.Instance.countCombo >= 25 && GameManager.Instance.countCombo < 27)
            camera.DOColor(_10Back, 1.2f);
        else if (GameManager.Instance.countCombo >= 27 && GameManager.Instance.countCombo < 30)
            camera.DOColor(_11Back, 1.2f);
        else if (GameManager.Instance.countCombo >= 30)
            camera.DOColor(_12Back, 1.2f);
    }

    public void MissBackgroundColor()
    {
        camera.DOColor(Color.white, 1f);
    }
}
