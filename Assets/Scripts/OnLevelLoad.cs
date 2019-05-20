using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class OnLevelLoad : MonoBehaviour {


	public playerLevelInfo pli;
	public DeathCount dc; 
	//public PauseMenuInGame pmig;
	private int currentLevel;
    private string currentSeasonString;
	// public bool existsSaveFile;
	
	// Use this for initialization
	void Start () {
		// currentLevel = SceneManager.GetActiveScene().buildIndex;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Current Level from OnLevelLoad: " + currentLevel);
        //pmig.loadMenuPressed = true;
        SaveGameAtBeginning();
        // CheckForSaveFile();
        currentSeasonString = ReturnCurrentLevel();
        Debug.Log(currentSeasonString);
	}

    public string ReturnCurrentLevel()
    {
        if(currentLevel == 0)
        {
            return "main_menu";
        }
        else if (currentLevel == 1 || currentLevel == 5 || currentLevel == 9 || currentLevel == 13)
        {
            return "spring";
        }
        else if (currentLevel == 2 || currentLevel == 6 || currentLevel == 10 || currentLevel == 14)
        {
            return "summer";
        }
        else if (currentLevel == 3 || currentLevel == 7 || currentLevel == 11 || currentLevel == 15)
        {
            return "fall";
        }
        else
        {
            return "winter";
        }

    }


	// public bool CheckForSaveFile(){
	// 	string path = Application.persistentDataPath + "/player_info";
	// 	if (!File.Exists(path))
	// 		return false;
	// 	else
	// 		return true;
	// }

	public void SaveGameAtBeginning(){
			bool insideMainMenu = inMainMenu();
			//Debug.Log(insideMainMenu.ToString());
			if(insideMainMenu == false){
				  //dc.SaveDeaths();
				dc.LoadDeaths();
				//Debug.Log("dc.totalDeaths after load: " + dc.totalDeaths);
        // playerDeaths = dc.totalDeaths;
				Debug.Log("Not in Main Menu");
				pli.SavePlayer();
			}else{
				Debug.Log("In Main Menu");
				// pli.SavePlayer();
			}
	}

	public bool inMainMenu(){
		currentLevel = SceneManager.GetActiveScene().buildIndex;
		Debug.Log("Current Level from inMainMenu: " + currentLevel);
		if(currentLevel == 0){
			return true;
		}else{
			return false;
		}
	}
	// Update is called once per frame
}
