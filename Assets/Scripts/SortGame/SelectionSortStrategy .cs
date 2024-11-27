

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine;

public class SelectionSortStrategy : ISortStrategy
{
    private SortController sortController;

    public SelectionSortStrategy(SortController controller)
    {
        sortController = controller;
    }

    public IEnumerator Sort(int[] numbers, Transform[] characters, TextMeshProUGUI[] numberLabels, float moveSpeed, TextMeshProUGUI methodLabel)
    {
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[j] < numbers[minIndex])
                {
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                yield return sortController.StartCoroutine(sortController.PerformSwap(i, minIndex));
            }
        }

        methodLabel.text = "Ordenado por selección!";
    }
}

