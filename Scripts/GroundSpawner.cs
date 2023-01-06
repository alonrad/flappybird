using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    
    [SerializeField] private const float MinDistance = 20;

    [SerializeField] private Transform ground;
    [SerializeField] private Transform startLevel;
    [SerializeField] private Transform player;

    private Transform lastEndPosition;

    private Transform spawnPoint;

    void Awake()
    {
        lastEndPosition = startLevel.Find("EndPosition");
        SpawnGround();
        SpawnGround();
    }

    void Update()
    {
        if(lastEndPosition.position.x <= MinDistance)
        {
            SpawnGround();
        }
    }

    void SpawnGround()
    {
        Transform groundObject = SpawnPosition(lastEndPosition.position);
        lastEndPosition = groundObject.Find("EndPosition");
    }
    
     private Transform SpawnPosition(Vector3 SpawnPosition)
    {
        Transform groundObject = Instantiate(ground, SpawnPosition, Quaternion.identity);
        return groundObject;
    }
}
