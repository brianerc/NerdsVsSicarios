using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
