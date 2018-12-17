using Assets.Scripts.ObjetosTablero.Proyectiles;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneVolador : Estructura
{
	public float tiempo;
	public AudioClip clip;
	public DroneElectrico_Bala bala;
	Vector3 balaPosicion;
	public float freqDeDisparo;
	public float siguienteDisparo;
	public float posicionY;
	public float posicionX;


	private Vector3 vector;
	private float startTime;
	private Vector3 posInicial;

	private int balaNum;

	//Se utilizan tres balas las cuales reutilizamos para no tener que estar creando y destruyendo cada una
	private DroneElectrico_Bala bala1;
	private DroneElectrico_Bala bala2;
	private DroneElectrico_Bala bala3;
	private Grid matriz;
	private Animator animator;

	private void Start()
	{
		animator = GetComponent<Animator>();
		matriz = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
		balaNum = 0;
		siguienteDisparo = Time.time + siguienteDisparo;
		vector = new Vector3(posicionX, posicionY, 0);
		posInicial = transform.position;
		balaPosicion = transform.position;
		balaPosicion += vector;

		//Se instancian solo una vez las 3 balas
		bala1 = Instantiate(bala, balaPosicion, Quaternion.identity);
		bala2 = Instantiate(bala, balaPosicion, Quaternion.identity);
		bala3 = Instantiate(bala, balaPosicion, Quaternion.identity);

		bala1.transform.localScale = new Vector2(0, 0);
		bala2.transform.localScale = new Vector2(0, 0);
		bala3.transform.localScale = new Vector2(0, 0);
	}

	private void FixedUpdate()
	{
		tiempo = tiempo - Time.deltaTime;
		Vector3Int auxiliar = matriz.WorldToCell(this.transform.position);
		if (Filas.HaySicarioEnFila(auxiliar.y))
		{
			animator.SetBool("tiene_enemigo_en_fila", true);
		}
		else
		{
			animator.SetBool("tiene_enemigo_en_fila", false);
		}
	}

	//Metodo que se llama desde la animacion de la catapulta. Esto es para que la catapulta dispare justo
	//cuando lo hace en la animacion. De esta forma optimizamos el momento de disparo
	private void Fire()
	{
		switch (balaNum)
		{
			case 0:
				bala1.transform.localScale = new Vector2(1, 1);
				bala1.transform.position = balaPosicion;
				bala1.empezarAMoverse = true;
				bala1.EmpezarAMoverse();
				bala1.PosicionarInicio(balaPosicion);
				break;
			case 1:
				bala2.transform.localScale = new Vector2(1, 1);
				bala2.transform.position = balaPosicion;

				bala2.empezarAMoverse = true;
				bala2.EmpezarAMoverse();
				bala2.PosicionarInicio(balaPosicion);
				break;
			case 2:
				bala3.transform.localScale = new Vector3(1, 1);
				bala3.transform.position = balaPosicion;
				bala3.empezarAMoverse = true;
				bala3.EmpezarAMoverse();
				bala3.PosicionarInicio(balaPosicion);
				break;
		}
		balaNum = ++balaNum % 2;
	}

	private void Destruirse()
	{
		Destroy(bala1.gameObject);
		Destroy(bala2.gameObject);
		Destroy(bala3.gameObject);
		Destroy(this.gameObject);
	}

	private void ReproducirSonido()
	{
		AudioSource audio = this.gameObject.GetComponent<AudioSource>();
		audio.PlayOneShot(audio.clip);
	}
}
