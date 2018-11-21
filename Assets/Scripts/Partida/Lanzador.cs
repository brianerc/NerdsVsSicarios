using Assets.Scripts.ObjetosTablero.Proyectiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
abstract public class Lanzador : MonoBehaviour
{
    public int filaQueSeEncuentra;
    public GameObject estructura;
    protected bool estado = false;
    public Grid matriz;
    public GameObject planoPosicion;
    protected Color verde;
    protected Color rojo;
    protected Color transparente;
    protected GameObject piso;
    public Mazo jugador;
    protected ObjetoTablero objetoTablero;
    public GameObject invocador;
    // Use this for initialization
    public virtual void Start()
    {
        CargarSprite();
        piso = GameObject.FindGameObjectWithTag("Piso");
        verde = new Color(0, 1, 0, 1);
        rojo = new Color(1, 0, 0, 1);
        transparente = new Color(0, 0, 0, 0);
        objetoTablero = estructura.GetComponent<ObjetoTablero>();
    }

    // Update is called once per frame

    void Update()
    {
        CambiarEstado();
        if (Input.touchCount < 1)
        {
            return;
        }
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Input.GetTouch(0).position);

        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            if (hit.collider && hit.collider.tag == this.gameObject.tag && EsSeleccionable())
            {
                estado = true;
                CrearSeleccion(touch);
                ActualizarPosicion(touch);
                ActualizarColorSeleccion(planoPosicion, hit);
            }
        }
        if (touch.phase == TouchPhase.Moved && estado)
        {
            if (hit.collider && hit.collider.tag == "Piso")
            {
                GameObject.FindGameObjectWithTag("Seleccion").transform.position = ActualizarPosicion(touch);
            }
            ActualizarColorSeleccion(GameObject.FindGameObjectWithTag("Seleccion"), hit);


        }
        if (touch.phase == TouchPhase.Ended && estado)
        {
            estado = false;

            if (hit.collider && hit.collider.tag == estructura.tag)
            {
                Debug.Log("No se puede colocar en donde ya hay una estructura");
            }
            else if (hit.collider && hit.collider.tag == "Piso")
            {
                ColocarEstructura(touch);
            }
            else if (hit.collider)
            {
                Debug.Log("No se puede colocar fuera de la matriz: " + hit.collider.tag);
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
            if (estructura.tag == "Sicario")
            {
                Filas.AgregarSicarioAFila(this.filaQueSeEncuentra);
            }
            GameObject nuevaEstructura = estructura;
            InstanciarInvocacion(nuevaEstructura, touch);
            InstanciarEstructura(nuevaEstructura);
            jugador.QuitarEnergia(objetoTablero.GetEnergia());
        }
    }
    protected virtual void InstanciarInvocacion(GameObject nuevaEstructura, Touch touch)
    {
        invocador.transform.position = ActualizarPosicion(touch);
        invocador.GetComponent<Invocacion>().estructura = nuevaEstructura;
        Instantiate(invocador);
    }
    protected virtual void InstanciarEstructura(GameObject nuevaEstructura)
    {

    }
    protected virtual Vector2 ActualizarPosicion(Touch touch)
    {
        Vector2 punto = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
        Vector3Int auxiliar = matriz.WorldToCell(punto);
        punto = matriz.GetCellCenterWorld(auxiliar);
        return punto;
    }
    private void CargarSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Partida/Lanzadores/" + estructura.GetComponent<ObjetoTablero>().nombre + " N" +  estructura.GetComponent<ObjetoTablero>().nivel);
    }
    protected void CrearSeleccion(Touch touch)
    {
        planoPosicion = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Vector3 escala = new Vector3(1, 1, 0);
        planoPosicion.transform.localScale = escala;
        planoPosicion.transform.position = ActualizarPosicion(touch);
        planoPosicion.tag = "Seleccion";
        Destroy(planoPosicion.GetComponent<BoxCollider>());
        planoPosicion.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materiales/Selector");
        planoPosicion.GetComponent<MeshRenderer>().material.color = transparente;
    }
    protected void ActualizarColorSeleccion(GameObject planoPosicion, RaycastHit2D hit)
    {
        MeshRenderer renderer = planoPosicion.GetComponent<MeshRenderer>();
        renderer.material.color = transparente;
        if (hit.collider && hit.collider.tag == estructura.tag)
        {
            renderer.material.color = rojo;
        }
        else if (hit.collider && hit.collider.tag == "Piso")
        {
            renderer.material.color = verde;
        }
        else
        {
            renderer.material.color = transparente;
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
    protected virtual bool EsSeleccionable()
    {
        if (jugador.GetEnergia() >= objetoTablero.GetEnergia())
        {
            return true;
        }
        return false;

    }
    protected virtual void CambiarEstado()
    {
        if (EsSeleccionable())
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Partida/Lanzadores/" + estructura.GetComponent<ObjetoTablero>().nombre + " N" + estructura.GetComponent<ObjetoTablero>().nivel);
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Partida/Lanzadores/Desactivados/" + estructura.GetComponent<ObjetoTablero>().nombre + " ByN N" + estructura.GetComponent<ObjetoTablero>().nivel);
        }
    }
    protected virtual void AnimarNerd()
    {
        GameObject.FindGameObjectWithTag("Nerd").GetComponent<Animator>().SetTrigger("invocar");
    }
}