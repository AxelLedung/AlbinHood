using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject coin;
    private GameObject player;

    public int maxHealth = 3;
    public int currentHealth;

    float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
    // Update is called once per frame
    void Update()
    {
        CheckAlive();
        Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        { 
            TakeDamage(PlayerScript.instance.arrowDamage);
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
    void CheckAlive()
    {
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        Instantiate(coin, transform.position, coin.transform.rotation);
        Destroy(this.gameObject);
    }
    void Move()
    {
        if (player != null)
        {
            rb.transform.position = Vector2.MoveTowards(rb.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
