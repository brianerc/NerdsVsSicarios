using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IArbol {
    int getCantidadDeNiveles();
    int getCantidadDeHojasDelNivel(int nivel);
    bool insertarHoja(IHoja hoja, int nivel);
    bool hayEspacioEnElNivel(int nivel);
    List<IHoja> getHojas();
    string getNombre();
    string getDescripcion();
    Sprite getImagen();
}
