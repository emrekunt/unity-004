using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody enemyRb;
    private GameObject player;
    public EnemyType enemyType;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        DestroyEnemy();
        ChasePlayer();
    }

    public void DestroyEnemy()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    public void ChasePlayer()
    {
        var vectorToMove = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(vectorToMove * speed);
    }

    public enum EnemyType
    {
        Normal,
        Attacker,
        Speeder,
        Defender
    }
}
