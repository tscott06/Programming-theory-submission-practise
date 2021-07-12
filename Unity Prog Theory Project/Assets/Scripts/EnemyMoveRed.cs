using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveRed : EnemyMove
{
    [SerializeField]
    private float speedIncrease = 1.0f;

    [SerializeField]
    private float shrinkBy = 2.0f;

 


    public override void TakeDamage()
    {
        hp--;

        increaseChaseSpeed();
        decreaseSize();

        if (hp < 1)
        {
            Destroy(this.gameObject);
        }
    }

    void increaseChaseSpeed()
    {
        speed += speedIncrease;
    }

    void decreaseSize()
    {
        transform.localScale -= new Vector3(shrinkBy, shrinkBy, shrinkBy);
    }

    public override void causeDamage()
    {
        PlayerHealth thisPlayerHealth = Player.GetComponent<PlayerHealth>();

        Rigidbody playerRB = Player.GetComponent<Rigidbody>();

        Vector3 repelDirection = (Player.transform.position - transform.position).normalized;
        playerRB.AddForce(repelDirection * 100.0f, ForceMode.VelocityChange);



        thisPlayerHealth.ChangeHealth(PlayerHealth.changeHealthMode.halfHealth);

    }
}
