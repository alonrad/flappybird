using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    
    [Header("Stats")]
    [SerializeField] private float spawnRate;
    [SerializeField] private float startDelay;

    [Space]

    [Header("References")]
    [SerializeField] private GameObject pipes;

    void Start()
    {
        InvokeRepeating("Spawn", startDelay, spawnRate);
    }

    void Spawn()
    {
        if (GameManager.state == State.playing)
        {
            GameObject pipe = Instantiate(pipes, new Vector3(20, Random.Range(-3f, 5f), 0), Quaternion.identity);
        }
    }
}
