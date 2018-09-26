using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHoja {
    bool esEstructura();
    bool esHabilidad();
    bool mejorarEstructura(IHoja estructura);
    bool mejorarHabilidad(IHoja habilidad);
    bool setNivel(int nivel);
    bool estaAprendida();
    void aprenderHoja();
    int getNivel();
    string getNombre();
    string getDescripcion();
    Sprite getImagen();

}
