using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HojaMochilaPegajosa : IHoja {
    private int nivel;
    private string nombre;
    private string descripcion;
    private double dañoBase;
    private double cd;
    private double vida;
    private bool aprendida;
    private GameObject objeto;
    // Use this for initialization
    public HojaMochilaPegajosa(GameObject unObjeto)
    {
        nivel = 1;
        nombre = "Mochila pegajosa";
        descripcion = "";
        dañoBase = 2;
        cd = 2.5;
        vida = 3;
        aprendida = true;
        objeto = unObjeto;
    }

    public bool EsEstructura()
    {
        return true;
    }
    public bool EsHabilidad()
    {
        return false;
    }
    public bool MejorarEstructura(IHoja estructura)
    {
        return false;
    }
    public bool MejorarHabilidad(IHoja habilidad)
    {
        return false;
    }
    public bool SetNivel(int unNivel)
    {
        nivel = unNivel;
        return unNivel == nivel;
    }
    public bool EstaAprendida()
    {
        return aprendida;
    }
    public void AprenderHoja()
    {
        aprendida = true;
    }
    public int GetNivel()
    {
        return nivel;
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
}