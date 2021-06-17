using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioSource music = null;
    [SerializeField] int delay = 2;

    void Start()
    {
        music.PlayDelayed(delay);
    }

    void Update()
    {
        if (!GameManager.singleton.GameStarted)
        {
            music.Stop();
        }
    }
}
