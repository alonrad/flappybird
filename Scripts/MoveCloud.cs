using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    private float CurrentSpeed;


    void Start()
    {
        CurrentSpeed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        if (transform.position.x <= -20)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(-Player.playerSpeed, 0) * Time.fixedDeltaTime * CurrentSpeed;
    }
}
