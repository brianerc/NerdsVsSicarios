using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObserver : MonoBehaviour {
    public bool generadoSicario1;
    public bool generadoSicario2;
    public bool generadoSicario3;
    private float tiempoSicario1;
    private float tiempoSicario2;
    private float tiempoSicario3;
    private float tiempoBase = 1;
	// Use this for initialization
	void Start () {
        generadoSicario1 = false;
        generadoSicario2 = false;
        generadoSicario3 = false;
        tiempoBase = 1;
        tiempoSicario1 = tiempoBase;
        tiempoSicario2 = tiempoBase;
        tiempoSicario3 = tiempoBase;
	}
	
	// Update is called once per frame
	void Update () {
		if(generadoSicario1)
        {
            tiempoSicario1 -= Time.deltaTime;
        }
        if (generadoSicario2)
        {
            tiempoSicario2 -= Time.deltaTime;
        }
        if (generadoSicario3)
        {
            tiempoSicario3 -= Time.deltaTime;
        }
        if(tiempoSicario1<=0)
        {
            tiempoSicario1 = tiempoBase;
            generadoSicario1 = false;
        }
        if (tiempoSicario2 <= 0)
        {
            tiempoSicario2 = tiempoBase;
            generadoSicario2 = false;
        }
        if (tiempoSicario3 <= 0)
        {
            tiempoSicario3 = tiempoBase;
            generadoSicario3 = false;
        }
    }
}
