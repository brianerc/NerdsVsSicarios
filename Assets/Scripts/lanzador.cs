using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class lanzador : MonoBehaviour {
    public GameObject estructura;
    private bool estado = false;
    public Grid matriz;
    private Image unIcono;

    // Use this for initialization
    void Start () {

        string ruta=Application.dataPath + "/Sprites/Lanzadores/" + estructura.name + ".png";
        unIcono.sprite = (Sprite)Resources.Load<Sprite>(ruta) as Sprite;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = unIcono.sprite;
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
                estado = true;
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
                else if (hit.transform.tag == "Piso")
                {
                    Vector3 punto = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
                    Vector3Int auxiliar = matriz.WorldToCell(punto);
                    punto = matriz.GetCellCenterWorld(auxiliar);
                    estructura.transform.position = punto;
                    Instantiate(estructura);
                }
                else
                {
                    Debug.Log("No se puede colocar fuera de la matriz");
                }
            }


        }
    }
}
