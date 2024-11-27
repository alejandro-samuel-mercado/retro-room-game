
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public interface ISortStrategy
{
    IEnumerator Sort(int[] numbers, Transform[] characters, TextMeshProUGUI[] numberLabels, float moveSpeed, TextMeshProUGUI methodLabel);
}

