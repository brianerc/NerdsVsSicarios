using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dakimakura : Estructura {
    private float tiempo;
    private float danoBase;
    // Use this for initialization
    void Start()
    {
        vidaBase = 10;
        danoBase = 2;
        tiempo = 1;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Sicario")
        {
            Sicario enemigo = collision.gameObject.GetComponent<Sicario>();
            if (tiempo <= 0)
            {
                enemigo.Herir(danoBase);
                tiempo = 1;
            }
        }
    }
    private void FixedUpdate()
    {
        tiempo = tiempo - Time.deltaTime;
    }
}
