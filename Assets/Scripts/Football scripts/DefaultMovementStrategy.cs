
using UnityEngine;
// Estrategia por defecto de movimiento
public class DefaultMovementStrategy : IMovementStrategy
{
    public void Move(Transform transform, ref float changeDirectionX)
    {
        if (transform.position.x < -2.1f || transform.position.x > 2.3f)
        {
            changeDirectionX *= -1;
        }
        transform.Translate(changeDirectionX * Time.deltaTime, 0, 0);
    }
}
