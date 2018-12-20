using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzadorEstructuras : Lanzador {

    private Vector3 zonaNula;
    private AudioSource sonidoInvocacion;

	public AudioSource invocacionWeaboo;
	public AudioSource invocacionItGuy;
	public AudioSource invocacionEmo;
	public AudioSource invocacionGeneral;

	

	public override void Start()
    {
        base.Start();
        sonidoInvocacion = GetComponent<AudioSource>();
        jugador = GameObject.FindGameObjectWithTag("Nerd").GetComponent<Mazo>();
        zonaNula = Camera.main.ScreenToWorldPoint(new Vector3(0, 0));
        zonaNula.x = piso.GetComponent<Renderer>().bounds.size.x / 2;
        Vector3Int auxiliar = matriz.WorldToCell(zonaNula);
        zonaNula = matriz.GetCellCenterWorld(auxiliar);
    }

    protected override Vector2 ActualizarPosicion(Touch touch)
    {
        Vector2 punto = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
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
		invocacionGeneral.Play();
		if (jugador.nombre.Equals("weaboo"))
		{
			invocacionWeaboo.Play();
		} else if (jugador.nombre.Equals("emo"))
		{
			invocacionEmo.Play();
		} else if (jugador.nombre.Equals("itguy"))
		{
			invocacionItGuy.Play();
		}
	}

}
