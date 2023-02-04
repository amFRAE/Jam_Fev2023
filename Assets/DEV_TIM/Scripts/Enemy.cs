using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody2D rb;


    [HideInInspector] public bool cursor = false;
    [Header("Parametres")]

    [Range(1,3)] public int hp;
    public float speed = 5;
    [Range(1, 100)] public float damage = 2;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Hit();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void States(bool states)
    {
        cursor = states;

    }

    private void Hit()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hp--;
        }
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnEnable()
    {
        Rotation();
    }

    private void Rotation()
    {
        Vector3 racinepos = GameObject.Find("ProtoRacine").transform.position;
        transform.up = racinepos - transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "cursor")
        {
            cursor = true;
            print("Cursor enter");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "cursor")
        {
            cursor = false;
            print("Cursor leave");
        }
    }

}
