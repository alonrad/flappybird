using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 7.5f);
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(-Player.playerSpeed, 0) * Time.fixedDeltaTime;
    }
}
