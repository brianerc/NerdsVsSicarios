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
		public int puntos;
	}
}
