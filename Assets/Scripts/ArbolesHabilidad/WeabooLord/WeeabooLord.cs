using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeeabooLord : MonoBehaviour, IArbol {

    public IHoja[][] arbol;
    private string nombre;
    private string descripcion;
    public GameObject catapulta;
    public GameObject lanzador;
    public GameObject dakimakura;
    public GameObject mochilaPegajosa;
    public float x;
    public float y;
    public float z;
	// Use this for initialization
	void Start () {
        arbol = new IHoja[5][];
        nombre = "Weeaboo Lord";
        descripcion = "";
        for (int i = 0; i < arbol.Length; i++)
        {
            if (i == 0)
            {
                arbol[i] = new IHoja[6];
            } else
            {
                arbol[i] = new IHoja[0];
            }
        }
        InsertarHoja(new HojaCatapulta(catapulta), 0);
        InsertarHoja(new HojaDakimakura(dakimakura), 0);
        InsertarHoja(new HojaMochilaPegajosa(mochilaPegajosa), 0);
        MostrarLanzadores();

    }

    // Update is called once per frame
    void Update () {

	}

    private void MostrarLanzadores()
    {
        for (int i =0;i<arbol.Length;i++) {
            for (int j = 0; j < arbol[i].Length; j++){
                if(arbol[i][j]==null)
                {
                    
                }
                else if (arbol[i][j].EsEstructura())
                {
                    GameObject nuevoLanzador=Instantiate(lanzador);
                    GameObject estructura = Resources.Load("Prefabs/Estructuras/"+arbol[i][j].GetNombre(), typeof(GameObject)) as GameObject;
                    Lanzador scriptLanzador = nuevoLanzador.GetComponent<Lanzador>();
                    scriptLanzador.estructura = estructura;
                    Vector3 posicion;
                    posicion.x = x;
                    posicion.y = y;
                    posicion.z = z;
                    nuevoLanzador.transform.position=posicion;
                    ComienzoPartida opciones = GameObject.FindGameObjectWithTag("Opciones").GetComponent<ComienzoPartida>();
                    x = x + opciones.separacionLanzadores;
                    nuevoLanzador.transform.tag = "Lanzador"+arbol[i][j].GetNombre();
                }
            }
        }
    }

    public int GetCantidadDeNiveles()
    {
        return arbol.Length;
    }
    public int GetCantidadDeHojasDelNivel(int nivel)
    {
        return arbol[nivel].Length;
    }
    private bool InsertarHoja(IHoja hoja, int nivel)
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
    private bool HayEspacioEnElNivel(int nivel)
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
    public List<IHoja> GetHojas()
    {
        return new List<IHoja>();
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