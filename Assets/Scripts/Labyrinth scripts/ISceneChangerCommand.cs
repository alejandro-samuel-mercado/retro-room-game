using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ISceneChangerCommand: Command pattern para cambiar de escena
public interface ISceneChangerCommand
{
    void Execute();
}



// Observador para el cronómetro y notificación de eventos (Observer Pattern)
public interface ITimeObserver
{
    void OnTimeEnded();
}

// Estrategia para la posición del jugador
public interface IMoveStrategy
{
    void Mover(Rigidbody rb, float velocidad);
}
