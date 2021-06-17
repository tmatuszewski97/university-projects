using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMainMenu : MonoBehaviour
{
    public void BackToMenu()
    {
        GameManager.singleton.GoToMainMenu();
    }
}
