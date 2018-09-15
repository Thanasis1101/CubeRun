using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour {

    public GameManager gameManager;

    void OnTriggerEnter(Collider collider)
    {
        // player reached finish line

        if (collider.name == "Player")
        {
            gameManager.CompleteLevel();
        }
    }
}
