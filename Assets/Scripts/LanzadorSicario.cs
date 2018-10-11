using Assets.Scripts.ObjetosTablero.Proyectiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LanzadorSicario : Lanzador
{
    public override void Start()
    {
        base.Start();
        jugador = GameObject.FindGameObjectWithTag("JugadorSicario").GetComponent<Arbol>();
    }
    protected override void AnimarNerd()
    {

    }
    protected override Vector3 ActualizarPosicion(Touch touch)
    {
        Vector3 punto = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
        punto.x = piso.GetComponent<Renderer>().bounds.size.x / 2;
        Vector3Int auxiliar = matriz.WorldToCell(punto);
		punto = matriz.GetCellCenterWorld(auxiliar);
        punto.z = 0f;
		this.filaQueSeEncuentra = auxiliar.y; 
		return punto;
    }
}
