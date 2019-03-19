using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public static MenuUI Instance { get; private set; }
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject exitButton;
    
    [SerializeField] private GameObject levelPanel;
    
    [SerializeField] private GameObject easyModButton;
    [SerializeField] private GameObject normalModButton;
    [SerializeField] private GameObject hardModButton;
    [SerializeField] private GameObject backToMenuButton;

    [SerializeField] private GameObject readyPanel;

    [SerializeField] private Text levelText;
    [SerializeField] private Text timerText;

   
    public bool easyModOn;
    public bool normalModOn;
    public bool hardModOn;
    public bool levelMenuIn;
    public bool getReadyIn;

    private float timer;

    private void Awake()
    {
        Time.timeScale = 1;
        Instance = this;
        getReadyIn = false;
        easyModOn = false;
        normalModOn = false;
        hardModOn = false;
        timer = 3;
    }

    private void Update()
    {
        TimerStart();
        GameStart();
    }

    private void TimerStart()
    {
        if(getReadyIn)
        {
            timer -= Time.deltaTime;
            timerText.text = Mathf.Round(timer).ToString();

        }
    }

    private void GameStart()
    {
        if (timer <= 0)
        {
            SceneManager.LoadScene("Game");
        }
    }
    public void EasyMod_On()
    {
        levelPanel.SetActive(false);
        easyModOn = true;
        getReadyIn = true;
        levelText.text = "Easy mod on!";
        readyPanel.gameObject.SetActive(true);
        
    }

    public void NormalMod_On()
    {
        levelPanel.SetActive(false);
        normalModOn = true;
        getReadyIn = true;
        levelText.text = "Normal mod on!";
        readyPanel.gameObject.SetActive(true);
        
    }
    public void HardMod_On()
    {
        levelPanel.SetActive(false);
        hardModOn = true;
        getReadyIn = true;
        levelText.text = "Hard mod on!";
        readyPanel.gameObject.SetActive(true);
      
    }
    public void BackToMainMenu()
    {
        levelMenuIn = false;
        menuPanel.gameObject.SetActive(true);
        levelPanel.gameObject.SetActive(false);
    }
    public void StartGame()
    {
        levelMenuIn = true;
        menuPanel.gameObject.SetActive(false);
        levelPanel.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

  
}
