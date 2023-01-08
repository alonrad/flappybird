using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    
    [Header("Stats")]
    [SerializeField] private float jumpHeight;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationIntensity;
    public static float playerSpeed;

    [Space]

    [Header("References")]
    private PlayerInput input;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D col;

    [Space]

    [Header("Sounds")]
    [SerializeField] private AudioSource pointSource;
    [SerializeField] private AudioSource flap;
    [SerializeField] private AudioSource die;

    void Awake()
    {
        playerSpeed = moveSpeed;

        input = new PlayerInput();
        input.Enable();
    }

    void Update()
    {
        if (input.Player.Jump.triggered)
        {
            Jump();
            if (GameManager.state == State.waiting) GameManager.state = State.playing;
        }

        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationIntensity);
    }

    public void Jump()
    {
        flap.Play();
        rb.velocity = new Vector2(0, jumpHeight);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.CompareTag("Obstacle"))
        {
            Lose();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            Score();
        }
        else if (other.gameObject.transform.root.gameObject.CompareTag("JumpPad"))
        {
            Jump();
        }
    }

    void Score()
    {
        ScoreManager.Score();
        pointSource.Play();
    }

    void Lose()
    {
        die.Play();
        rb.velocity = new Vector2(2.5f, 7.5f);
        rb.angularVelocity = -500f;
        playerSpeed = 0;
        GameManager.state = State.dead;
        Destroy(gameObject, 2.5f);
        col.enabled = false;
        enabled = false;
    }
}
