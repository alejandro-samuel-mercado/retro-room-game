using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// IForceApplier para encapsular la aplicación de fuerza
public interface IForceApplier
{
    void ApplyForce(Vector3 direction, float force);
}


