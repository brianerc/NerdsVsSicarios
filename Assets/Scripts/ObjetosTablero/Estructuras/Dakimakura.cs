using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dakimakura : Estructura {
    public float tiempo;
    public float danoBase;
    // Use this for initialization
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
    public void SetDanoBase(float dano)
    {
        danoBase = dano;
    }
    public void SetTiempoAtaque(float unTiempo)
    {
        tiempo = unTiempo;
    }
    public float GetTiempo()
    {
        return danoBase;
    }
}
