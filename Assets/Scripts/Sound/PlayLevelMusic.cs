using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayLevelMusic : MonoBehaviour {

	int newLevelIndex = 0;
	int oldLevelIndex = -1;
    string newSeason = "MainMenu";
    string oldSeason = "Default";

	void Start() {
		//FindObjectOfType<AudioManager>().Play("MenuMusic");
		newLevelIndex = 0;
		oldLevelIndex = -1;
        newSeason = "MainMenu";
        oldSeason = "Default";
    }

	// Update is called once per frame
	void Update () {
        newSeason = DetectSeasonChange();
        //if(newSeason != oldSeason)
        //{
        //    ChangeLevelSong(oldSeason, newSeason);

        //}
		newLevelIndex = SceneManager.GetActiveScene().buildIndex;
		if(newSeason != oldSeason){
			Debug.Log("Season Has Changed");
			ChangeLevelSong(newSeason);
		}
		oldSeason = newSeason;
	}

	string DetectSeasonChange(){
        newLevelIndex = SceneManager.GetActiveScene().buildIndex;
        if (newLevelIndex == 0)
        {
            return "MainMenu";
        }else if(newLevelIndex == 1 || newLevelIndex == 5 || newLevelIndex == 9 || newLevelIndex == 13)
        {
            return "spring";
        }
        else if (newLevelIndex == 2 || newLevelIndex == 6 || newLevelIndex == 10 || newLevelIndex == 14)
        {
            return "summer";
        }
        else if (newLevelIndex == 3 || newLevelIndex == 7 || newLevelIndex == 11 || newLevelIndex == 15)
        {
            return "fall";
        }
        else if (newLevelIndex == 4 || newLevelIndex == 8 || newLevelIndex == 12 || newLevelIndex == 16)
        {
            return "winter";
        }
        else
        {
            return "EndGame";
        }
    }

	void ChangeLevelSong(string newSeason){
        Debug.Log("Stop ALL MUSIC");
        FindObjectOfType<AudioManager>().Stop("MenuMusic");
        FindObjectOfType<AudioManager>().Stop("SpringMusic");
        FindObjectOfType<AudioManager>().Stop("FallMusic");
        FindObjectOfType<AudioManager>().Stop("WinterMusic");
        FindObjectOfType<AudioManager>().Stop("SummerMusic");
        FindObjectOfType<AudioManager>().Stop("GameEndMusic");

        // MenuMusic
        if (newSeason == "MainMenu"){
            //         FindObjectOfType<AudioManager>().Stop("MenuMusic");
            //         FindObjectOfType<AudioManager>().Stop("SpringMusic");
            //FindObjectOfType<AudioManager>().Stop("FallMusic");
            //FindObjectOfType<AudioManager>().Stop("WinterMusic");
            //FindObjectOfType<AudioManager>().Stop("SummerMusic");
            FindObjectOfType<AudioManager>().Stop("GameEndMusic");
            FindObjectOfType<AudioManager>().Play("MenuMusic");
		}
		// Spring Music
		else if(newSeason == "spring"){
			//FindObjectOfType<AudioManager>().Stop("MenuMusic");
			//FindObjectOfType<AudioManager>().Stop("FallMusic");
			//FindObjectOfType<AudioManager>().Stop("WinterMusic");
			//FindObjectOfType<AudioManager>().Stop("SummerMusic");
			FindObjectOfType<AudioManager>().Play("SpringMusic");
		}

		// Summer Music
		else if(newSeason == "summer"){
			//FindObjectOfType<AudioManager>().Stop("MenuMusic");
			//FindObjectOfType<AudioManager>().Stop("WinterMusic");
			//FindObjectOfType<AudioManager>().Stop("SpringMusic");
			//FindObjectOfType<AudioManager>().Stop("FallMusic");
			FindObjectOfType<AudioManager>().Play("SummerMusic");
		}
  
		// Fall Music
		else if(newSeason == "fall"){
			//FindObjectOfType<AudioManager>().Stop("MenuMusic");
			//FindObjectOfType<AudioManager>().Stop("WinterMusic");
			//FindObjectOfType<AudioManager>().Stop("SpringMusic");
			//FindObjectOfType<AudioManager>().Stop("SummerMusic");
			FindObjectOfType<AudioManager>().Play("FallMusic");
		}

		// Winter Music
		else if(newSeason == "winter"){
			//FindObjectOfType<AudioManager>().Stop("FallMusic");
			//FindObjectOfType<AudioManager>().Stop("MenuMusic");
			//FindObjectOfType<AudioManager>().Stop("SpringMusic");
			//FindObjectOfType<AudioManager>().Stop("SummerMusic");
			FindObjectOfType<AudioManager>().Play("WinterMusic");
		}
        //if (newIndex == 17)
        else if(newSeason == "EndGame"){
            //FindObjectOfType<AudioManager>().Stop("FallMusic");
            //FindObjectOfType<AudioManager>().Stop("MenuMusic");
            //FindObjectOfType<AudioManager>().Stop("SpringMusic");
            //FindObjectOfType<AudioManager>().Stop("SummerMusic");
            FindObjectOfType<AudioManager>().Play("GameEndMusic");
        }
    }
}
