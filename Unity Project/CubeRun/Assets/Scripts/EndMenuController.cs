using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenuController : MonoBehaviour {

    public void PlayButtonClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButtonClicked()
    {
        Application.Quit();
    }
}
