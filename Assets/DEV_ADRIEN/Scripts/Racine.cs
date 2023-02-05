using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Racine : MonoBehaviour
{
	//Variables internes
	private float growthPercentage = 0;
	private bool r1 = false;
	private bool r2 = false;
	private bool r3 = false;
	private bool r4 = false;
	private bool r5 = false;
	private bool r6 = false;


	//Variables static
	public static Racine i = null;

	[Header("Préparation")]
	[SerializeField] private AnimationClip racineGrowth;
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
		GameObject.Find("Slider_HP").GetComponent<Slider>().value = hp;
	}

	//Fonctions majeures
	public void Tick()
	{
		//Références
		GameObject RacineSprites = transform.Find("_Sprites").gameObject;
		GameObject RacineObjects = transform.Find("_Racines").gameObject;

		//Faire grandir la racine
		growthPercentage = Mathf.Clamp(growthPercentage + growthPerTick, 0, 100);
		GameObject.Find("GAMEMANAGER").GetComponent<GAMEMANAGER>().STAT_CROISSANCE = Mathf.RoundToInt(growthPercentage);


		if (growthPercentage >= 14.29f && growthPercentage < 28.58f) //Si entre 14.29% et 28.57% inclus
		{
			if (!r1)
			{
				RacineSprites.transform.Find("1").GetComponent<Animation>().Play();
				RacineSprites.transform.Find("1").gameObject.SetActive(true);
				GameObject.Find("SFX_Root").GetComponent<AudioSource>().Play();
				r1 = true;
			}
		}
		else if (growthPercentage >= 28.58f && growthPercentage < 42.87f)
		{
			if (!r2)
			{
				RacineSprites.transform.Find("2").GetComponent<Animation>().Play();
				RacineSprites.transform.Find("2").gameObject.SetActive(true);
				GameObject.Find("SFX_Root").GetComponent<AudioSource>().Play();
				r2 = true;
			}
		}
		else if (growthPercentage >= 42.87f && growthPercentage < 57.16f)
		{
			if (!r3)
			{
				RacineSprites.transform.Find("3").GetComponent<Animation>().Play();
				RacineSprites.transform.Find("3").gameObject.SetActive(true);
				r3 = true;
			}
		}
		else if (growthPercentage >= 57.16f && growthPercentage < 71.45f)
		{
			if (!r4)
			{
				RacineSprites.transform.Find("4").GetComponent<Animation>().Play();
				RacineSprites.transform.Find("4").gameObject.SetActive(true);
				GameObject.Find("SFX_Root").GetComponent<AudioSource>().Play();
				r4 = true;
			}
		}
		else if (growthPercentage >= 71.45f && growthPercentage < 85.74f)
		{
			if (!r5)
			{
				RacineSprites.transform.Find("5").GetComponent<Animation>().Play();
				RacineSprites.transform.Find("5").gameObject.SetActive(true);
				GameObject.Find("SFX_Root").GetComponent<AudioSource>().Play();
				r5 = true;
			}
		}
		else if (growthPercentage >= 100)
		{
			if (!r6)
			{
				RacineSprites.transform.Find("6").GetComponent<Animation>().Play();
				RacineSprites.transform.Find("6").gameObject.SetActive(true);
				GameObject.Find("SFX_Root").GetComponent<AudioSource>().Play();
				r6 = true;
			}

			Invoke("WIN", racineGrowth.length);
		}
	}

	public void TakeDamage(float damage)
	{
		printer("La racine pris " + damage + " dégâts ! Vie restante : " + hp);
		hp = hp + (damage * -1);
		if (hp <= 0)
		{
			Time.timeScale = 0;
			GameObject.Find("CANVAS_LOOSE").transform.Find("go").gameObject.SetActive(true);
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
	private void WIN()
	{
		Time.timeScale = 0;
		GameObject.Find("Image").SetActive(false);
		GameObject.Find("CANVAS_WIN").transform.Find("go").gameObject.SetActive(true);
		Debug.LogError("GAGNE !");
	}
}
