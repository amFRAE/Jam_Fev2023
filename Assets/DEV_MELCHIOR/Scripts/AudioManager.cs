using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioSource antSource;
    [SerializeField] AudioSource hitSource;
    [SerializeField] AudioSource rootSource;
    [SerializeField] List<AudioClip> antClips = new List<AudioClip>();
    [SerializeField] List<AudioClip> hitClips = new List<AudioClip>();
    [SerializeField] List<AudioClip> rootClips = new List<AudioClip>();

    public const string MUSIC_KEY = "musicVolume";
    public const string SFX_KEY = "sfxVolume";
    public const string TOGGLE_MUSIC_KEY = "toggleMusic";
    public const string TOGGLE_SFX_KEY = "toggleSFX";

    void Awake()
    {
        if (instance == null)
        {
            instance == this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadVolume();
    }

	public void AntSFX()
	{
		Audio clip = antClips[Random, Range(0, antClips.Count)];

		antSource.PlayOneShot(clip);
	}

	public void HitSFX()
	{
		Audio clip = hitClips[Random, Range(0, hitClips.Count)];

		hitSource.PlayOneShot(clip);
	}

	public void RootSFX()
	{
		Audio clip = rootClips[Random, Range(0, rootClips.Count)];

		rootSource.PlayOneShot(clip);
	}

	void LoadVolume() //Volume saved in VolumeSettings.cs
	{
		float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
		float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);
		if (PlayerPrefs.GetString(TOGGLE_MUSIC_KEY, "OFF") == "OFF")
		{
			mixer.SetFloat(VolumeSettings.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20);
		}
		else
		{
			mixer.SetFloat(VolumeSettings.MIXER_MUSIC, Mathf.Log10(0.0001f) * 20);
		}
		if (PlayerPrefs.GetString(TOGGLE_SFX_KEY, "OFF") == "OFF")
		{
			mixer.SetFloat(VolumeSettings.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);
		}
		else
		{
			mixer.SetFloat(VolumeSettings.MIXER_SFX, Mathf.Log10(0.0001f) * 20);
		}
	}
}
