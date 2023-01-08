using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static State state;

    [SerializeField] private GameObject jumpPad;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject loseMenu;

    void Awake()
    {
        state = State.waiting;
    }

    void Update()
    {
        jumpPad.SetActive(state == State.waiting);
        //pauseMenu.SetActive(state == State.paused);
        loseMenu.SetActive(state == State.dead);
    }
}

public enum State
{
    waiting,
    playing,
    paused,
    dead
}
