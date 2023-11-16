using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevelScript : MonoBehaviour
{
    UnityEngine.SceneManagement.Scene scene;
    char lastCharacterInString;
    int lastDigitInString;

    private GameObject player;
    private GameObject spawnBlock;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lastCharacterInString = scene.name[scene.name.Length - 1];
            lastDigitInString = lastCharacterInString - '0';
            lastDigitInString += 1;
            
            spawnBlock = GameObject.FindGameObjectWithTag("PlayerStartPositionBlock");
            Destroy(spawnBlock);
            spawnBlock = GameObject.FindGameObjectWithTag("PlayerStartPositionBlock");
            player.transform.position = spawnBlock.transform.position;
            SceneManager.LoadScene("GameLevelScene" + lastDigitInString, LoadSceneMode.Single);
        }
    }
}
