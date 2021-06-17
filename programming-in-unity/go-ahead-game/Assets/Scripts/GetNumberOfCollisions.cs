using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetNumberOfCollisions : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = "";
    }

    void Update()
    {
        if (!GameManager.singleton.GameStarted)
            textMesh.text = GameManager.singleton.NumberOfCollisions.ToString();
        else
            textMesh.text = "";
    }
}
