using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.ObjetosTablero.Proyectiles;

public class Generador : MonoBehaviour {
    public GameObject sicario1;
    public GameObject sicario2;
    public GameObject sicario3;
    public float tiempoSicario1;
    public float tiempoSicario2;
    public float tiempoSicario3;
    private float tiempoGeneracionSicario1;
    private float tiempoGeneracionSicario2;
    private float tiempoGeneracionSicario3;
    public Grid matriz;
	// Use this for initialization
	void Start () {
        tiempoGeneracionSicario1 = tiempoSicario1;
        tiempoGeneracionSicario2 = tiempoSicario2;
        tiempoGeneracionSicario3 = tiempoSicario3;
        sicario1.transform.position = ActualizarPosicion();
        sicario2.transform.position = ActualizarPosicion();
        sicario3.transform.position = ActualizarPosicion();
    }

    // Update is called once per frame
    void Update () {
        tiempoSicario1 -= Time.deltaTime;
        tiempoSicario2 -= Time.deltaTime;
        tiempoSicario3 -= Time.deltaTime;
        if(tiempoSicario1<=0)
        {
            tiempoSicario1 = tiempoGeneracionSicario1;
            Instantiate(sicario1);
        }
        if (tiempoSicario2 <= 0)
        {
            tiempoSicario2 = tiempoGeneracionSicario2;
            Instantiate(sicario2);
        }
        if (tiempoSicario3 <= 0)
        {
            tiempoSicario3 = tiempoGeneracionSicario3;
            Instantiate(sicario3);
        }
    }
    protected virtual Vector3 ActualizarPosicion()
    {
        Vector3 punto = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        Vector3Int auxiliar = matriz.WorldToCell(transform.position);
        punto = matriz.GetCellCenterWorld(auxiliar);
        return punto;
    }
}
