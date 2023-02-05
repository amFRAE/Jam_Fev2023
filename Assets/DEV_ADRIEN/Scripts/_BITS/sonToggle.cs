using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sonToggle : MonoBehaviour
{
	public void Toggle()
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

	private void Update()
	{
		if (PlayerPrefs.GetString("Mute", "OFF") == "OFF")
		{
			GetComponent<Toggle>().isOn = false;
		}
		else if (PlayerPrefs.GetString("Mute", "OFF") == "ON")
		{
			GetComponent<Toggle>().isOn = true;
		}
	}
}