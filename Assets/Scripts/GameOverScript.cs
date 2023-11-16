using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Button restartGameButton;
    // Start is called before the first frame update
    void Start()
    {
        restartGameButton.onClick.AddListener(RestartGameButtonClick);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void RestartGameButtonClick()
    {
        SceneManager.LoadScene("StartMenuScene");
    }
}

