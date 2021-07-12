using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   
    private static TextMeshProUGUI healthText;

    private static PlayerHealth playerHealth;

    

    // Start is called before the first frame update
    void Start()
    {
        healthText = gameObject.GetComponentInChildren<TextMeshProUGUI>();

        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();

        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void UpdateHealth()
    {
        healthText.text = "Health : " + playerHealth.health + " out of " + playerHealth.maxHealth;
    }
}
