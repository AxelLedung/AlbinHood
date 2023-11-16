using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    public static TextBoxManager instance;

    public GameObject textBox;
    public GameObject shopBox;

    public TextMeshProUGUI theText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public PlayerScript player;
    private void Awake()
    {
        instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartMonologoue()
    {
        textBox.SetActive(true);
        theText.text = textLines[0];
        currentLine = 0;
    }
    public void ResetMonologue()
    {
        textBox.SetActive(false);
        currentLine = 0;
    }
    public void NextPage()
    {
        if (currentLine >= endAtLine)
        {
            textBox.SetActive(false);
            currentLine = 0;
        }
        else
        {
            currentLine += 1;
            theText.text = textLines[currentLine];
        }  
    }
    public void StartShop()
    {
        shopBox.SetActive(true);
    }
    public void ExitShop()
    {
        shopBox.SetActive(false);
    }
}