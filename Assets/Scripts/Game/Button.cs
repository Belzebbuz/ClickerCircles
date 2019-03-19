using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ArrowsType arrowType;
    private void CheckZone()
    {
        if (CheckRing.Instance.checker && arrowType == CheckRing.Instance.triggerIcon.arrT)
        {
            CheckRing.Instance.colorRing.color = new Color(0.172f, 0.849f, 0.471f);
            StartCoroutine(Wait());
            Destroy(CheckRing.Instance.triggerIcon.gameObject);
            GameManager.Instance.countHit += 1;
            GameManager.Instance.countCombo++;
            GameManager.Instance.score += 10 * GameManager.Instance.countCombo;
        }
        else
        {
            GameManager.Instance.countCombo = 0;
        }
    }

    private void Update()
    {
        if (CheckRing.Instance.checker && arrowType == CheckRing.Instance.triggerIcon.arrT)
            GameManager.Instance.miss = false;
       
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        CheckZone();
        Vibration.Vibrate(30);
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.12f);
        CheckRing.Instance.colorRing.color = Color.black;
    }
   
 

}
