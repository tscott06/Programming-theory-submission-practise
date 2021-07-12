using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;

    private Rigidbody bulletRB;

    // Start is called before the first frame update
    void Start()
    {
        bulletRB = gameObject.GetComponent<Rigidbody>();

        StartCoroutine(DestroyBullet());

        bulletRB.AddRelativeForce(Vector3.up * bulletSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

        

    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
