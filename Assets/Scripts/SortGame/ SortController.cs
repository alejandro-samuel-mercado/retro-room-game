using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SortController : MonoBehaviour
{
    public Transform[] characters;
    public TextMeshProUGUI[] numberLabels;
    public Button optionButton1;
    public Button optionButton2;
    public TextMeshProUGUI methodLabel;
    public TextMeshProUGUI scoreLabel;
    public float moveSpeed = 2f;

    private int score = 0;
    private int[] numbers;
    private bool isSorted = false;

    private ISortStrategy sortStrategy;

    private void Start()
    {
        AssignRandomNumbers();
        UpdateNumberLabels();
        PresentOptions();

        sortStrategy = new SelectionSortStrategy(this);
    }



    private void AssignRandomNumbers()
    {
        numbers = new int[characters.Length];
        List<int> availableNumbers = new List<int>();
        for (int i = 1; i <= characters.Length; i++)
        {
            availableNumbers.Add(i);
        }

        for (int i = 0; i < characters.Length; i++)
        {
            int randomIndex = Random.Range(0, availableNumbers.Count);
            numbers[i] = availableNumbers[randomIndex];
            availableNumbers.RemoveAt(randomIndex);
        }
    }

    private void UpdateNumberLabels()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            numberLabels[i].text = numbers[i].ToString();
        }
    }

    private void PresentOptions()
    {
       
    if (isSorted) return;

    int correctIndex1 = -1;
    int correctIndex2 = -1;
    for (int i = 0; i < numbers.Length - 1; i++)
    {
        if (numbers[i] > numbers[i + 1])
        {
            correctIndex1 = i;
            correctIndex2 = i + 1;
            break;
        }
    }

    if (correctIndex1 == -1)
    {
        isSorted = true;
        methodLabel.text = "Ordenado!";
        StartCoroutine(ShuffleAndSort());
        
        // Desactivar el puntaje al terminar la ordenación manual
        scoreLabel.text = "";  
        scoreLabel.gameObject.SetActive(false);  

        return;
    }

    // Generar opciones incorrectas aleatorias
    int otherIndex1, otherIndex2;
    do
    {
        otherIndex1 = Random.Range(0, numbers.Length - 1);
        otherIndex2 = otherIndex1 + 1;
    } while ((otherIndex1 == correctIndex1 && otherIndex2 == correctIndex2) ||
             (otherIndex1 == correctIndex2 && otherIndex2 == correctIndex1));

    bool correctFirst = Random.value > 0.5f;

    if (correctFirst)
    {
        SetOptionButton(optionButton1, correctIndex1, correctIndex2, true);
        SetOptionButton(optionButton2, otherIndex1, otherIndex2, false);
    }
    else
    {
        SetOptionButton(optionButton1, otherIndex1, otherIndex2, false);
        SetOptionButton(optionButton2, correctIndex1, correctIndex2, true);
    }
    }

    private void SetOptionButton(Button button, int index1, int index2, bool isCorrect)
    {
        button.onClick.RemoveAllListeners();
        button.GetComponentInChildren<TextMeshProUGUI>().text = $"Intercambiar {numbers[index1]} y {numbers[index2]}";

        if (isCorrect)
        {
            button.onClick.AddListener(() => StartCoroutine(PerformSwap(index1, index2)));
        }
        else
        {
            button.onClick.AddListener(() => IncorrectSelection());
        }
    }

    public IEnumerator PerformSwap(int index1, int index2)
{
    methodLabel.text = "";

    // Realiza el intercambio en los números
    int tempNumber = numbers[index1];
    numbers[index1] = numbers[index2];
    numbers[index2] = tempNumber;

    // Realiza el intercambio de posiciones en los objetos transform
    Vector3 startPos1 = characters[index1].position;
    Vector3 startPos2 = characters[index2].position;

    float t = 0;
    while (t < 1)
    {
        t += Time.deltaTime * moveSpeed;
        characters[index1].position = Vector3.Lerp(startPos1, startPos2, t);
        characters[index2].position = Vector3.Lerp(startPos2, startPos1, t);
        yield return null;
    }

    // Intercambio visual de los personajes
    Transform tempCharacter = characters[index1];
    characters[index1] = characters[index2];
    characters[index2] = tempCharacter;

    // Intercambio de los textos
    TextMeshProUGUI tempLabel = numberLabels[index1];
    numberLabels[index1] = numberLabels[index2];
    numberLabels[index2] = tempLabel;

    UpdateNumberLabels();
    score++;
    scoreLabel.text = "Puntaje: " + score;

    PresentOptions();
}



    private void IncorrectSelection()
    {
        methodLabel.text = "Opción incorrecta. Intenta de nuevo.";
        score--;
if(score<0){
 SceneManager.LoadScene("GameOver");
}
        scoreLabel.text = "Puntaje: " + score;

        StartCoroutine(HideIncorrectMessage());
    }

    private IEnumerator HideIncorrectMessage()
    {
        yield return new WaitForSeconds(2f);
        methodLabel.text = "";
    }

    private IEnumerator ShuffleAndSort()
    {
        AssignRandomNumbers();
        UpdateNumberLabels();

        yield return new WaitForSeconds(1f);

      
        yield return StartCoroutine(sortStrategy.Sort(numbers, characters, numberLabels, moveSpeed, methodLabel));

 SceneManager.LoadScene("YouWin");

    }
}



