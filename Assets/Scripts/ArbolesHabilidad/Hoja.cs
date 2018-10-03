using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Hoja {
    protected int nivel;
    protected bool aprendida;
    protected string nombre;
    protected string descripcion;
    protected GameObject objeto;

    public virtual bool EsEstructura()
    {
        return true;
    }
    public virtual bool EsHabilidad()
    {
        return false;
    }
    public bool MejorarEstructura(Hoja estructura)
    {
        return false;
    }
    public bool MejorarHabilidad(Hoja habilidad)
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
    public GameObject GetObjeto()
    {
        return objeto;
    }
}
