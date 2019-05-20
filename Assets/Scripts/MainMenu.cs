using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [SerializeField] float LevelLoadDelay = 1f;
    [SerializeField] float LevelExitSlowMo = .2f;
    public Animator animator;

    public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);	
	}

    public void GoToMainMenu()
    {
        StartCoroutine(LoadMainMenu());
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    
    IEnumerator LoadMainMenu()
    {
        animator.SetTrigger("FadeOut");
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        SceneManager.LoadScene(20);
    }

  

	public void QuitGame()
	{
		Debug.Log("QUIT");
		Application.Quit();
	}


}
