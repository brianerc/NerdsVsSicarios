using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Especificacion del objeto del tablero para todos los game objects correspondientes a las estructuras. 
/// Esta clase sigue estando sobre la jerarquia de las estructuras. 
/// Las estructuras especifican esta clase con sus habilidades particulares correspondientes
/// </summary>
public class Estructura : ObjetoTablero {

	public override bool EsSicario()
	{
		return false;
	}
}
