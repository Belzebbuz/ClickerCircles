using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissPointInit : MonoBehaviour
{
    
    private void Start()
    {
        transform.position = Border.Instance.MissPoint();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.countMiss += 1;
        GameManager.Instance.lifeCount -= 1;
        GameManager.Instance.miss = true;
        ComboExit();
    }

    private void ComboExit()
    {
        if (GameManager.Instance.miss && GameManager.Instance.countCombo != 0)
        {
            GameManager.Instance.countCombo = 0;
        }
    }
}
