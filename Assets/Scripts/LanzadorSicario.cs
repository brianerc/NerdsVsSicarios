using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LanzadorSicario : MonoBehaviour
{
    public GameObject sicario;
    private bool estado = false;
    public Grid matriz;
    private GameObject planoPosicion;
    private Color verde;
    private Color rojo;
    private Color transparente;
    // Use this for initialization
    void Start()
    {
        CargarSprite();
        verde = new Color(0, 1, 0, 0.5f);
        rojo = new Color(1, 0, 0, 0.5f);
        transparente = new Color(0, 0, 0, 0);

    }

    // Update is called once per frame

    void Update()
    {
        RaycastHit hit;
        if (Input.touchCount < 1)
        {
            return;
        }
        Touch touch = Input.GetTouch(0);
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        if (touch.phase == TouchPhase.Began)
        {
            Debug.Log(this.gameObject.transform.tag);
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
        if (touch.phase == TouchPhase.Moved && estado)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Piso")
                {
                    GameObject.FindGameObjectWithTag("Seleccion").transform.position = ActualizarPosicion(touch);
                    ActualizarColorSeleccion(GameObject.FindGameObjectWithTag("Seleccion"), hit);
                }
            }
        }
        if (touch.phase == TouchPhase.Ended && estado)
        {
            estado = false;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == sicario.tag)
                {
                    Debug.Log("No se puede colocar en donde ya hay una estructura");
                }
                else if (hit.transform.tag == "Piso")
                {
                    sicario.transform.position = ActualizarPosicion(touch);
                    Instantiate(sicario);
                }
                else
                {
                    Debug.Log("No se puede colocar fuera de la matriz: " + hit.transform.tag);
                }
            }
            Destroy(GameObject.FindGameObjectWithTag("Seleccion"));
        }
        if (touch.phase == TouchPhase.Canceled)
        {
            if (GameObject.FindGameObjectsWithTag("Seleccion") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("Seleccion"));
            }
        }
    }
    private Vector3 ActualizarPosicion(Touch touch)
    {
        Vector3 punto = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
        Vector3Int auxiliar = matriz.WorldToCell(punto);
        punto = matriz.GetCellCenterWorld(auxiliar);
        return punto;
    }
    private void CargarSprite()
    {
        Debug.Log(sicario.name);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Lanzadores/" + sicario.name);
    }
    private void CrearSeleccion(Touch touch)
    {
        planoPosicion = GameObject.CreatePrimitive(PrimitiveType.Cube);
        planoPosicion.transform.position = ActualizarPosicion(touch);
        planoPosicion.tag = "Seleccion";
        Destroy(planoPosicion.GetComponent<BoxCollider>());
        planoPosicion.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materiales/Selector");
        //planoPosicion.transform.localScale = new Vector3(1.2f, 1.2f, 0);

        planoPosicion.GetComponent<MeshRenderer>().material.color = transparente;
    }
    private void ActualizarColorSeleccion(GameObject planoPosicion, RaycastHit hit)
    {
        MeshRenderer renderer = planoPosicion.GetComponent<MeshRenderer>();
        renderer.material.color = transparente;
        if (hit.transform.tag == sicario.tag)
        {
            renderer.material.color = rojo;
        }
        else if (hit.transform.tag == "Piso")
        {
            renderer.material.color = verde;
        }
        else
        {
            renderer.material.color = rojo;
        }
    }
}
