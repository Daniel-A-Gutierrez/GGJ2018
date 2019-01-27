using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;


public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public static AudioManager instance;   
    // Start is called before the first frame update and before start
    void Awake()
    {
    	//makes it so that if the audiomanager exists already, it destroys one to avoid duplicates
    	if(instance == null)
    	{
    		instance = this;
    	}
    	else
    	{
    		Destroy(gameObject);
    		return;
    	}
    	DontDestroyOnLoad(gameObject);  //makes it so that audiomanager isnt destroyed between scenes, song is continuous
        foreach(Sound s in sounds)		
        {
        	s.source = gameObject.AddComponent<AudioSource>();
        	s.source.clip = s.clip;
        	s.source.volume = s.volume;
        	s.source.pitch = s.pitch;
        	s.source.loop = s.loop;
			
        }
    }
    void Start()
    {
    	Play("Daytime");     //Plays theme at start
    }

    public void Play (string name)
    {
    	Sound s = Array.Find(sounds, sound => sound.name == name);
    	if(s == null)        //catches the error where we try to access a clip that isn't there(or mispelled)
    	{
    		Debug.LogWarning("Sound " + name + " not found");
    		return;
    	}
    	s.source.Play();
    }

	public void Stop (string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
    	if(s == null)        //catches the error where we try to access a clip that isn't there(or mispelled)
    	{
    		Debug.LogWarning("Sound " + name + " not found");
    		return;
    	}
    	s.stop();
	}
}
