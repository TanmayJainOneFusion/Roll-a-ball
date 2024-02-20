using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{
    public TMP_Text countText;
    public TMP_Text wintext;
    public TMP_Text GameOverText;
    public Button ResetButton;
    private AudioSource pop;
    private AudioSource GameO;
    private AudioSource Winner;

    public float speed = 30.0f;
    private float ogSpeed;
    private Rigidbody rb;
    private int count;

    private float currentTime = 0f;
    private float startingTime = 30f;
    public TMP_Text Timer;

    private float movementX;
    private float movementY;

    public BoxCollider GameBounds;
    private static PlayerController instance; // Singleton instance

    Action UpdateAction = () => { };

    void Start()
    {
        Debug.Log(gameObject.name);
        InitializeGame();
    }

    void InitializeGame()
    {
        ogSpeed = speed;
        currentTime = startingTime;
        count = 0;
        SetCountText();
        rb = GetComponent<Rigidbody>();

        wintext.gameObject.SetActive(false);
        GameOverText.gameObject.SetActive(false);
        DeactivateButton();

        pop = GetComponent<AudioSource>();

        UpdateAction = UsualUpdateRoutine;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void Update()
    {
        UpdateAction();
    }

    private void UsualUpdateRoutine()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 300);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 2 * ogSpeed;
        }
        else
        {
            speed = ogSpeed;
        }

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed * Time.deltaTime * 100);

        HandleTime();
        HandleBounds();
    }

    void HandleTime()
    {
        currentTime -= Time.deltaTime;
        if (Timer != null)
        {
            Timer.text = currentTime.ToString("0");
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            HandleGameOver();
        }
    }

    void HandleBounds()
    {
        if (!GameBounds.bounds.Contains(transform.position))
        {
            HandleGameOver();
        }
    }

    public void HandleGameOver()
    {
        GameOverText.gameObject.SetActive(true);
        PausePlayer();
        ActivateButton();
        UpdateAction = () => { };
    }

    void PausePlayer()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            CollectPickup(other.gameObject);
            count++; 
            SetCountText();
        }
    }

    private void CollectPickup(GameObject pickup)
    {
       // Destroy(pickup);
        PickupManager.Instance.RespawnPickup();
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 13 && currentTime > 0)
        {
            wintext.gameObject.SetActive(true);
            UpdateAction = () => { };
            PausePlayer();
            ActivateButton();
        }
        else if (currentTime == 0 && count < 13)
        {
            HandleGameOver();
        }
    }

    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ActivateButton()
    {
        ResetButton.gameObject.SetActive(true);
    }

    void DeactivateButton()
    {
        ResetButton.gameObject.SetActive(false);
    }
}
