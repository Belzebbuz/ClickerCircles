using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ArrowsType { Up, Down, Left, Right };
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private CheckRing prefabCheckRing;
    [SerializeField] private GameObject prefabBands;


    [SerializeField] private AudioClip easyModMusic;
    [SerializeField] private AudioClip normalModMusic;
    [SerializeField] private AudioClip hardModMusic;


    public AudioSource gameModAudio;

    public float speedArrow;
    public float spawnTime;

    public string grade;

    public bool _loseGame;
    public bool _winGame;
    public bool _restartGame;
    public Text scoreUIText;
    public float ScoreAnimationTime;
    public int score;
    public int lifeCount;
    public bool miss;
    public int countCombo;
    public int countMiss;
    public int countHit;
    public int maxCountLife;
    public int countArrow;
    public float hitCountRate;

    private void Awake()
    {
        Time.timeScale = 1;
        gameModAudio = GetComponent<AudioSource>();
        SetLevel();
        CheckRingInit();
        BandsInit();
        Instance = this;
    }
    private void Start()
    {
        AddScore(0);
        maxCountLife = lifeCount;
        countMiss = 0;
        countHit = 0;
        hitCountRate = 100;
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
        if (HealthBar.Instance._healthBar.fillAmount <= 0 && GameUI.Instance.gameOnPause == false)
        {
            Time.timeScale = 0;
            _loseGame = true;
            _restartGame = true;
            gameModAudio.Stop();
        }
    }
    private void WinGame()
    {
        if(HealthBar.Instance._healthBar.fillAmount != 0 && !gameModAudio.isPlaying && GameUI.Instance.gameOnPause == false)
        {
            Time.timeScale = 0;
            _winGame = true;
            _restartGame = true;
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
            spawnTime = 0.6123f;
            speedArrow = Border.Instance.DistanceFromSpawn() / (spawnTime * 1.5f);
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
            speedArrow = 2.61f;
            spawnTime = 0.7317f;
            gameModAudio.clip = normalModMusic;
            gameModAudio.Play();
        }
        else
        {
            spawnTime = 0.6123f;
            speedArrow = Border.Instance.DistanceFromSpawn() / (spawnTime * 1.5f);
            gameModAudio.clip = hardModMusic;
            gameModAudio.Play();
        }
    }
    private void CheckRingInit()
    {
        CheckRing checkRing = Instantiate(prefabCheckRing);
        checkRing.transform.position = Border.Instance.GetCheckRingPoint();
    }
    private void BandsInit()
    {
        Instantiate(prefabBands).transform.position = Border.Instance.BandPoint();
    }

    public void AddScore(int value)
    {
        score += value;
        var animTime = ScoreAnimationTime / 2f;
        float deltaTime = 0f;
        if (value > 0)
        {
            scoreUIText.transform.DOScale(1.2f, animTime).OnUpdate(() =>
            {
                deltaTime += Time.deltaTime;
                var newTime = (int)(value * (1 - deltaTime / animTime));
                SetTxt(score - value + (value - newTime), scoreUIText);
            }).OnComplete(() =>
            {
                scoreUIText.transform.DOScale(1f, animTime / 2f);
            });
        }
        else
        {
            scoreUIText.text = score.ToString();
        }
        
    }
    public void SetTxt(int value, Text txt, string prefix = "")
    {
        txt.text = string.Format("{0}{1}", prefix, value);
    }

    public void Grade()
    {
        if (hitCountRate == 100)
            grade = "SS";
        else if (hitCountRate <= 100 && hitCountRate >= 95)
            grade = "S";
        else if (hitCountRate <= 95 && hitCountRate >= 90)
            grade = "A";
        else if (hitCountRate <= 90 && hitCountRate >= 85)
            grade = "B";
        else if (hitCountRate <= 85 && hitCountRate >= 80)
            grade = "C";
        else if (hitCountRate <= 80)
            grade = "D";
    }


}
