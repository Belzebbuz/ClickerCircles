using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance { get; private set; }
    [SerializeField] private Text textScore;
    [SerializeField] private Text textLife;

    [SerializeField] private GameObject pauseButton;

    [SerializeField] private GameObject pausePanel;

    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject backButton;

    [SerializeField] private Sprite pauseSprite;
    [SerializeField] private Sprite unpauseSprite;

    [SerializeField] private Text scoreUIText;
    [SerializeField] private Text winUIText;
    [SerializeField] private Text comboText;
    [SerializeField] private Text hitText;
    [SerializeField] private Text missText;

    private Image pauseImage;
   
    public bool gameOnPause;

    private bool pauseMusic;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {       
        gameOnPause = false;
        pauseImage = pauseButton.gameObject.GetComponent<Image>();        
    }

    private void Update ()
    {
        textScore.text = GameManager.Instance.score.ToString();
        textLife.text = "Lifes: " + GameManager.Instance.lifeCount.ToString();
        comboText.text = "Combo " + GameManager.Instance.countCombo.ToString() + "x";
        hitText.text = "Hit " + GameManager.Instance.countHit.ToString();
        missText.text = "Miss " + GameManager.Instance.countMiss.ToString();
        LoseGameUI();
        WinGameUI();
	}

    private void LoseGameUI()
    {
        if (GameManager.Instance._loseGame)
        {
            pausePanel.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            winUIText.text = "You lose!";
            scoreUIText.text = "Score: " + GameManager.Instance.score.ToString();
        }
    }
    private void WinGameUI()
    {
        if(GameManager.Instance._winGame)
        {
            pausePanel.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            winUIText.text = "You win!";
            scoreUIText.text = "Score: " + GameManager.Instance.score.ToString();
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");       
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Pause_Game()
    {
        if (gameOnPause == false)
        {
            pauseImage.sprite = unpauseSprite;
            gameOnPause = true;
            Time.timeScale = 0;
            pausePanel.gameObject.SetActive(true);
            scoreUIText.text = "Score: " + GameManager.Instance.score.ToString();
            GameManager.Instance.gameModAudio.Pause();
        }
        else
        {
            GameManager.Instance.gameModAudio.Play();
            pauseImage.sprite = pauseSprite;
            gameOnPause = false;
            Time.timeScale = 1;
            pausePanel.gameObject.SetActive(false);
        }
    }
   
}
