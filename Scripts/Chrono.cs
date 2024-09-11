using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chrono : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    float elapsedTime;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int secondes = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, secondes);
    }
}
