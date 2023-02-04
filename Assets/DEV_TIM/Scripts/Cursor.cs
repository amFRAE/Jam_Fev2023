using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
    void Update()
    {
        Vector3 mousepose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousepose.x,mousepose.y,0);
    }

}
