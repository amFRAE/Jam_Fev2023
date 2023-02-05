using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEVELMANAGER : MonoBehaviour
{
    //Variables internes

    [Header("DEBUG")]
    [SerializeField] private bool doPrint = false;
    [Space]
    [Space]
    [Header("Préparation")]
    [SerializeField] private GameObject PF_Fourmi;
	[SerializeField] private GameObject PF_Ver;
	[SerializeField] private GameObject PF_Grillon;
    [Space]
    [Space]
    [Header("Paramètres")]
    [Tooltip("Temps (en secondes) entre chaque spawn.")]
    [SerializeField] private float SpawnTime = 2;
    [Tooltip("Réduction du temps de spawn pour chaque spawn.")]
    [SerializeField] private float SpawnTimeReduction = 0.025f;
    
	//Invokers
	void Start()
    {
        Init();
    }

    //Main functions
    private void Init()
    {
		Invoke("Spawn", SpawnTime);
	}

    private void Spawn()
    {
        int seed = Mathf.RoundToInt(Random.Range(0, 100));
        int seedT = 100 - seed;

        //Spawn ver
        if (seedT >= 75)
        {
			printer("Apparition d'un ver !");

			var Spawns = GameObject.Find("enemySpawn").GetComponent<enemySpawn>().Spawns;
            int id = Mathf.RoundToInt(Random.Range(0, Spawns.Count - 1));
            Instantiate(PF_Ver, Spawns[id].transform.position, Quaternion.identity);

		}
        else if (seedT >= 40)
		{
			//TODO : Faire apparaître grillon.
			printer("Apparition d'un grillon !");

			var Spawns = GameObject.Find("enemySpawn").GetComponent<enemySpawn>().Spawns;
			int id = Mathf.RoundToInt(Random.Range(0, Spawns.Count - 1));
			Instantiate(PF_Grillon, Spawns[id].transform.position, Quaternion.identity);

		}
		else if (seedT >= 25)
        {
			//TODO : Faire apparaître fourmi.
			printer("Apparition d'une fourmi !");

			var Spawns = GameObject.Find("enemySpawn").GetComponent<enemySpawn>().Spawns;
			int id = Mathf.RoundToInt(Random.Range(0, Spawns.Count - 1));
			Instantiate(PF_Fourmi, Spawns[id].transform.position, Quaternion.identity);
		}

        SpawnTime = Mathf.Clamp(SpawnTime - SpawnTimeReduction, 0.8f, Mathf.Infinity);
		Invoke("Spawn", SpawnTime);
	}

	//Minor functions
	private void printer(object message)
    {
        if (doPrint)
        {
            print(message);
        }
    }
}
