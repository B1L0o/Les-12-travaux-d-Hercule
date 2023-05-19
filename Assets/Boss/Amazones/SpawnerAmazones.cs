using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerAmazones : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] 
    private GameObject amazonePrefab;
    [SerializeField] 
    private Player player;
    private List<GameObject> listAmazonesAlive;
    public void SpawnRandomAmazon()
    {
        GameObject amazone = Instantiate(amazonePrefab);
        Amazone amazoneObject = amazone.GetComponent<Amazone>();
        amazoneObject.Damage = Random.Range(1,3);
        amazoneObject._speed = Random.Range(3f,6f);
        amazoneObject._player = player;
        amazone.SetActive(true);
        listAmazonesAlive.Add(amazone);
    }

    private void Start()
    {
        listAmazonesAlive = new List<GameObject>();
    }

    public List<GameObject> SpawnAmazones(int numberofAmazoneToSpawn)
    {
        for (int i = 0; i < numberofAmazoneToSpawn; i++)
        {
            SpawnRandomAmazon();
        }

        return listAmazonesAlive;
    }
}
