using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SpawnerAmazones : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] 
    private GameObject amazonePrefab;
    [SerializeField] 
    private Player player;
    [SerializeField] 
    private int numberofAmazoneToSpawn;
    public void SpawnRandomAmazon()
    {
        GameObject amazone = Instantiate(amazonePrefab);
        Amazone amazoneObject = amazone.GetComponent<Amazone>();
        amazoneObject.Damage = Random.Range(1,3);
        amazoneObject._speed = Random.Range(3,8);
        amazoneObject._player = player;
        amazone.SetActive(true);
    }
    void Start()
    {
        StartCoroutine(SpawnBirds());
    }
    
    IEnumerator SpawnBirds()
    {
        
        for (int i = 0; i < numberofAmazoneToSpawn; i++)
        {
            yield return new WaitForSeconds(1.5f);
            SpawnRandomAmazon();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
