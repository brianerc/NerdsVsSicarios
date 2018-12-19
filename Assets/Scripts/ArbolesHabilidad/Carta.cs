using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase responsables de mantener las hojas de habilidad de los personajes. Iteraremos en la segunda entrega
/// sobre esta clase. Se espera en la misma mantener la logica al desbloqueo de habilidades y especializacion
/// de las cartas
/// </summary>
abstract public class Carta {
    protected int nivel;
    protected bool aprendida;
    protected string nombre;
    protected string descripcion;
    protected int vida;
    protected GameObject objeto;

    public virtual bool EsEstructura()
    {
        return true;
    }
    public virtual bool EsHabilidad()
    {
        return false;
    }
    public bool MejorarEstructura(Carta estructura)
    {
        return false;
    }
    public bool MejorarHabilidad(Carta habilidad)
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
    public void SetVida(float nuevaVida)
    {
        objeto.GetComponent<ObjetoTablero>().SetVida(nuevaVida);
    }
    public void SetDano(float dano)
    {
        objeto.GetComponent<ObjetoTablero>().danoBase=dano;
    }
}
