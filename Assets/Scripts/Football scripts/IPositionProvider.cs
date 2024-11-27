using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Interfaz para proveer la posición donde se instanciará la pelota
public interface IPositionProvider
{
    Vector3 GetPosition();
}
