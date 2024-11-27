using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Proveedor de posición por defecto
public class DefaultPositionProvider : IPositionProvider
{
    private Transform transform;

    public DefaultPositionProvider(Transform transform)
    {
        this.transform = transform;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}

