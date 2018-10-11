using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzadorEstructuras : Lanzador {

    private Vector3 zonaNula;
    private AudioSource sonidoInvocacion;
    public override void Start()
    {
        base.Start();
        sonidoInvocacion = GetComponent<AudioSource>();
        jugador = GameObject.FindGameObjectWithTag("Nerd").GetComponent<Arbol>();
        zonaNula = Camera.main.ScreenToWorldPoint(new Vector3(0, 0));
        zonaNula.x = piso.GetComponent<Renderer>().bounds.size.x / 2;
        Vector3Int auxiliar = matriz.WorldToCell(zonaNula);
        zonaNula = matriz.GetCellCenterWorld(auxiliar);
    }

    protected override Vector3 ActualizarPosicion(Touch touch)
    {
        Vector3 punto = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
        Vector3Int auxiliar = matriz.WorldToCell(punto);
        punto = matriz.GetCellCenterWorld(auxiliar);
        if (punto.x == zonaNula.x)
        {
            punto.x = punto.x - matriz.cellSize.x;
        }
        return punto;
    }
    protected override void InstanciarInvocacion(GameObject nuevaEstructura, Touch touch)
    {
        base.InstanciarInvocacion(nuevaEstructura, touch);
        sonidoInvocacion.Play();
    }

}
