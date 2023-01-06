using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBird : MonoBehaviour
{
    Player player;

    void Awake() {
        player = GetComponent<Player>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        player.Jump();
    }
}
