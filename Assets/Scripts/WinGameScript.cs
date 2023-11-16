using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinGameScript : MonoBehaviour
{
    public TextMeshProUGUI winText;
    public Button restartGameButton;
    public TextAsset textFile;
    public string[] textLines;
    public int coins;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(false);
        coins = PlayerScript.instance.coins;
        restartGameButton.onClick.AddListener(RestartGameButtonClick);
        if (coins < 15)
        {
            winText.text = "F�r in i helvete �r du dum i huvudet. \n" + coins + " mynt �r det du lyckades skramla ihop? \nJag vet att du lyckades hitta mer mynt �n s�, vad spenderade du det p�?";
        }
        else
        {
            winText.text = "Grattis och bra jobbat! \nDu lyckades samla ihop " + coins + " mynt �t Halmstad folket bra jobbat!";
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void RestartGameButtonClick()
    {
        Destroy(player);
        SceneManager.LoadScene("StartMenuScene");
    }
}
