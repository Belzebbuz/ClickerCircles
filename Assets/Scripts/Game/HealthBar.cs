using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    public static HealthBar Instance { get; private set; } 
    public Image _healthBar;
    private bool startDicriment;
    private void Awake()
    {
        Instance = this;
        startDicriment = false;
    }
    void Start()
    {
        _healthBar = GetComponent<Image>();
        _healthBar.DOFillAmount(1, Border.Instance.DistanceFromSpawn()/GameManager.Instance.speedArrow);
        startDicriment = true;
    }

    private void FixedUpdate()
    {
        if (startDicriment)
            _healthBar.fillAmount -= 0.0005f;
    }

    public void AddHealth()
    {
        _healthBar.DOFillAmount(_healthBar.fillAmount + 0.1f, 0.1f);
    }

    public void MinusHealth()
    {
        _healthBar.DOFillAmount(_healthBar.fillAmount - 0.1f, 0.1f);
    }
}
