using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    protected GameObject Player;

    public float speed = 3.0f;
    protected Rigidbody enemyRb;

    [SerializeField]
    protected int damage = 1;

    [SerializeField]
    protected int hp = 1;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        MoveEnemy();

    }

    public virtual void MoveEnemy()
    {
        Vector3 lookDirection = (Player.transform.position - transform.position).normalized;

        //multiply by speed
        enemyRb.AddForce(lookDirection * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            causeDamage();
        }
    }

    public virtual void causeDamage()
    {
        PlayerHealth thisPlayerHealth = Player.GetComponent<PlayerHealth>();

        thisPlayerHealth.ChangeHealth(-damage);

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage();

            Destroy(other.gameObject);
        }
    }

    public virtual void TakeDamage()
    {
        
            Destroy(this.gameObject);
        
    }

   
}
