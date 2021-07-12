using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   
    private static TextMeshProUGUI[] uiTexts = new TextMeshProUGUI[2];
    private static TextMeshProUGUI healthText;
    private static TextMeshProUGUI gameOverText;

    private static PlayerHealth playerHealth;

    

    // Start is called before the first frame update
    void Start()
    {
        uiTexts = gameObject.GetComponentsInChildren<TextMeshProUGUI>(true);
        healthText = uiTexts[0];
        gameOverText = uiTexts[1];


        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();

        UpdateHealth();
    }



    public static void UpdateHealth()
    {
        healthText.text = "Health : " + playerHealth.health + " out of " + playerHealth.maxHealth;
    }

    public static void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }
}
