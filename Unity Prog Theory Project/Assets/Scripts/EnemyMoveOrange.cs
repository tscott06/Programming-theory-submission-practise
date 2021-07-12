using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveOrange : EnemyMove
{
    private bool canMove = true;
    private float knockbackSpeed = 75.0f;


    // Update is called once per frame
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();       
    }

    public override void MoveEnemy()
    {
        if (canMove)
        {
            Vector3 lookDirection = (Player.transform.position - transform.position).normalized;

            //multiply by speed
            enemyRb.AddForce(lookDirection * speed, ForceMode.VelocityChange);

            StartCoroutine(moveDelay());

        }
    }

    IEnumerator moveDelay()
    {
        canMove = false;

        yield return new WaitForSeconds(2);

        canMove = true;

    }

    public override void TakeDamage()
    {
        hp--;

        Vector3 lookDirection = (Player.transform.position - transform.position).normalized;

        enemyRb.AddForce(-lookDirection * knockbackSpeed, ForceMode.VelocityChange);

        if (hp < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
