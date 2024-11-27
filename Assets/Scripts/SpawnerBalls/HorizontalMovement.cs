using UnityEngine;
public class HorizontalMovement : IMovementStrateggy
{
    private float speedX;
    private float initialX;
    private float finalX;

    public HorizontalMovement(float speedX, float initialX, float finalX)
    {
        this.speedX = speedX;
        this.initialX = initialX;
        this.finalX = finalX;
    }

    public void Move(Transform transform)
    {
        transform.Translate(speedX * Time.deltaTime, 0, 0);

        if (transform.position.x <= finalX || transform.position.x >= initialX)
        {
            speedX *= -1;
        }
    }
}
