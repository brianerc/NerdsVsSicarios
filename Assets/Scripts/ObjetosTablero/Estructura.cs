using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Especificacion del objeto del tablero para todos los game objects correspondientes a las estructuras. 
/// Esta clase sigue estando sobre la jerarquia de las estructuras. 
/// Las estructuras especifican esta clase con sus habilidades particulares correspondientes
/// </summary>
public class Estructura : ObjetoTablero {

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.transform.tag == "Sicario")
		{
			objetivo = collision.gameObject;
			int cantEnemigos = this.GetComponent<Animator>().GetInteger("cant_enemigos");
			this.GetComponent<Animator>().SetInteger("cant_enemigos", cantEnemigos + 1);
		}
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
		if (collision.transform.tag == "Sicario")
		{
			int cantEnemigos = this.GetComponent<Animator>().GetInteger("cant_enemigos");
			this.GetComponent<Animator>().SetInteger("cant_enemigos", cantEnemigos - 1);
		}
		objetivo = null;
    }
}
