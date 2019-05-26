using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVisualise : MonoBehaviour
{
    public int band;
    public float startScale, scaleMultiplier;
    public bool useBuffer;

    private void Update()
    {
        if(useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.audioBandBuffer[band] * scaleMultiplier) + startScale, transform.localScale.z);
            
        }
        if (!useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.audioBand[band] * scaleMultiplier) + startScale, transform.localScale.z);

        }
    }
}
