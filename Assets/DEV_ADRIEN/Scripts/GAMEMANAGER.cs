using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEMANAGER : MonoBehaviour
{
    //Variables static
    public static GAMEMANAGER i;

    //Variables internes

    //Variables "grab"
    [NonSerialized] public double secondsElapsed = 0;
	[NonSerialized] public List<GameObject> Bouts = new List<GameObject>();
	[NonSerialized] public List<GameObject> tickReceiver = new List<GameObject>();

	[Header("DEBUG")]
    [SerializeField] private bool doPrint = false;
    [Header("Indicateures")]
    [SerializeField] private List<GameObject> allBouts;
	[Space]
	[Space]
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
	private void Update()
	{
        Indicateurs();
	}

	//Fonctions majeures
	void doTick()
    {
        foreach (GameObject receiver in tickReceiver)
        {
            switch (receiver.tag)
            {
                case "Racine":
                    receiver.GetComponent<Racine>().Tick();
                    break;

                case "Enemy_Grillon":
                    receiver.GetComponent<Enemy>().Tick();
                    break;

				case "Enemy_Ver":
					receiver.GetComponent<Enemy>().Tick();
					break;

				case "Enemy_Fourmi":
					receiver.GetComponent<Enemy>().Tick();
					break;
			}
        }

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

    private void Indicateurs()
    {
        allBouts = Bouts;
    }
}
