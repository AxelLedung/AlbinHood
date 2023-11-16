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
            winText.text = "För in i helvete är du dum i huvudet. \n" + coins + " mynt är det du lyckades skramla ihop? \nJag vet att du lyckades hitta mer mynt än så, vad spenderade du det på?";
        }
        else
        {
            winText.text = "Grattis och bra jobbat! \nDu lyckades samla ihop " + coins + " mynt åt Halmstad folket bra jobbat!";
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
