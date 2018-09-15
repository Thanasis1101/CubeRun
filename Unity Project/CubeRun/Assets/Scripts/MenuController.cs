using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public Text controlsText;

	void Start () {
        if (Application.platform == RuntimePlatform.Android)
        {
            controlsText.text = "Controls:\nMove Left: Touch left side of screen\nMove Right: Touch right side of screen\nJump: Swipe up";
        }
    }

    public void PlayButtonClicked()
    {
        SceneManager.LoadScene(1);
    }

}
