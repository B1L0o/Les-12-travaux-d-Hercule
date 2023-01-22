using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_player_ennemi3 : MonoBehaviour
{
    public float seuil_distance;
    public float speed;
    private bool is_already_lauch = false;
    
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("ennemi");
        GameObject projectile = GameObject.FindGameObjectWithTag("fireball");
        float distance = Vector3.Distance (transform.position, player.transform.position);
        Debug.Log(distance);
        if (distance<seuil_distance)
        {
            projectile.GetComponent<SpriteRenderer>().enabled = true;
            is_already_lauch = true;
        }
        if (is_already_lauch)
        {
            Vector3 direction = player.transform.position - transform.position;
            projectile.transform.Translate(direction.normalized * speed * Time.deltaTime,Space.World);
        }
    }
    
}
