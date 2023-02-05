using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AUDIOMANAGER : MonoBehaviour
{
    [SerializeField] private AudioMixer Mixer;
	[SerializeField] private List<AudioSource> Clips = new List<AudioSource>();

    public static AUDIOMANAGER i = null;

	private void Awake()
	{
        DontDestroyOnLoad(gameObject);
        soundState();

        if (i == null)
        {
            i = this;
        }
	}

	public void Mute(bool State)
    {
		if (PlayerPrefs.GetString("Mute", "OFF") == "OFF")
		{
            PlayerPrefs.SetString("Mute", "ON");
        }
		else if (PlayerPrefs.GetString("Mute", "OFF") == "ON")
		{
			PlayerPrefs.SetString("Mute", "OFF");
		}
	}

    public void Play(string clipName)
    {
        foreach (AudioSource Clip in Clips)
        {
            if (Clip.gameObject.name == clipName)
            {
                Clip.Play();
            }
        }
    }

    
    private void soundState()
    {
        if (PlayerPrefs.GetString("Mute", "OFF") == "OFF")
        {
            Mixer.SetFloat("Volume", -20f);
        }
        else if (PlayerPrefs.GetString("Mute", "OFF") == "ON")
        {
            Mixer.SetFloat("Volume", -80f);
        }
	}
}
