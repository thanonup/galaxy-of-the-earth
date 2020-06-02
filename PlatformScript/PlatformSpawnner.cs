using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject brakablePlatform;

    public float platform_Spawn_Timer = 1.8f;
    private float current_Platform_Spawn_timer;

    private int platform_Spawn_Count;

    public float minx_X = -1.7f, max_X = 1.7f;

    void Start()
    {
        current_Platform_Spawn_timer = platform_Spawn_Timer;
    }

    void Update()
    {
        SpawnPlatforms();
    }
    void SpawnPlatforms()
    {
        current_Platform_Spawn_timer += Time.deltaTime;
        if(current_Platform_Spawn_timer >= platform_Spawn_Timer)
        {
            platform_Spawn_Count++;

            Vector3 temp = transform.position;
            temp.x = Random.Range(minx_X, max_X);

            GameObject newPlatform = null;
            if(platform_Spawn_Count < 2)
            {
                newPlatform = Instantiate(platformPrefab[Random.Range(0, platformPrefab.Length)]
                    , temp, Quaternion.identity);
            }
            else if (platform_Spawn_Count == 2)
            {
                if(Random.Range(0,2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab[Random.Range(0, platformPrefab.Length)], temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(movingPlatforms[Random.Range(0, movingPlatforms.Length)]
                        ,temp,Quaternion.identity);
                }
            }
            else if(platform_Spawn_Count == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab[Random.Range(0, platformPrefab.Length)], temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(spikePlatformPrefab , temp, Quaternion.identity);
                }
            }
            else if (platform_Spawn_Count == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab[Random.Range(0, platformPrefab.Length)], temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(brakablePlatform, temp, Quaternion.identity);
                }
                platform_Spawn_Count = 0;
            }
            if(newPlatform)
                newPlatform.transform.parent = transform;

            current_Platform_Spawn_timer = 0f;
        }
    }
}
