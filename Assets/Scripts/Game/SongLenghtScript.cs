using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SongLenghtScript : MonoBehaviour
{
    private Image songLenght;
    private void Start()
    {
        songLenght = GetComponent<Image>();
        SongLengthCircle();
    }
    private void SongLengthCircle()
    {
        songLenght.DOFillAmount(1, GameManager.Instance.gameModAudio.clip.length);
    }

}
