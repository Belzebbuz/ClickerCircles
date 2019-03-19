using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public ArrowsType arrT;
    private Color arrowColor;

    private void Awake()
    {
        //CheckRing.Instance.ringExitEvent += missPlus;
    }
    void FixedUpdate ()
    {
        moveArrow();
    }
    private void Update()
    {
        DestroyArrow();
    }
    
    private void moveArrow()
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(transform.position.x + GameManager.Instance.speedArrow, transform.position.y), Time.deltaTime);
    }
    public void ColorSwap()
    { 
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void DestroyArrow()
    {
        if (transform.position.x >= Border.Instance.GetDestroyPoint())
        {
            Destroy(gameObject);
        }
    }

    

}
