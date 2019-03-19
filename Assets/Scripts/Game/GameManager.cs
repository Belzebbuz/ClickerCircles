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
    

    public AudioSource gameModAudio;
    

    public float speedArrow;
    public float spawnTime;

    public bool _loseGame;
    public bool _winGame;
    public bool _restartGame;

    public int score;
    public int lifeCount;
    public bool miss;
    public int countCombo;
    public int countMiss;
    public int countHit;

    private void Awake()
    {
        Time.timeScale = 1;
        gameModAudio = GetComponent<AudioSource>();
        SetLevel();
        CheckRingInit();
        Instance = this;
    }
    private void Start()
    {
        countMiss = 0;
        countHit = 0;
        score = 0;
        countCombo = 0;
        _loseGame = false;
        _winGame = false;
        _restartGame = false;
    }

   
    private void Update()
    {
        GameOver();
        WinGame();
    }
    private void GameOver()
    {
        if (lifeCount == 0 && GameUI.Instance.gameOnPause == false)
        {
            Time.timeScale = 0;
            _loseGame = true;
            _restartGame = true;
            gameModAudio.Stop();
        }
    }
    private void WinGame()
    {
        if(lifeCount != 0 && !gameModAudio.isPlaying && GameUI.Instance.gameOnPause == false)
        {
            Time.timeScale = 0;
            _winGame = true;
            _restartGame = true;
            Debug.Log("Победа");
            gameModAudio.Stop();
        }
    }
    private void SetLevel()
    {
        try        
        {
            SelectedLevel();
        }
        catch
        {
            speedArrow = 4f;
            spawnTime = 1.3f;
        }
    }

    private void SelectedLevel()
    {
        if (MenuUI.Instance._easyModOn)
        {
            speedArrow = 3f;
            spawnTime = 3f;
            gameModAudio.clip = easyModMusic;
            gameModAudio.Play();
        }
        else if (MenuUI.Instance._normalModOn)
        {
            speedArrow = 4f;
            spawnTime = 1.3f;
            gameModAudio.clip = normalModMusic;
            gameModAudio.Play();
        }
        else
        {
            speedArrow = 3.5f;
            spawnTime = 0.65f;
            gameModAudio.clip = hardModMusic;
            gameModAudio.Play();
        }
    }
    private void CheckRingInit()
    {
        CheckRing checkRing = Instantiate(prefabCheckRing);
        checkRing.transform.position = Border.Instance.GetCheckRingPoint();
    }

}
