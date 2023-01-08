using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [Header("Spawn Rate")]
    [SerializeField] private float minSpawnRate;
    [SerializeField] private float maxSpawnRate;
    [SerializeField] private float startDelay;
    [Header("Spawn Height")]
    [SerializeField] private float minSpawnHeight;
    [SerializeField] private float maxSpawnHeight;
    [Header("Rotation")]
    [SerializeField] private float minRotation;
    [SerializeField] private float maxRotation;

    [Space]

    [Header("References")]
    [SerializeField] private GameObject[] clouds;

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        if (GameManager.state == State.playing || GameManager.state == State.waiting)
        {
            GameObject pipe = Instantiate(clouds[Random.Range(0, clouds.Length)], new Vector3(20, Random.Range(minSpawnHeight, maxSpawnHeight), 0), Quaternion.Euler(new Vector3(0, 0, Random.Range(minRotation, maxRotation))));
        }
        Invoke("Spawn", Random.Range(minSpawnRate, maxSpawnRate));
    }
}
