using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ArrowScript : MonoBehaviour
{
    public static ArrowScript instance;
    public GameObject arrow;
    public float arrowSpeed;
    Vector2 targetPos;
    Vector2 arrowPosition;
    
    float despawnTimer = 0.0f;
    float despawnTime = 5.0f;
    private void Awake()
    {
        instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    // Update is called once per frame
    void Update()
    {
        arrowPosition = new Vector2(transform.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(arrowPosition, targetPos, arrowSpeed * Time.deltaTime);
        despawnTimer += Time.deltaTime;
        if (targetPos == arrowPosition && despawnTimer > despawnTime )
        {
            Destroy(arrow);
        }
    }
}
