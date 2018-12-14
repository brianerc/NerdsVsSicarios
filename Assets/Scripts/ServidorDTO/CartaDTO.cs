using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ServidorDTO
{
	[Serializable]
	class CartaDTO
	{
		public bool exito;
		public List<Carta> cartas;

	
	}

	[Serializable]
	class Carta
	{
		public int nivel;
		public bool aprendida;
		public string _id;
		public string tipo;
		public string nombre;
		public int danio;
		public int costoParaDesbloquear;
		public int velocidad;

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
