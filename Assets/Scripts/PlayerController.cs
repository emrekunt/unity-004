using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    public GameObject powerupIndicator;

    private Rigidbody playerRb;
    private GameObject focalPoint;
    private bool hasPowerup = false;
    private readonly int powerUpTime = 7;
    private readonly float powerUpForce = 15f;
    private Vector3 powerUpIndicatorOffset;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find(AppConstants.GameObject.FocalPoint.ToString());
        powerupIndicator.SetActive(false);
        StartCoroutine(PowerupCountDown());
        powerUpIndicatorOffset = new Vector3(0, -0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private IEnumerator PowerupCountDown()
    {
        yield return new WaitForSeconds(powerUpTime);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    private void Move()
    {
        var verticalInput = Input.GetAxis(AppConstants.Axis.Vertical.ToString());
        playerRb.AddForce(speed * verticalInput * focalPoint.transform.forward);

        var horizontalInput = Input.GetAxis(AppConstants.Axis.Horizontal.ToString());
        playerRb.AddForce(speed * horizontalInput * focalPoint.transform.right);

        powerupIndicator.transform.position = transform.position + powerUpIndicatorOffset;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(AppConstants.Tag.Powerup.ToString()))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(AppConstants.Tag.Enemy.ToString()))
        {
            if (hasPowerup)
            {
                PushEnemy(collision);
            }

        }
    }

    private void PushEnemy(Collision collision)
    {
        var vectorToMoveAway = collision.gameObject.transform.position - transform.position;
        var enemyRb = collision.gameObject.GetComponent<Rigidbody>();
        enemyRb.AddForce(vectorToMoveAway * powerUpForce, ForceMode.Impulse);
    }
}
