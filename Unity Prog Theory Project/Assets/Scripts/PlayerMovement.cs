using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject playerBullet;

    private Rigidbody playerRB;

    [SerializeField]
    private float playerSpeed = 100;
    [SerializeField]
    private float playerTurnSpeed = 75;

    
    

    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerInputs();



    }

    void CheckPlayerInputs()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }

        PlayerThruster();
        PlayerTurn();
    }

    private void PlayerThruster()
    {

        playerRB.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed);

    }

    private void PlayerTurn()
    {

        playerRB.AddRelativeTorque(Vector3.up * Input.GetAxis("Horizontal") * playerTurnSpeed);

    }

    public void FireBullet()
    {

       

        Vector3 bulletSpawnRotation = playerBullet.transform.eulerAngles;

        bulletSpawnRotation = transform.eulerAngles;
        bulletSpawnRotation.x = 90.0f;

        Instantiate(playerBullet, transform.localPosition, Quaternion.Euler(bulletSpawnRotation));

        

    }
}
