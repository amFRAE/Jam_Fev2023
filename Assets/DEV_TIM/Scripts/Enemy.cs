using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector3 target;
    private bool surRacine = false;

    [HideInInspector] public bool cursor = false;
    [Header("Parametres")]

    [Range(1,3)] public int hp;
    public float speed = 5;
    [Range(1, 100)] public float damage = 2;

    //Invokers
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Définir cible; un bout de racine random.
        List<GameObject> bouts = GameObject.Find("GAMEMANAGER").GetComponent<GAMEMANAGER>().Bouts;
        int id = Random.Range(0, bouts.Count - 1);
        print("Bouts is from 0 to " + (bouts.Count - 1) + ". Chosen ID is " + id);
        target = bouts[id].transform.position;
		transform.up = target - transform.position;
	}
	private void OnEnable()
	{
		Rotation();
	}
	private void OnMouseEnter()
	{
        isCursor(true);
	}
	private void OnMouseExit()
	{
		isCursor(false);
	}
	private void Update()
    {
        Hit();
    }
	private void FixedUpdate()
    {
        Move();
    }
	private void OnTriggerEnter2D(Collider2D col)
	{
        if (col.gameObject.tag == "Racine_Bout")
        {
            surRacine = true;
            transform.Find("Fourmis_Anim").GetComponent<Animator>().SetBool("attacking", true);
        }
	}

	//Fonctions majeures
	private void Hit()
    {
        if(Input.GetMouseButtonDown(0) && cursor)
        {
            hp--;
        }
        if(hp <= 0)
        {
            //Se retirer de la liste des objets devant recevoir des ticks
            GameObject.Find("GAMEMANAGER").GetComponent<GAMEMANAGER>().tickReceiver.Remove(this.gameObject);

            Destroy(gameObject);
        }
    }
    private void Move()
    {
        if (!surRacine)
        {
			rb.velocity = transform.up * speed;
		}
        else if (surRacine)
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
    private void Rotation()
    {
        if (gameObject.tag == "Enemy_Fourmi")
        {
            transform.up = new Vector3(target.x, target.y - 0.7f, 0) - transform.position;
		}
	}
    public void Tick()
    {
        if (surRacine)
        {
            GameObject.FindGameObjectWithTag("Racine").GetComponent<Racine>().TakeDamage(damage);
        }
    }

    //Fonctions mineures
    private void isCursor(bool state)
    {
        cursor = state;
    }

}
