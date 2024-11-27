using UnityEngine;

// Strategy para el movimiento del Goalkeeper
public interface IMovementStrategy
{
    void Move(Transform transform, ref float changeDirectionX);
}

