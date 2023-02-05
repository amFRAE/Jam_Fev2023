using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
	[SerializeField] AudioMixer mixer;
	[SerializeField] Slider musicSlider;
	[SerializeField] Slider sfxSlider;
	[SerializeField] Toggle musicToggle;
	[SerializeField] Toggle sfxToggle;

	public const string MIXER_MUSIC = "MusicVolume";
	public const string MIXER_SFX = "SFXVolume";
	public const string TOGGLE_MUSIC = "ToggleMusic";
	public const string TOGGLE_SFX = "ToggleSFX";

	void Awake()
	{
	musicSlider.onValueChanged.AddListener(SetMusicVolume);
	sfxSlider.onValueChanged.AddListener(SetSFXVolume);
	musicToggle.onValueChanged.AddListener(ToggleMusic);
	sfxToggle.onValueChanged.AddListener(ToggleSFX);
	}

	void Start()
	{
		musicSlider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY, 1f);
		sfxSlider.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY, 1f);
		if (PlayerPrefs.GetString(AudioManager.TOGGLE_MUSIC_KEY, "OFF") == "OFF")
		{
			musicToggle.isOn = false;
		}
		else
        {
			musicToggle.isOn = true;
		}
		if (PlayerPrefs.GetString(AudioManager.TOGGLE_SFX_KEY, "OFF") == "OFF")
		{
			sfxToggle.isOn = false;
		}
		else
		{
			sfxToggle.isOn = true;
		}
	}

	void OnDisable()
	{
		PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, musicSlider.value);
		PlayerPrefs.SetFloat(AudioManager.SFX_KEY, sfxSlider.value);
		if(musicToggle.isOn)
        {
			PlayerPrefs.SetString(AudioManager.TOGGLE_MUSIC_KEY, "ON");
		}
		else
        {
			PlayerPrefs.SetString(AudioManager.TOGGLE_MUSIC_KEY, "OFF");

		}
		if (sfxToggle.isOn)
		{
			PlayerPrefs.SetString(AudioManager.TOGGLE_SFX_KEY, "ON");
		}
		else
		{
			PlayerPrefs.SetString(AudioManager.TOGGLE_SFX_KEY, "OFF");
		}
	}

	void SetMusicVolume(float value)
	{
		mixer.setFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
	}

	void SetSFXVolume(float value)
	{
		mixer.setFloat(MIXER_SFX, Mathf.Log10(value) * 20);
	}

	void ToggleMusic(bool value)
	{
		if (value)
		{
			SetMusicVolume(0.0001f);
		}
		else
		{
			SetMusicVolume(1);
		}
	}

	void ToggleSFX(bool value)
	{
		if (value)
		{
			SetSFXVolume(0.0001f);
		}
		else
		{
			SetSFXVolume(1);
		}
	}
}



