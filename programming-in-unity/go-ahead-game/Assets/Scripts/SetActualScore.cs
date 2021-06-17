using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetActualScore : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = "";
    }

    void Update()
    {
        if (GameManager.singleton.GameStarted)
            textMesh.text = "Punkty: " + GameManager.singleton.Score;
        else
            textMesh.text = "";
    }
}
