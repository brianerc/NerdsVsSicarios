using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Servidor.ServidorDTO
{
	[Serializable]
	class UsuarioDTO
	{
		public bool exito;
		public Usuario usuario;
	}

	[Serializable]
	class Usuario
	{
		public string _id;
		public int nivel;
		public string nombreusuario;
		public string contrasenia;
		public List<CartaUsuario> cartas;
	}

	[Serializable]
	public class CartaUsuario
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
	}
}
