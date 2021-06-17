using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetScoreResult : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    [SerializeField] string additionalText = "";

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = "";
    }

    void Update()
    {
        if (!GameManager.singleton.GameStarted)
            textMesh.text = additionalText + " " + GameManager.singleton.Score.ToString();
        else
            textMesh.text = "";
    }
}
