using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackgroundColor : MonoBehaviour
{
    public static BackgroundColor Instance { get; private set; }
    private Camera camera;
    private List<Color> colors = new List<Color> { new Color(0.946f, 1, 0.75f), new Color(0.8374f, 1, 0.75f), new Color(0.75f, 1, 0.77f),
        new Color(0.5f, 1, 0.844f) , new Color(0.544f, 0.9725f, 1), new Color(0.544f, 0.8157f, 1), new Color(0.544f, 0.5513f, 1),new Color(0.7684f,0.545f,1),
        new Color(1,0.545f,0.989f),new Color(1,0.545f,0.718f),new Color(1,0.545f,0.557f),new Color(1,0.7052f,0.533f) };
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
            camera.DOColor(colors[0], 1.2f);
        else if (GameManager.Instance.countCombo >= 5 && GameManager.Instance.countCombo < 8)
            camera.DOColor(colors[1], 1.2f);
        else if (GameManager.Instance.countCombo >= 8 && GameManager.Instance.countCombo < 12)
            camera.DOColor(colors[2], 1.2f);
        else if (GameManager.Instance.countCombo >= 12 && GameManager.Instance.countCombo < 15)
            camera.DOColor(colors[3], 1.2f);
        else if (GameManager.Instance.countCombo >= 15 && GameManager.Instance.countCombo < 17)
            camera.DOColor(colors[4], 1.2f);
        else if (GameManager.Instance.countCombo >= 17 && GameManager.Instance.countCombo < 20)
            camera.DOColor(colors[5], 1.2f);
        else if (GameManager.Instance.countCombo >= 20 && GameManager.Instance.countCombo < 23)
            camera.DOColor(colors[6], 1.2f);
        else if (GameManager.Instance.countCombo >= 23 && GameManager.Instance.countCombo < 25)
            camera.DOColor(colors[7], 1.2f);
        else if (GameManager.Instance.countCombo >= 25 && GameManager.Instance.countCombo < 27)
            camera.DOColor(colors[8], 1.2f);
        else if (GameManager.Instance.countCombo >= 27 && GameManager.Instance.countCombo < 30)
            camera.DOColor(colors[9], 1.2f);
        else if (GameManager.Instance.countCombo >= 30)
            camera.DOColor(colors[10], 1.2f);
    }

    public void MissBackgroundColor()
    {
        camera.DOColor(Color.white, 1f);
    }
}
