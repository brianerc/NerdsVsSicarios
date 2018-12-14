using Assets.Scripts.Partida;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UsuarioRegistrar : MonoBehaviour
{
    public GameObject transicion;
	public InputField textNombreDeUsuario;
	public InputField contrasenia;
	public Text error;
	public Button boton;
    private string nombreEscena;

    private void Start()
    {
    }
    IEnumerator LoadScene()
    {
        transicion.GetComponent<Animator>().SetTrigger("Cerrar");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(nombreEscena, LoadSceneMode.Single);
    }
    public void volver()
	{
        nombreEscena = "UsuarioAcceso";
        StartCoroutine(LoadScene());
    }
    
	public void crearUsuario()
	{

		string nombreDeUsuario = textNombreDeUsuario.text;
		string contraseniaTexto = contrasenia.text;
		StartCoroutine(POST(nombreDeUsuario, contraseniaTexto));
	}

	public IEnumerator POST(string nombreDeUsuario, string contrasenia)
	{
		error.color = Color.black;
		error.text = "Cargando...";
		boton.enabled = false;
		Dictionary<string, string> headers = new Dictionary<string, string>();
		headers.Add("Content-Type", "application/json");

		string postBodyData = "{\"nombreusuario\":\"" + nombreDeUsuario + "\" , \"contrasenia\": \"" + contrasenia + "\"}";

		byte[] pData = System.Text.Encoding.ASCII.GetBytes(postBodyData.ToCharArray());

		WWW www = new WWW("http://35.243.154.34:8090/api/v1/usuario", pData, headers);

		yield return www;
		if (!string.IsNullOrEmpty(www.error))
		{
			error.text = www.error;
			error.color = Color.red;
			if (error.text.Equals("400 Bad Request"))
			{
				error.text = "Usuario ya existe";
			}
			else
			{
				error.text = "Error con el servidor";
			}
			Debug.Log(www.error);
			Debug.Log("EN ERROR");
		}
		else
		{
			error.color = Color.green;
			error.text = "Usuario creado";
		}
		boton.enabled = true;
	}
}
