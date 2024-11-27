using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PositionLimitChecker : MonoBehaviour, ILimitChecker
{
    [SerializeField] private float limiteX = -20f;

    public bool EstaFueraDeLimites(Vector3 posicion)
    {
        return posicion.x < limiteX;
    }
}
