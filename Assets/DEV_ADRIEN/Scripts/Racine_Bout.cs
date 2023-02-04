using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racine_Bout : MonoBehaviour
{
    void Awake()
    {
        //Enregistrer bout 
        GameObject.Find("GAMEMANAGER").GetComponent<GAMEMANAGER>().Bouts.Add(this.gameObject);
    }
}
