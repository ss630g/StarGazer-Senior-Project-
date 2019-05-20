using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

    public playerController pc;
    [SerializeField] int playerDeaths = 0;
    [SerializeField] Text deathText;
    [SerializeField] Text timerText;
    [SerializeField] float startTime;
     public float t;
     int currentSceneIndex = 0;
     int oldSceneIndex = -1;
     public bool loadpressed = false;
     public DeathCount dc;
     //public PauseMenuInGame pmig;
     //public PauseMenuInGame pmig;

    private void Awake()
    {
        DuplicateGameSessionCheck();
    }

    // Use this for initialization
    void Start () 
    { 
        if(SceneManager.GetActiveScene().buildIndex == 0){
            Destroy(gameObject);
        }
        //  Debug.Log(SceneManager.GetActiveScene().buildIndex)
        //dc.stoppedTime = dc.totalTime;
        dc.LoadDeaths();
        startTime = Time.time - dc.totalTime;
        CurrentLocation();
        //dc.LoadDeaths();
        //Debug.Log("dc.StoppedTime: " + dc.StoppedTime);
        //startTime = Time.time - dc.totalStoppedTime;
        //dc.totalStartTime = Time.time - dc.totalStoppedTime;
        //startTime = Time.time - dc.totalStoppedTime;
        //dc.totalStartTime = Time.time - dc.totalStoppedTime;
        //playerDeaths = dc.totalDeaths;


        // dc.LoadDeaths();
        // playerDeaths = dc.totalDeaths;
        // currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		// deathText.text = "Deaths: " + playerDeaths.ToString();
	}

    void CurrentLocation() {
         GameObject input = GameObject.Find("Weather");
        Weather w = input.GetComponent<Weather>();
        StartCoroutine(w.GetWeather());
        //urrentLocation.GetComponentInChildren<Text>().text = w.city;
     }

    public bool inMainMenu(){
	 	int currentLevel = SceneManager.GetActiveScene().buildIndex;
	 	//Debug.Log("Current Level from inMainMenu: " + currentLevel);
	 	if(currentLevel == 0){
	 		return true;
	 	}else{ 
	 		return false;
	 	}
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 17)
        {
            Destroy(gameObject);
        }
        DuplicateGameSessionCheck();
        bool inmenu = inMainMenu();
        //Set Conditional Here
        //if(!inmenu){
        //if(pmig.loadMenuPressed == false){
            t = Time.time-startTime;
            dc.totalTime = t;
        //}
        //}
        //
        dc.SaveDeaths();
        //Debug.Log("Total Time: " + dc.totalTime);
        //dc.totalTime = Time.time-startTime;
        string minutes = ((int)t / 60).ToString("00");
        string seconds = (t % 60).ToString("00.00");
        timerText.text = "Time\n " + minutes + ":" + seconds;
        deathText.text = "Deaths: " + playerDeaths.ToString();
        oldSceneIndex = currentSceneIndex;
        playerDeaths = dc.totalDeaths;
        //CheckCurrentSeason();

        //Debug.Log("dc.totalDeaths: " + dc.totalDeaths);
    }


    private void DuplicateGameSessionCheck(){
    int numGameSessions = FindObjectsOfType<GameSession>().Length;
        // currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //  bool created = false;
        //  Debug.Log("From Game Session, Called: " + (SceneManager.GetActiveScene().buildIndex));
         if (numGameSessions > 1 && oldSceneIndex != currentSceneIndex/*&& oldSceneIndex != currentSceneIndex*/)
         {
             Destroy(gameObject);
         }
         else if(SceneManager.GetActiveScene().buildIndex == 0){
              Destroy(gameObject);
         }
         else
         {
             DontDestroyOnLoad(gameObject);
         } 


    }

    public void ProcessPlayerDeath()
    {
        Debug.Log("Inside ProcessPlayerDeath()");
        // if (playerLives > 1)
        // {
        //     incrementDeaths();
        // }
        // else
        // {
        //     ResetGameSession();
        // }
        if(playerDeaths >= 0){
            incrementDeaths();
        }
    }

    public void incrementDeaths()
    {
        FindObjectOfType<AudioManager>().Play("DieSound");
        //playerDeaths++;
        //playerDeaths++;
        dc.totalDeaths++;
        Debug.Log("Display total deaths: " + dc.totalDeaths);
        dc.SaveDeaths();
        
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        deathText.text = "Deaths: " + playerDeaths.ToString();
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
