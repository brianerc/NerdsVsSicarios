using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
	public GameObject fondo;
	public GameObject paginaVista;
	public int pagina;
	public GameObject flechaAtras;
	public GameObject flechaAdelante;

	private void Start()
	{
		pagina = 1;
		SpriteRenderer renderer = flechaAtras.GetComponent<SpriteRenderer>();
		renderer.sprite = null;
	}

	private void CargarCartas()
	{
		
	}

	void Update()
	{

		RaycastHit2D hit;
		if (Input.touchCount < 1)
		{
			return;
		}
		Touch touch = Input.GetTouch(0);
		Vector2 test = Camera.main.ScreenToWorldPoint(touch.position);
		hit = Physics2D.Raycast(test, (touch.position));
		if (touch.phase == TouchPhase.Ended)
		{
			if (hit.collider != null)
			{

				

				if (hit.transform.name == "flecha_adelante")
				{
					if (pagina != 6)
					{
						pagina++;

						Sprite spriteFlecha = Resources.Load<Sprite>("Sprites/Tutorial/flecha_adelante");
						SpriteRenderer rendererFlecha = flechaAdelante.GetComponent<SpriteRenderer>();
						rendererFlecha.sprite = spriteFlecha;

						if (pagina != 1)
						{
							Sprite spriteFlechaAtras = Resources.Load<Sprite>("Sprites/Tutorial/flecha_atras");
							SpriteRenderer rendererFlechaAtras = flechaAtras.GetComponent<SpriteRenderer>();
							rendererFlechaAtras.sprite = spriteFlechaAtras;
						}

						string nombrePagina = "tutorial_" + pagina;
						Sprite sprite = Resources.Load<Sprite>("Sprites/Tutorial/" + nombrePagina);
						SpriteRenderer renderer = paginaVista.GetComponent<SpriteRenderer>();
						renderer.sprite = sprite;
					}
					else
					{
						SpriteRenderer renderer = flechaAdelante.GetComponent<SpriteRenderer>();
						renderer.sprite = null;
					}
					if (pagina == 6)
					{
						SpriteRenderer renderer = flechaAdelante.GetComponent<SpriteRenderer>();
						renderer.sprite = null;
					}
				}
				else if (hit.transform.name == "flecha_atras")
				{

					if (pagina != 1)
					{
						pagina--;
						if (pagina != 6)
						{
							Sprite spriteFlechaAdelante= Resources.Load<Sprite>("Sprites/Tutorial/flecha_adelante");
							SpriteRenderer rendererFlechaAtras = flechaAdelante.GetComponent<SpriteRenderer>();
							rendererFlechaAtras.sprite = spriteFlechaAdelante;
						}

						Sprite spriteFlecha = Resources.Load<Sprite>("Sprites/Tutorial/flecha_atras");
						SpriteRenderer rendererFlecha = flechaAtras.GetComponent<SpriteRenderer>();
						rendererFlecha.sprite = spriteFlecha;
						string nombrePagina = "tutorial_" + pagina;
						Sprite sprite = Resources.Load<Sprite>("Sprites/Tutorial/" + nombrePagina);
						SpriteRenderer renderer = paginaVista.GetComponent<SpriteRenderer>();
						renderer.sprite = sprite;
					}
					else
					{
						SpriteRenderer renderer = flechaAtras.GetComponent<SpriteRenderer>();
						renderer.sprite = null;
					}
					if (pagina == 1)
					{
						SpriteRenderer renderer = flechaAtras.GetComponent<SpriteRenderer>();
						renderer.sprite = null;
					}
				}
				else if (hit.transform.name == "Salir")
				{
					LoadScene();
				}
			}
		}
	}

	private void LoadScene()
	{
		SceneManager.LoadScene("MenuPrincipal", LoadSceneMode.Single);
	}
}
