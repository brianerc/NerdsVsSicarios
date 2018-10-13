using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.ObjetosTablero.Proyectiles;

/// <summary>
/// Generador correspondiente al single player. Logica correspondiente a "spawnear" personajes sicarios
/// para que el nerd pueda jugar y practicar solo.
/// </summary>
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
    public int filaQueSeEncuentra;
    public Grid matriz;
    public GeneradorObserver generadorObserver;

	void Start () {
        generadorObserver = GameObject.FindGameObjectWithTag("GeneradorObserver").GetComponent<GeneradorObserver>();
        tiempoGeneracionSicario1 = tiempoSicario1;
        tiempoGeneracionSicario2 = tiempoSicario2;
        tiempoGeneracionSicario3 = tiempoSicario3;
        tiempoSicario1 = Random.Range(tiempoGeneracionSicario1, tiempoGeneracionSicario1 + 10f);
        tiempoSicario2 = Random.Range(tiempoGeneracionSicario2, tiempoGeneracionSicario2 + 10f);
        tiempoSicario2 = Random.Range(tiempoGeneracionSicario3, tiempoGeneracionSicario3 + 10f);
    }

    void Update () {
        tiempoSicario1 -= Time.deltaTime;
        tiempoSicario2 -= Time.deltaTime;
        tiempoSicario3 -= Time.deltaTime;
        if (generadorObserver.generadoSicario1)
        {
            tiempoSicario1 = Random.Range(tiempoGeneracionSicario1, tiempoGeneracionSicario1 + 10f);
        }
        if (generadorObserver.generadoSicario2)
        {
            tiempoSicario2 = Random.Range(tiempoGeneracionSicario2, tiempoGeneracionSicario2 + 10f);
        }
        if (generadorObserver.generadoSicario3)
        {
            tiempoSicario3 = Random.Range(tiempoGeneracionSicario3, tiempoGeneracionSicario3 + 10f);
        }
        if (tiempoSicario1<=0)
        {
            tiempoSicario1 = Random.Range(tiempoGeneracionSicario1,tiempoGeneracionSicario1+10f);
            Instantiate(sicario1, ActualizarPosicion(), transform.rotation, transform);
            Filas.AgregarSicarioAFila(filaQueSeEncuentra);
            generadorObserver.generadoSicario1 = true;
        }
        if (tiempoSicario2 <= 0)
        {
            tiempoSicario2 = Random.Range(tiempoGeneracionSicario2, tiempoGeneracionSicario2 + 20f);
            Instantiate(sicario2,ActualizarPosicion(),transform.rotation,transform);
            Filas.AgregarSicarioAFila(this.filaQueSeEncuentra);
            generadorObserver.generadoSicario2 = true;
        }
        if (tiempoSicario3 <= 0)
        {
            tiempoSicario3 = Random.Range(tiempoGeneracionSicario3, tiempoGeneracionSicario3 + 30f);
            Instantiate(sicario3, ActualizarPosicion(), transform.rotation, transform);
            Filas.AgregarSicarioAFila(filaQueSeEncuentra);
            generadorObserver.generadoSicario3 = true;
        }
    }
    protected virtual Vector3 ActualizarPosicion()
    {
        Vector3 punto = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
        Vector3Int auxiliar = matriz.WorldToCell(punto);
        punto = matriz.GetCellCenterWorld(auxiliar);
        this.filaQueSeEncuentra = auxiliar.y;
        return punto;
    }
}
