using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IArbol {
    int GetCantidadDeNiveles();
    int GetCantidadDeHojasDelNivel(int nivel);
    //bool insertarHoja(IHoja hoja, int nivel);
    //bool hayEspacioEnElNivel(int nivel);
    List<IHoja> GetHojas();
    string GetNombre();
    string GetDescripcion();
    Sprite GetImagen();
}
