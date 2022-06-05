using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameManager manager;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winText;
    public GameObject loseText;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        SetCountText();
        rb = GetComponent<Rigidbody>();
        winText.SetActive(false);
        loseText.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();

            if (count >= 12)
            {
                FindObjectOfType<GameManager>().WinGame();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    void SetCountText()
    {
        countText.text = count.ToString();
    }
}
