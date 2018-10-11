using Assets.Scripts.ObjetosTablero.Proyectiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    abstract public class ObjetoTablero : MonoBehaviour {

	public float vidaBase;
	// Use this for initialization
	protected int costoEnergia;
	public Observable observable;
	public abstract bool EsSicario();
	public int FilaQueSeEncuentra { get; set; }

	private void Start()
	{
		this.observable = new Observable();
		
	}

	public virtual void Herir(float daño)
    {
        vidaBase = vidaBase - daño;
		AnimatorStateInfo stateInfo = this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
		if (vidaBase<=0)
        {
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
