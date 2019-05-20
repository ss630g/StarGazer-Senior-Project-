using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;
	//public static AudioManager instance;

	// Use this for initialization
	void Awake () {

		// int numAudioManagerSessions = FindObjectsOfType<SoundEffectsPlayer>().Length;
        // // currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // //  bool created = false;
        // //  Debug.Log("From Game Session, Called: " + (SceneManager.GetActiveScene().buildIndex));
        //  if (numAudioManagerSessions > 1)
        //  {
        //      Destroy(gameObject);
        //  }
        //  else
        //  {
        //      DontDestroyOnLoad(gameObject);
        //  } 

			int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1){
         	Destroy(gameObject);
        }else{
             DontDestroyOnLoad(gameObject);
        } 

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
            s.source.loop = s.loop;
		}
		
	}
	
	public void Play (string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
		s.source.Play();
	}
	
	public void Stop (string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
		s.source.Stop();
	}

    public void Loop ()
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.loop = true;
    }
}
