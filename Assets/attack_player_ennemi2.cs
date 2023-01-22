using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_player_ennemi2 : MonoBehaviour
{
    public float seuil_distance;
    public float speed;
    
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector3.Distance (transform.position, player.transform.position);
        if (distance<seuil_distance && distance>1)
        {
            gameObject.GetComponent<Patrol>().enabled = false;
            transform.position = Vector3.MoveTowards( transform.position,player.transform.position,speed*Time.deltaTime);
        }
    }
}
