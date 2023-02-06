using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GameTimer : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    public float Time { get; private set; } = 0f;

    public static string FormatTime(TimeSpan time)
    {
        return string.Format("{0:0}:{1:00}.{2:000}", time.Minutes, time.Seconds, time.Milliseconds);
    }

    public void Restart()
    {
        Time = 0f;
    }

    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        Time += UnityEngine.Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(Time);
        textMesh.text = FormatTime(time);
    }
}
