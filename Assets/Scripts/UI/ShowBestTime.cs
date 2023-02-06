using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ShowBestTime : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    public float Time { get; set; } = -1f;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        if (Time > 0f)
        {
            textMesh.text = "Best time: " + GameTimer.FormatTime(TimeSpan.FromSeconds(Time));
        }
        else
        {
            textMesh.text = "Best time: -";
        }
    }
}
