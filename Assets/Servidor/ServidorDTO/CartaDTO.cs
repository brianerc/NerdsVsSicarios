using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ServidorDTO
{
	[Serializable]
	public class CartaDTO
	{
		public bool exito;
		public List<Carta> cartas;
	}

	[Serializable]
	public class Carta
	{
		public bool aprendida;
		public string _id;

		public int nivel;
		public string tipo;
		public string nombre;
		public string nombre_completo;
		public int danio;
		public int costo_para_desbloquear;
		public int velocidad;
		public int limite_nivel;

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override string ToString()
		{
			return nombre + " N" + nivel;
		}
	}
}
