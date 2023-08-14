using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(speed * verticalInput * Vector3.forward);

        var horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(speed * horizontalInput * Vector3.right);

    }
}
