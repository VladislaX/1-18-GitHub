using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersOnRoad : MonoBehaviour
{
    public GameObject[] TriggerPrefabs;
    public float DistanceBetweenTriggers;
    public Game Game;

    private void Awake()
    {
        int levelIndex = Game.LevelIndex;
        
        int platformsCount = 36;
        for (int i = 0; i < platformsCount; i++)
        {
            int prefabIndex = Random.Range(0, TriggerPrefabs.Length);

                Vector3 position = CalculatePlatformPosition(i);
                Quaternion rotation = Quaternion.Euler(0, 0, 0);
                Instantiate(TriggerPrefabs[prefabIndex], position, rotation, transform);
            
        }

       
    }

    private Vector3 CalculatePlatformPosition(int i)
    {
        return new Vector3(-5/2, -1/2, DistanceBetweenTriggers * i);
        
    }

}

   

