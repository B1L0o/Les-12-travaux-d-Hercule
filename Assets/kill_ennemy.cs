using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill_ennemy : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ennemi"))
        {
             Destroy(   GameObject.FindGameObjectWithTag(other.tag).transform.parent.gameObject);
        }
    }
}
