using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;

    private Rigidbody playerRb;
    private GameObject focalPoint;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(speed * verticalInput * focalPoint.transform.forward);

        var horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(speed * horizontalInput * focalPoint.transform.right);

    }
}
