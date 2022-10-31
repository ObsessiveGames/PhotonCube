using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fpsText;
    private int averageFrameRate;

    public void Update()
    {
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        averageFrameRate = (int)current;
        fpsText.SetText($"FPS: {averageFrameRate}");
    }
}
