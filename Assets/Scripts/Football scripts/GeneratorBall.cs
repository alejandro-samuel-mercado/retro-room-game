using UnityEngine;


public class GeneratorBall : MonoBehaviour, IBallGenerator
{
    [SerializeField]
    //Indica el GameObject de la pelota
    private GameObject ballPrefab;
    //Indica la pelota actual
    private GameObject currentBall;
private IPositionProvider positionProvider;
   private ICommand generateBallCommand;

    void Start()
    { positionProvider = GetComponent<IPositionProvider>() ?? new DefaultPositionProvider(transform);
           generateBallCommand = new GenerateBallCommand(this);
        generateBallCommand.Execute();
    }
    public void GenerateBall()
    {
        // Si es que hay una pelota generada, la destruye
        if (currentBall != null)
        {
            Destroy(currentBall);
        }

        // Instancia una nueva pelota en donde se ubica el generador
            currentBall = Instantiate(ballPrefab, positionProvider.GetPosition(), transform.rotation);
    }
}


