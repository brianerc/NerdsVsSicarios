using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Arbol : MonoBehaviour {
    public Hoja[][] arbol;
    protected string nombre;
    protected string descripcion;
    public GameObject lanzador;
    protected float posicionX;
    public float x;
    public float y;
    public float z;
    public virtual void Start()
    {
        posicionX = GameObject.FindGameObjectWithTag("Opciones").GetComponent<ComienzoPartida>().separacionLanzadores;
        Inicializar();
    }
    protected virtual void MostrarLanzadores()
    {
        for (int i = 0; i < arbol.Length; i++)
        {
            for (int j = 0; j < arbol[i].Length; j++)
            {
                if (arbol[i][j] == null)
                {

                }
                else if (arbol[i][j].EsEstructura())
                {
                    GameObject nuevoLanzador = Instantiate(lanzador);
                    GameObject estructura = CargarLanzador(i, j);
                    Lanzador scriptLanzador = nuevoLanzador.GetComponent<Lanzador>();
                    scriptLanzador.estructura = estructura;
                    Vector3 posicion;
                    posicion.x = x;
                    posicion.y = y;
                    posicion.z = z;
                    nuevoLanzador.transform.position = posicion;
                    x = x + posicionX;
                    nuevoLanzador.transform.tag = "Lanzador" + arbol[i][j].GetNombre();
                }
            }
        }
    }
    protected virtual GameObject CargarLanzador(int i, int j)
    {
        return null;
    }
    protected virtual void Inicializar()
    {

    }
    public int GetCantidadDeNiveles()
    {
        return arbol.Length;
    }
    public int GetCantidadDeHojasDelNivel(int nivel)
    {
        return arbol[nivel].Length;
    }
    protected bool InsertarHoja(Hoja hoja, int nivel)
    {
        for (int i = 0; i < arbol[nivel].Length; i++)
        {
            if (arbol[nivel][i] == null)
            {
                arbol[nivel][i] = hoja;
                return true;
            }
        }
        return false;
    }
    protected bool HayEspacioEnElNivel(int nivel)
    {
        for (int i = 0; i < arbol[nivel].Length; i++)
        {
            if (arbol[nivel][i] == null)
            {
                return true;
            }
        }
        return false;
    }
    public List<Hoja> GetHojas()
    {
        return new List<Hoja>();
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
