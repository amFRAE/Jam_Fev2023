using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI stats;
    public string preText = "Nombre d'insectes tués ";
    public string nomDeStat = "STAT_INSECT";
    

    void Update()
    {
        if (nomDeStat == "STAT_INSECT")
        {
            if (SceneManager.GetActiveScene().name == "Game" || SceneManager.GetActiveScene().name == "DEV_ADRIEN")
            {
				stats.text = preText + GameObject.Find("GAMEMANAGER").GetComponent<GAMEMANAGER>().STAT_INSECT.ToString();
			}
			else
            {
                stats.text = preText + "0";
            }
        }
        else if (nomDeStat == "STAT_CHAMPI")
        {
            if (SceneManager.GetActiveScene().name == "Game" || SceneManager.GetActiveScene().name == "DEV_ADRIEN")
            {
                stats.text = preText + GameObject.Find("GAMEMANAGER").GetComponent<GAMEMANAGER>().STAT_CHAMPI.ToString();
			}
            else
            {
                stats.text = preText + "0";
            }
        }
        else if (nomDeStat == "STAT_CROISSANCE")
        {
            if (SceneManager.GetActiveScene().name == "Game" || SceneManager.GetActiveScene().name == "DEV_ADRIEN")
            {
                stats.text = preText + GameObject.Find("GAMEMANAGER").GetComponent<GAMEMANAGER>().STAT_CROISSANCE.ToString();
            }
            else
            {
                stats.text = preText + "0";
            }
        }

    }
}
