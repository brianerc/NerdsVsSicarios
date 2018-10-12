using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invocacion : MonoBehaviour {
    public GameObject estructura;
    public void Invocar()
    {
        Instantiate(estructura);
        Destroy(this.gameObject);
    }

}
