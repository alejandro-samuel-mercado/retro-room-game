using UnityEngine;

public class MoveCommand : ICommand
{
    private Rigidbody rb;
    private float velocity;

    public MoveCommand(Rigidbody rb, float velocity)
    {
        this.rb = rb;
        this.velocity = velocity;
    }

    public void Execute()
    {
        float movimientoX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(velocity * movimientoX * Time.deltaTime, rb.velocity.y, rb.velocity.z);
    }
}
