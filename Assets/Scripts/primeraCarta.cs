using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class primeraCarta : MonoBehaviour {
    public GameObject primerEstructura;
    private bool estado = false;
    public Grid matriz;
	// Use this for initialization
	void Start () {
		
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
        if (touch.phase==TouchPhase.Ended && estado)
        {

            if(Physics.Raycast(ray,out hit))
            {
                if(hit.transform.tag=="Estructura")
                {
                    Debug.Log("No se puede colocar en donde ya hay una estructura");
                    return;
                }
            }
            estado = false;
            Vector3 punto = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
            Vector3Int auxiliar = matriz.WorldToCell(punto);
            punto = matriz.GetCellCenterWorld(auxiliar);
            primerEstructura.transform.position = punto;
            Instantiate(primerEstructura);
        }
    }
}
