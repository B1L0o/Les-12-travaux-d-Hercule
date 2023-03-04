
using UnityEngine;

public class DontDestroyLoadScene : MonoBehaviour
{
    public new GameObject[] objects; 
    void Awake()
    {
        foreach (GameObject _object in objects)
        {
            DontDestroyOnLoad(_object);
        }
    }

    
}
