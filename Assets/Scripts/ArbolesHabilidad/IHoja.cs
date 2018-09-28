using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHoja {
    bool EsEstructura();
    bool EsHabilidad();
    bool MejorarEstructura(IHoja estructura);
    bool MejorarHabilidad(IHoja habilidad);
    bool SetNivel(int nivel);
    bool EstaAprendida();
    void AprenderHoja();
    int GetNivel();
    string GetNombre();
    string GetDescripcion();
    Sprite GetImagen();

}
