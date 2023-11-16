using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;

    int score;
    private void Awake()
    {
        instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Coins: " + score.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdatePoints(int coins)
    {
        score = coins;
        scoreText.text = "Coins: " + score.ToString();
    }
}
