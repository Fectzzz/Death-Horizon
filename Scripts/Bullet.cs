using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Utilisation d'un switch pour traiter les collisions de manière plus concise
        switch (collision.gameObject.tag)
        {
            case "Mur":
            case "Ennemi":
            case "Coin":
            case "Potion":
                Destroy(gameObject);
                break;
        }
    }
}

