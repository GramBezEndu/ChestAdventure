using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GameTimer : MonoBehaviour
{
    float currentTime = 0f;

    TextMeshProUGUI textMesh;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        textMesh.text = string.Format("{0:0}:{1:00}.{2:000}", time.Minutes, time.Seconds, time.Milliseconds);
    }
}
