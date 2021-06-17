using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetTitle : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.singleton.GamePaused)
            textMesh.text = "Poziom " + (GameManager.singleton.Level);
        else if (GameManager.singleton.YouLose)
            textMesh.text = "Przegrałeś!";
        else
            textMesh.text = "";
    }
}
