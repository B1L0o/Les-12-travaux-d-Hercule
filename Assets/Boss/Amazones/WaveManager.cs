using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveManager : MonoBehaviour
{
    [SerializeField] 
    private SpawnerAmazones spawnerAmazones;
    [SerializeField] 
    private int[] numberOfAmazonesForEachWave;
    private List<GameObject> listCurrentAmazones;
    private int numberActualWave;
    [SerializeField] 
    private Text textWave;
    

    // Start is called before the first frame update

    private void StartWave(int numberOfAmazones)
    {
        listCurrentAmazones = spawnerAmazones.SpawnAmazones(numberOfAmazones);
    }
    void Start()
    {
        listCurrentAmazones = new List<GameObject>();
        numberActualWave = -1;
    }
    
    void Update()
    {
        if (AreAmazonesAllDead() && numberActualWave+1<numberOfAmazonesForEachWave.Length)
        {
            
            numberActualWave = numberActualWave + 1;
            textWave.text = "Wave " + (numberActualWave+1);
            StartWave(numberOfAmazonesForEachWave[numberActualWave]);
        }
        
        
    }

    private bool AreAmazonesAllDead()
    {
        listCurrentAmazones.RemoveAll(amazone => amazone.gameObject is null||amazone.CompareTag("Untagged"));
        return  listCurrentAmazones.Count==0;

    }
}
