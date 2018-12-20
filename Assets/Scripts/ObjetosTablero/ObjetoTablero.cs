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
	public List<GameObject> objetivos;
	public float danoBase;
	public int nivel;
	public string nombre;
	public AudioSource muerteSonido;
	public AudioSource ataqueSonido;

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
			if (muerteSonido != null)
			{
				muerteSonido.Play();
			}
			this.GetComponent<Animator>().SetTrigger("Destruir");
			muerto = true;

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
		if (objetivos != null && objetivos.Count > 0)
		{
			GameObject objetivo = objetivos[0];
			while (objetivo == null && objetivos.Count > 0)
			{
				objetivos.RemoveAt(0);
				if (objetivos.Count > 0)
				{
					objetivo = objetivos[0];
				}
				else
				{
					objetivo = null;
				}
			}
			if (objetivo != null)
			{
				if (ataqueSonido != null)
				{
					ataqueSonido.Play();
				}
				if (objetivo.transform.tag == "Estructura" || objetivo.transform.tag == "Sicario")
					objetivo.GetComponent<ObjetoTablero>().Herir(this.danoBase);
				if (objetivo.transform.tag == "Nerd")
					objetivo.GetComponent<Mazo>().Herir(this.danoBase);
			}
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
