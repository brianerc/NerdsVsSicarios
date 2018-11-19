using Assets.Scripts.ObjetosTablero.Proyectiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Jerarquia padre de todos los objetos del tablero. Posee la logica comun a las estructuras y los sicarios
/// </summary>
abstract public class ObjetoTablero : MonoBehaviour
{
	public float vidaBase;
	protected int costoEnergia;
	public int filaQueSeEncuentra { get; set; }
	private bool muerto;
    public GameObject objetivo;
    public float danoBase = 0;
    public int nivel;
    private void Start()
	{
		muerto = false;
	}

    /// <summary>
    /// Funcion que llaman los objetos del tablero cuando golpean al otro
    /// </summary>
    /// <param name="daño"></param>
    public virtual void Herir(float daño)
	{
		vidaBase = vidaBase - daño;
		AnimatorStateInfo stateInfo = this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
		if (vidaBase <= 0 && !muerto)
		{
			muerto = true;
			this.GetComponent<Animator>().SetTrigger("Destruir");
		}
	}
	public int GetEnergia()
	{
		return costoEnergia;
	}
	public void SetCostoEnergia(int energia)
	{
		costoEnergia = energia;
	}
    public void Atacar()
    {
        if (objetivo)
        {
            if (objetivo.transform.tag == "Estructura" || objetivo.transform.tag == "Sicario")
                objetivo.GetComponent<ObjetoTablero>().Herir(this.danoBase);
            if (objetivo.transform.tag == "Nerd")
                objetivo.GetComponent<Arbol>().Herir(this.danoBase);
        }
    }
	public void Morir()
	{
		Destruir();
	}

	protected virtual void Destruir()
	{
		if (this.gameObject.tag == "Sicario")
		{
			Grid matriz = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
			Vector3Int auxiliar = matriz.WorldToCell(this.transform.position);
			Filas.EliminarSicarioAFila(auxiliar.y);
		}
		Destroy(this.gameObject);
	}

	public void SetVida(float vida)
	{
		vidaBase = vida;
	}
}
