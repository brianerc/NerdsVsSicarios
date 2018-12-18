﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.ServidorDTO;
using Assets.Servidor;
abstract public class FinalPartida : MonoBehaviour {
    public GameObject transicion;
    public static int cantidadExp;
    private string nombreEscena;
    void Start () {
	}
    private void LoadScene()
    {
        Transicion.nombreEscena = nombreEscena;
        transicion.GetComponent<Animator>().SetTrigger("Cerrar");
    }
    public void GanarPuntos()
    {
        StartCoroutine(Acciones.CambiarPuntos(cantidadExp));
    }
    void Update()
    {
        if (Input.touchCount < 1)
        {
            return;
        }
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Input.GetTouch(0).position);

        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
                nombreEscena = "MenuPrincipal";
                LoadScene();
        }
    }
}

