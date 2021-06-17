using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetTimeResult : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    float minutes = 0;
    float seconds = 0;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = "";
        minutes = Mathf.FloorToInt(GameManager.singleton.playedTime/60);
        seconds = Mathf.FloorToInt(GameManager.singleton.playedTime % 60);
    }

    void Update()
    {
        if (!GameManager.singleton.GameStarted)
            textMesh.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        else
            textMesh.text = "";
    }
}
