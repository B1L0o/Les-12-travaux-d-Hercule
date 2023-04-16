using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float bulletSpeed;
    public int Damage;
    public Player _player;
    private Rigidbody2D rb;
    public GameObject explosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right*bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") || col.CompareTag("Tilemap"))
        {
            if (col.CompareTag("Player"))
            {
                StartCoroutine(_player.TakeDMG(Damage));

            }
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
       
    }
}
