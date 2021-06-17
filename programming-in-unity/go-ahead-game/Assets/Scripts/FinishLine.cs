﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (GameManager.singleton.GameStarted && !GameManager.singleton.GamePaused)
            {
                GameManager.singleton.NextLevel();
            }
        }
    }
}
