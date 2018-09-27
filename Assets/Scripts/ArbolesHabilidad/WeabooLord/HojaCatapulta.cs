using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapulta : IHoja {
    private int nivel;
    private string nombre;
    private string descripcion;
    private double dañoBase;
    private double cd;
    private double vida;
    private bool aprendida;
    private GameObject objeto;
    // Use this for initialization
	public Catapulta (GameObject unObjeto) {
        nivel = 1;
        nombre = "Drone";
        descripcion = "Este dispositivo hace poco daño, pero a gran velocidad.";
        dañoBase = 0.8;
        cd = 0.7;
        vida = 3;
        aprendida = false;
        objeto = unObjeto;
	}

    public bool esEstructura()
    {
        return true;
    }
    public bool esHabilidad()
    {
        return false;
    }
    public bool mejorarEstructura(IHoja estructura)
    {
        return false;
    }
    public bool mejorarHabilidad(IHoja habilidad)
    {
        return false;
    }
    public bool setNivel(int unNivel)
    {
        nivel = unNivel;
        return unNivel==nivel;
    }
    public bool estaAprendida()
    {
        return aprendida;
    }
    public void aprenderHoja()
    {
        aprendida = true;
    }
    public int getNivel()
    {
        return nivel;
    }
    public string getNombre()
    {
        return nombre;
    }
    public string getDescripcion()
    {
        return descripcion;
    }
    public Sprite getImagen()
    {
        return null;
    }
}
