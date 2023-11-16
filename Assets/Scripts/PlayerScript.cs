using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;

    public Rigidbody2D rb;
    public int coins;
    public int hearts;
    Vector2 movement;
    public float speed = 5;
    
    public GameObject arrow;
    public float arrowCooldown = 1.0f;
    float arrowTimer = 0.0f;
    public int arrowDamage = 1;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
    
    }
    void ProcessInputs()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetButtonDown("Jump")) {
            TextBoxManager.instance.NextPage();
        }
        arrowTimer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && arrowTimer > arrowCooldown)
        {
            arrowTimer = 0.0f;
            Attack();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Death();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            collision.gameObject.SetActive(false);
            coins += 1;
            ScoreManager.instance.UpdatePoints(coins);
        }
    }
    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Move();
        UpdateYAxis();
        ScoreManager.instance.UpdatePoints(coins);
    }
    void Move()
    {
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
        if (movement.x > 0) { transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); }
        else if (movement.x < 0) { transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0)); }
    }
    void UpdateYAxis()
    {
        if (MentorScript.instance != null)
        {
            if (transform.position.y > MentorScript.instance.yAxis)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 1);
            }
            else if (transform.position.y < MentorScript.instance.yAxis)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -1);
            }
        }
    }
    public void Attack()
    {
        Vector2 objectPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetPos = mousePos;

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        arrow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        mousePos.x = mousePos.x + objectPos.x;
        mousePos.y = mousePos.y + objectPos.y;

        Vector2 arrowPosition = new Vector2(objectPos.x, objectPos.y);
        Instantiate(arrow, arrowPosition, arrow.transform.rotation);
    }
    public void Death()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("GameOverScene");
        coins = 0;
        ScoreManager.instance.UpdatePoints(coins);
    }
}
