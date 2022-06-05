using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControls : MonoBehaviour
{

    #region Movement Variables
    public float moveSpeed = 5f;
    private float xInput;
    private float zInput;
    public CharacterController playerController;
    private Vector3 moveDirection;
    #endregion

    #region Text Variables
    private int pickUpCount;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        pickUpCount = 0;
        playerController = GetComponent<CharacterController>();
        setCountText();
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        moveDirection = new Vector3(xInput, 0, zInput);
        playerController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            pickUpCount += 1;
            setCountText();
            other.gameObject.SetActive(false);
        }
    }

    private void setCountText()
    {
        countText.text = pickUpCount.ToString();
        if(pickUpCount == 12)
        {
            winTextObject.SetActive(true);
        }
    }
}
