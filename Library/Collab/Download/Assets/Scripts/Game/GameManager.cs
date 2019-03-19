using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ArrowsType { Up, Down, Left, Right };
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private CheckRing prefabCheckRing;


    [SerializeField] private AudioClip easyModMusic;
    [SerializeField] private AudioClip normalModMusic;
    [SerializeField] private AudioClip hardModMusic;
    public  AudioSource gameModAudio;


    public float speedArrow;
    public float spawnTime;
    public bool loseGame;
    public bool restartGame;
    public int score;
    public int missCount;

    private void Awake()
    {        
        SetLevel();
        Time.timeScale = 1;
        CheckRing checkRing = Instantiate(prefabCheckRing);
        checkRing.transform.position = Border.Instance.GetCheckRingPoint();
        Instance = this;
    }
    private void Start()
    {

       /* speedArrow = 3f;
        spawnTime = 3f;*/
        score = 0;
        missCount = 5;
        loseGame = false;
        restartGame = false;
    }

   
    private void Update()
    {
       
        GameOver();
    }
    private void GameOver()
    {
        if ((missCount == 0 || !gameModAudio.isPlaying) && GameUI.Instance.gameOnPause == false)
        {
            Time.timeScale = 0;
            loseGame = true;
            restartGame = true;
            gameModAudio.Stop();
        }
    }

    private void SetLevel()
    {
        
        gameModAudio = GetComponent<AudioSource>();
        try
        {
            if (MenuUI.Instance.levelMenuIn)
            {
                if (MenuUI.Instance.easyModOn)
                {
                    speedArrow = 3f;
                    spawnTime = 3f;
                    gameModAudio.clip = easyModMusic;
                    gameModAudio.Play();
                }
                else if (MenuUI.Instance.normalModOn)
                {
                    speedArrow = 4f;
                    spawnTime = 1.5f;
                    gameModAudio.clip = normalModMusic;
                    gameModAudio.Play();
                }
                else
                {
                    speedArrow = 5f;
                    spawnTime = 0.7f;
                    gameModAudio.clip = hardModMusic;
                    gameModAudio.Play();
                }
            }
        }
        
        catch
        {
            speedArrow = 3f;
            spawnTime = 3f;
        }
    }



}
