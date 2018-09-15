using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour {

    public Text score;
    public Transform player;

	// Update score text

	void Update ()
    {
        if (!FindObjectOfType<GameManager>().gameOver)
        {
            score.text = player.position.z.ToString("0");
        }
	}
}
