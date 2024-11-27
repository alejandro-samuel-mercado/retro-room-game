using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallPool : MonoBehaviour
{
    
    public static BallPool Instance { get; private set; }

    [SerializeField]
    private GameObject ballPrefab;

    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject GetBall(Vector3 position)
    {
        GameObject ball;
        if (pool.Count > 0)
        {
            ball = pool.Dequeue();
            ball.SetActive(true);
        }
        else
        {
            ball = Instantiate(ballPrefab);
        }

        // Colocar la pelota en la posición del spawner
        ball.transform.position = position;
        return ball;
    }

    public void ReturnBall(GameObject ball)
    {
        ball.SetActive(false);
        pool.Enqueue(ball);
    }
}
