using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicScript : MonoBehaviour
{
    private static GameMusicScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad (instance);
        }
        else
        {
            Destroy (gameObject);
        }
    }
}
