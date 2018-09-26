using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITGuy : MonoBehaviour, IArbol {

    public IHoja[,] arbol;
    private string nombre;
    private string descripcion;
	// Use this for initialization
	void Start () {
        arbol = new IHoja[5,3];
        nombre = "IT Guy";
        descripcion = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int getCantidadDeNiveles()
    {
        return arbol.GetLength(1);
    }
    public int getCantidadDeHojasDelNivel(int nivel)
    {
        return arbol.GetLength(0);
    }
    public bool insertarHoja(IHoja hoja, int nivel)
    {
        for (int i = 0; i< arbol.GetLength(nivel); i++)
        {
            if (arbol.GetValue(nivel,i)==null)
            {
                arbol.SetValue(hoja,nivel,i);
                return true;
            }
        }
        return false;
    }
    public bool hayEspacioEnElNivel(int nivel)
    {
        for (int i = 0; i < arbol.GetLength(nivel); i++)
        {
            if (arbol.GetValue(nivel, i) == null)
            {
                return true;
            }
        }
        return false;
    }
    public List<IHoja> getHojas()
    {
        return new List<IHoja>();
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
