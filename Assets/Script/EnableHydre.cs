using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableHydre : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private int seuil;
    [SerializeField] private GameObject graphics;
    [SerializeField] private GameObject hydreHeathBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (graphics.activeInHierarchy == false && Vector2.Distance(transform.position,player.transform.position)<seuil)
        {
            hydreHeathBar.SetActive(true);
            graphics.SetActive(true);
        }
    }
}
