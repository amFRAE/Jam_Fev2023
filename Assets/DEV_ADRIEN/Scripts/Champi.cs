using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Champi : MonoBehaviour
{
    //Variables privées
    private float growthPercent = 0;
    private bool mouse = false;

    [Header("Indicateurs")]
    [SerializeField][Range(0, 100)] private float growth = 0;
    [Space]
    [Space]
    [Header("Paramètres")]
    [Tooltip("Tous les ticks, pousser de combien de % ?")]
    [SerializeField] [Range(0, 100)] private float growthPerTick = 2.5f;
    [Tooltip("Lorsque mature, combien de dégâts par tick ?")]
    [SerializeField] [Range(0, 100)] private float damagePerTick = 2.5f;


	private void Update()
	{
        Indicateurs();

        if (Input.GetMouseButtonDown(0) && mouse == true && growthPercent >= 100)
        {
            GameObject.Find("GAMEMANAGER").GetComponent<GAMEMANAGER>().tickReceiver.Remove(gameObject);
			GameObject.Find("GAMEMANAGER").GetComponent<GAMEMANAGER>().Invoke("spawnChampi", 3);
			Destroy(gameObject);
        }
	}
	private void OnMouseEnter()
	{
        mouse = true;
	}
	private void OnMouseExit()
	{
        mouse = false;
	}

	public void Tick()
    {
        if (growthPercent >= 100)
        {
            Damage();
        }
        else
        {
			Grow();
        }
	}
    
    void Damage()
    {
        GameObject.FindGameObjectWithTag("Racine").GetComponent<Racine>().TakeDamage(damagePerTick);
    }
    void Grow()
    {
        growthPercent = Mathf.Clamp(growthPercent + growthPerTick, 0, 100);
    }
    private void Indicateurs()
    {
        growth = growthPercent;
    }
}
