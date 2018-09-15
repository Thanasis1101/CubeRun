using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMusicPlaying : MonoBehaviour {

    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(gameObject);
            created = true;
        }
    }
}
