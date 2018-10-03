using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    abstract public class ObjetoTablero : MonoBehaviour {
    protected float vidaBase;
	// Use this for initialization

	public virtual void Herir(float daño)
    {
        vidaBase = vidaBase - daño;
        if (vidaBase<=0)
        {
            this.GetComponent<Animator>().SetTrigger("Destruir");
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
    protected virtual void Destruir()
    {
        Destroy(this.gameObject);
    }
    public void SetVida(float vida)
    {
        vidaBase = vida;
    }
}
