using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    
    public Transform[] waypoints;
    public float speed;
    private Transform target;
    private int index_next_target=0;
    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
        transform.Rotate(0,180,0,Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime,Space.World);
        if (Vector3.Distance(transform.position,target.position)<0.3f)
        {
            index_next_target = (index_next_target + 1) % waypoints.Length;
            target = waypoints[index_next_target];
            transform.Rotate(0,180,0,Space.World);
        }

    }
}
