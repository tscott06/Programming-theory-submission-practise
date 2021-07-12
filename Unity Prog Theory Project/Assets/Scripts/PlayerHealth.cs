using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public enum changeHealthMode
    {
        fullHealth,
        halfHealth,
    }

    [SerializeField]
    private int _maxHealth = 10;
    public int maxHealth
    {
        get { return _maxHealth; }
   

    }

    [SerializeField]
    private int _health = 10;
    public int health
    {
        get { return _health; }

    }

  

    //Helath overloaded
    /// <summary>
    /// Deduct helath by a specified amount
    /// </summary>
    /// <param name="health"></param>
    public void ChangeHealth(int health)
    {

        _health += health;

        UIManager.UpdateHealth();
        CheckIfDead();

    }

    /// <summary>
    /// 
    /// Set types of health recover
    /// </summary>
    public void ChangeHealth(changeHealthMode healthRecover)
    {

        if (healthRecover == changeHealthMode.fullHealth)
        {
            _health = maxHealth;
        } else if (healthRecover == changeHealthMode.halfHealth)
        {
            _health /= 2;
        }

        UIManager.UpdateHealth();

        CheckIfDead();
    }

    public void ChangeMaxHealth(int amount)
    {
        _maxHealth += amount;

        UIManager.UpdateHealth();

        CheckIfDead();
    }


    private void CheckIfDead()
    {
        if(health <= 0)
        {
            Destroy(gameObject.GetComponent<PlayerMovement>());

            

            UIManager.GameOver();

        }
    }
}
