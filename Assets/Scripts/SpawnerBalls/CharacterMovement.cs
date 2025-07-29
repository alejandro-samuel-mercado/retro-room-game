using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float velocidad = -2000f;
    private Rigidbody rb;
    private ICommand moveCommand;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveCommand = new MoveCommand(rb, velocidad);
    }

    void Update()
    {
        moveCommand.Execute();
    }
   
}
