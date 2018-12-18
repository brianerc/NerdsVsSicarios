using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transicion : MonoBehaviour
{
    public static string nombreEscena;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void CargarEscena()
    {
        SceneManager.LoadSceneAsync(nombreEscena);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
