using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] private float lifeTime; 
    
    // local vars
    private float timeLeft;
    
    void Start()
    {
        timeLeft = lifeTime;
    }

    void Update()
    {
        if (timeLeft <= 0)
        {
            if (GameManager.state == State.playing)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            timeLeft -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(-Player.playerSpeed, 0) * Time.fixedDeltaTime;
    }
}
