using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonClickSound : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    public void playSound()
    {
        FindObjectOfType<AudioManager>().Play("ClickButton");
    }

    public void playChangeWeatherSound()
    {
        FindObjectOfType<AudioManager>().Play("ChangeWeatherButton");
    }
}
