using System.Collections;
using System.Collections.Generic;
using UnityEngine;
abstract public class Lanzador : MonoBehaviour {
    public GameObject estructura;
    protected bool estado = false;
    public Grid matriz;
    protected GameObject planoPosicion;
    protected Color verde;
    protected Color rojo;
    protected Color transparente;
    protected GameObject piso;
    public Arbol jugador;
    protected ObjetoTablero objetoTablero;
    // Use this for initialization
    public virtual void Start() {
        CargarSprite();
        piso = GameObject.FindGameObjectWithTag("Piso");
        verde = new Color(0, 1, 0, 0.5f);
        rojo = new Color(1, 0, 0, 0.5f);
        transparente = new Color(0, 0, 0, 0);
        objetoTablero = estructura.GetComponent<ObjetoTablero>();
    }

    // Update is called once per frame
    
    void Update () {
        RaycastHit hit;
        if (Input.touchCount < 1)
        {
            return;
        }
        Touch touch = Input.GetTouch(0);
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        if (touch.phase == TouchPhase.Began)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == this.gameObject.tag)
                {
                    estado = true;
                    CrearSeleccion(touch);
                    ActualizarPosicion(touch);
                    ActualizarColorSeleccion(planoPosicion, hit);
                }
            }
        }
        if(touch.phase==TouchPhase.Moved && estado)
        {
            if(Physics.Raycast(ray,out hit))
            {
                if(hit.transform.tag == "Piso")
                {
                    GameObject.FindGameObjectWithTag("Seleccion").transform.position = ActualizarPosicion(touch);
                    ActualizarColorSeleccion(GameObject.FindGameObjectWithTag("Seleccion"), hit);
                }
				if (hit.transform.tag == "Estructura")
				{
					ActualizarColorSeleccion(GameObject.FindGameObjectWithTag("Seleccion"), hit);
				}
            }
        }
        if (touch.phase == TouchPhase.Ended && estado)
        {
            estado = false;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == estructura.tag)
                {
                    Debug.Log("No se puede colocar en donde ya hay una estructura");
                }
                else if (hit.transform.tag == "Piso" )
                {
                    ColocarEstructura(touch);
                }
                else
                {
                    Debug.Log("No se puede colocar fuera de la matriz: " + hit.transform.tag);
                }
            }
            Destroy(GameObject.FindGameObjectWithTag("Seleccion"));
        }
        TouchCancelado(touch);
    }
    protected void ColocarEstructura(Touch touch)
    {
        if (jugador.GetEnergia() >= objetoTablero.GetEnergia())
        {
            estructura.transform.position = ActualizarPosicion(touch);
            AnimarNerd();
            GameObject nuevaEstructura = estructura;
            Instantiate(nuevaEstructura);
            jugador.QuitarEnergia(objetoTablero.GetEnergia());
        }
    }
    protected virtual Vector3 ActualizarPosicion(Touch touch)
    {
        Vector3 punto = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
        Vector3Int auxiliar = matriz.WorldToCell(punto);
        punto = matriz.GetCellCenterWorld(auxiliar);
        return punto;
    }
    private void CargarSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Lanzadores/" + estructura.name);
    }
    protected void CrearSeleccion(Touch touch)
    {
        planoPosicion = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Vector3 escala = new Vector3(0.6f, 0.6f, 0);
        planoPosicion.transform.localScale = escala;
        planoPosicion.transform.position = ActualizarPosicion(touch);
        planoPosicion.tag = "Seleccion";
        Destroy(planoPosicion.GetComponent<BoxCollider>());
        planoPosicion.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materiales/Selector");
        planoPosicion.GetComponent<MeshRenderer>().material.color = transparente;
    }
    protected void ActualizarColorSeleccion(GameObject planoPosicion,RaycastHit hit)
    {
        MeshRenderer renderer = planoPosicion.GetComponent<MeshRenderer>();
        renderer.material.color=transparente;
        if (hit.transform.tag == estructura.tag)
        {
            renderer.material.color = rojo;
        }
        else if (hit.transform.tag == "Piso")
        {
            renderer.material.color = verde;
        }
        else
        {
			renderer.material.color = transparente;
			//renderer.material.color = rojo;
		}
    }
    protected void TouchCancelado(Touch touch)
    {
        if (touch.phase == TouchPhase.Canceled)
        {
            if (GameObject.FindGameObjectsWithTag("Seleccion") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("Seleccion"));
            }
        }
    }
    protected virtual void AnimarNerd()
    {
        GameObject.FindGameObjectWithTag("Nerd").GetComponent<Animator>().SetTrigger("invocar");
    }
}
