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
    public static int CurrentScore;
    public static int HighScore;

    [Space]

    [Header("References")]
    private PlayerInput input;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Collider2D col;

    [Space]

    [Header("Sounds")]
    [SerializeField] private AudioSource pointSource;
    [SerializeField] private AudioSource flap;
    [SerializeField] private AudioSource die;

    void Awake()
    {
        playerSpeed = moveSpeed;
        CurrentScore = 0;

        input = new PlayerInput();
        input.Enable();
    }

    void Update()
    {
        if (input.Player.Jump.triggered)
        {
            Jump();
        }

        if (scoreText) {
            scoreText.text = CurrentScore.ToString();
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
    }

    void Score()
    {
        CurrentScore++;
        pointSource.Play();
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Lose()
    {
        die.Play();
        Invoke(nameof(ReloadScene), 1.25f);
        rb.velocity = new Vector2(2.5f, 7.5f);
        rb.angularVelocity = -500f;
        playerSpeed = 0;
        col.enabled = false;
        enabled = false;
    }
}
