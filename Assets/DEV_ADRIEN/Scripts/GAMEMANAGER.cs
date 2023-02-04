using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GAMEMANAGER : MonoBehaviour
{
    //Variables static
    public static GAMEMANAGER i;

    //Variables internes

    //Variables "grab"
    [NonSerialized] public double secondsElapsed = 0;

    [Header("DEBUG")]
    [SerializeField] private bool doPrint = false;
    [Space]
    [Space]
	[Header("Paramètres")]
    [Header("- Ticks")]
    [Tooltip("Toutes les combien de secondes est-ce qu'un tick arrive [Défaut = 1]")]
    public float tickRate = 1;

    //Invokers
    void Awake()
    {
        Init();
    }
	private void Start()
	{
        //Démarrer boucle des ticks
        Invoke("doTick", 1);
	}

	//Fonctions majeures
    void doTick()
    {
        //Envoyer event "tick" aux GameObjects
        GameObject.FindGameObjectWithTag("Racine").GetComponent<Racine>().Tick(); //... à la racine

        //Boucle
        secondsElapsed++;
		Invoke("doTick", 1);
	}

	//Fonctions mineures
	private void Init()
    { 
        //Singletons
        if (i == null)
        {
            i = this;
        }
    }

    private void printer(object message)
    {
        if (doPrint)
        {
            print(message);
        }
    }
}
