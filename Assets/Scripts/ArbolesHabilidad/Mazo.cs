﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase padre correspondiente al arbol de habilidad. Esta clase es la responsable de gestionar las 
/// habilidades de los objetos del tablero. Es generica para todos los objetos del tablero. 
/// Se espera iterar sobre esta logica en la siguiente entrega. 
/// </summary>
abstract public class Mazo : MonoBehaviour {

    public List<Carta> mazo;
    protected string nombre;
    protected string descripcion;
    public GameObject lanzador;
    protected float posicionX;
    public float x;
    public float y;
    public float z;
    protected float danoBase;
    public float vidaBase;
    protected float tiempo;
    protected float tiempoBase;
    protected float vidaInicial;
    protected int energia;
    private int energiaMaxima;
    protected float tiempoRegeneracionEnergia;
    protected int cantidadRegeneracionEnergia;
    private float tiempoActualRegeneracionEnergia;

	public virtual void Update()
    {
        CalcularTiempoEnergia();
    }
    protected void CalcularTiempoEnergia()
    {
        tiempoActualRegeneracionEnergia -= Time.deltaTime;
        if (tiempoActualRegeneracionEnergia <= 0)
        {
            RegenerarEnergia();
            tiempoActualRegeneracionEnergia = tiempoRegeneracionEnergia;
        }
    }
    public virtual void Start()
    {
        vidaBase = 10;
        posicionX = GameObject.FindGameObjectWithTag("Opciones").GetComponent<Comenzar>().separacionLanzadores;
        Inicializar();
        vidaInicial = vidaBase;
        energiaMaxima = energia;
        tiempoActualRegeneracionEnergia = tiempoRegeneracionEnergia;
    }
    public void RegenerarEnergia()
    {
        energia += cantidadRegeneracionEnergia;
    }
    public int GetEnergia()
    {
        return energia;
    }

    public void QuitarEnergia(int cantEnergia)
    {
        energia = energia - cantEnergia;
    }

    protected virtual void MostrarLanzadores()
    {
        foreach (var carta in mazo)
        {
            lanzador.GetComponent<Lanzador>().estructura = carta.GetObjeto();
            Vector3 posicion;
            posicion.x = x;
            posicion.y = y;
            posicion.z = z;
            lanzador.GetComponent<Lanzador>().transform.position = posicion;
            x = x + posicionX;
            lanzador.GetComponent<Lanzador>().transform.tag = "Lanzador" + carta.GetNombre();
            Instantiate(lanzador);
        }
    }
    protected virtual GameObject CargarLanzador(int i, int j)
    {
        return null;
    }
    protected virtual void Inicializar()
    {

    }
    protected bool InsertarCarta(Carta carta)
    {
        try {
            mazo.Add(carta);
            return true;
        } catch
        {
            return false;
        }
    }
    public string GetNombre()
    {
        return nombre;
    }
    public string GetDescripcion()
    {
        return descripcion;
    }
    public Sprite GetImagen()
    {
        return null;
    }
    public virtual void Herir (float danoBase)
    {
        vidaBase = vidaBase - danoBase;
    }
    public float GetVida()
    {
        return vidaBase;
    }

}