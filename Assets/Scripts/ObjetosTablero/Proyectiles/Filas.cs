using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Clase correspondiente a la logica para saber en que fila se encuentran los sicarios.
/// Esta clase existe para objetos como la catapultan que necesitan saber en que fila estan los sicarios
/// para poder comenzar a disparar. 
/// De haber personajes sicarios que necestian saber en que filas se encuentran las estructuras, 
/// se agregarian en esta misma clase ya que es la responsable de gestionar las filas y los objetos 
/// del tablero que se encuentran en la misma
/// </summary>
namespace Assets.Scripts.ObjetosTablero.Proyectiles
{
	class Filas
	{
		public static Dictionary<float, int> SicariosEnFilas = new Dictionary<float, int>();

		public static bool HaySicarioEnFila(float fila)
		{
			if (SicariosEnFilas.ContainsKey(fila) && SicariosEnFilas[fila] > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		internal static void AgregarSicarioAFila(float y)
		{
			if (!SicariosEnFilas.ContainsKey(y))
			{
				SicariosEnFilas[y] = 0;
			}
			SicariosEnFilas[y]++;
		}

		public static void EliminarSicarioAFila(float y)
		{
			if (!SicariosEnFilas.ContainsKey(y))
			{
				//throw new Exception("Eliminar sicario de fila cuando no se agrego");
			}
			SicariosEnFilas[y]--;
		}
	}
}
