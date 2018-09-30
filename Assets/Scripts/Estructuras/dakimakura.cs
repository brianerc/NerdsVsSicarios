using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dakimakura : MonoBehaviour {
    private float tiempo;
    private float danoBase;
    private float vidaBase;
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
            JugadorDeFootballBase enemigo = collision.gameObject.GetComponent<JugadorDeFootballBase>();
            if (tiempo <= 0)
            {
                enemigo.Herir(danoBase);
                tiempo = 1;
            }
        }
    }
    public void Herir(float dano)
    {
        vidaBase = vidaBase - dano;
        if (vidaBase <= 0)
        {
            Destruir();
            //this.GetComponent<Animator>().SetTrigger("Destruir");
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
    private void FixedUpdate()
    {
        tiempo = tiempo - Time.deltaTime;
    }
    public void Destruir()
    {
        Destroy(this.gameObject);
    }
}
