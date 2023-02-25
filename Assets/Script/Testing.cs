using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    private Pathfinding pathfinding;
    private GameObject player;
    private GameObject enn;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enn = GameObject.FindWithTag("Finish");
        pathfinding = new Pathfinding(15, 15,Vector3.zero);
        List<PathNode> path = pathfinding.FindPath(0, 0, 2, 8);
        
    }

    // Update is called once per frame
    void Update()
    {
        List<PathNode> path = pathfinding.FindPath( (int)enn.transform.position.x, (int)enn.transform.position.y, (int)player.transform.position.x, (int)player.transform.position.y);
        foreach (var node in path)
        {
            enn.transform.position = Vector3.MoveTowards(enn.transform.position, new Vector3(node._x, node._y),Time.deltaTime);
        }
    }
}
