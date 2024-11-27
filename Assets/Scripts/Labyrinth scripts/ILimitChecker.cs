using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public interface ILimitChecker
{
    bool EstaFueraDeLimites(Vector3 posicion);
}

