using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour
{
    public Button startGameButton;
    public Button quitGameButton;
    // Start is called before the first frame update
    void Start()
    {
        startGameButton.onClick.AddListener(StartGameButtonClick);
        quitGameButton.onClick.AddListener(QuitGameButtonClick);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void StartGameButtonClick()
    {
        SceneManager.LoadScene("GameLevelScene0");
    }
    void QuitGameButtonClick()
    {

    }
}
