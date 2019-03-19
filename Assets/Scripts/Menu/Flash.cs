using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    [SerializeField] private Text gameName;
    [SerializeField] private Text menuLevel;
    [SerializeField] private Text levelTextLevelMenu;
    [SerializeField] private Text GetReady;
    [SerializeField] private Text levelGetready;
    private void Update()
    {
        gameName.color = new Color(gameName.color.r, gameName.color.g, gameName.color.b, Mathf.PingPong(Time.time/2.5f,1f));
        menuLevel.color = new Color(menuLevel.color.r, menuLevel.color.g, menuLevel.color.b, Mathf.PingPong(Time.time/2.5f,1f));
        levelTextLevelMenu.color = new Color(levelTextLevelMenu.color.r, levelTextLevelMenu.color.g, levelTextLevelMenu.color.b, Mathf.PingPong(Time.time/2.5f,1f));
        GetReady.color = new Color(GetReady.color.r, GetReady.color.g, GetReady.color.b, Mathf.PingPong(Time.time/2.5f,1f));
        levelGetready.color = new Color(levelGetready.color.r, levelGetready.color.g, levelGetready.color.b, Mathf.PingPong(Time.time/2.5f,1f));
    }
        
}
