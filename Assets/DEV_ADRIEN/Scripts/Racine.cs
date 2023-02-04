using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racine : MonoBehaviour
{
	//Variables internes
	private float growthPercentage = 0;

	//Variables static
	public static Racine i = null;

	[Header("DEBUG")]
	[SerializeField] private bool doPrint = false;
	[Space]
	[Space]
	[Header("Indicateurs")]
	[Tooltip("Pourcentage de croissance de la racine")]
	[SerializeField][Range(0, 100)] private float growth = 0;
	[SerializeField][Range(0, 100)] private float hp = 100;
	[Space]
	[Space]
	[Header("Paramètres")]
	[Tooltip("Par combien est-ce que la racine grandit par tick ? (0 - 100)")]
	[Range(0, 100)] public float growthPerTick = 10;

	//Invokers
	private void Awake()
	{
		Singleton();
	}

	private void Update()
	{
		Indicateurs();
	}

	//Fonctions majeures
	public void Tick()
	{
		//Donner info si on print
		//printer(gameObject.name + " a reçu un tick !");

		//Faire grandir la racine
		growthPercentage = Mathf.Clamp(growthPercentage + growthPerTick, 0, 100);
		GameObject.Find("GAMEMANAGER").GetComponent<GAMEMANAGER>().STAT_CROISSANCE = Mathf.RoundToInt(growthPercentage);
		if (growthPercentage >= 100)
		{
			Time.timeScale = 0;
			Debug.LogError("GAGNE !");
		}
	}

	public void TakeDamage(float damage)
	{
		printer("La racine pris " + damage + " dégâts ! Vie restante : " + hp);
		hp = hp + (damage * -1);
		if (hp <= 0)
		{
			Time.timeScale = 0;
			Debug.LogError("PERDU !");
		}
	}

	//Fonctions mineures
	private void printer(object message)
	{
		if (doPrint)
		{
			print(message);
		}
	}
	private void Indicateurs()
	{
		growth = growthPercentage;
	}
	private void Singleton()
	{
		if (i == null)
		{
			i = this;
		}
	}
}
