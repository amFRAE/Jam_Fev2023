using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tickReceiver : MonoBehaviour
{
    private void Awake()
    {
        GameObject.Find("GAMEMANAGER").GetComponent<GAMEMANAGER>().tickReceiver.Add(this.gameObject);
    }
}
