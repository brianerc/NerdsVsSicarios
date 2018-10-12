using Assets.Scripts.ObjetosTablero.Proyectiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LanzadorSicario : Lanzador
{
    private AudioSource sonidoInvocacion;
    public override void Start()
    {
        base.Start();
        sonidoInvocacion = GetComponent<AudioSource>();
        jugador = GameObject.FindGameObjectWithTag("JugadorSicario").GetComponent<Arbol>();
    }
    protected override void AnimarNerd()
    {

    }
    protected override void InstanciarEstructura(GameObject nuevaEstructura)
    {
        sonidoInvocacion.Play();
        Instantiate(nuevaEstructura);
    }
    protected override void InstanciarInvocacion(GameObject nuevaEstructura, Touch touch)
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
