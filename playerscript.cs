using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    private int health = 3;
    public float speed = 3;
    public float horizontalInput;
    public float verticalInput;
    public float fireRate = 0.5f;
    public float nextFire = 0;

    spawnmanagerscript spawnmanagerscript;

    public GameObject laserPrefab;

    void Start()
    {
        transform.position = new Vector3(0, 1, 0);
    }


    void Update()
    {
        CalculateMovement();
        Fire();
    }

    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            Instantiate(laserPrefab, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }



    void CalculateMovement()
    {


        if (transform.position.x < 5 && transform.position.x > -5 && transform.position.y < 4 && transform.position.y > 0)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
            transform.Translate(direction * Time.deltaTime * speed);
        }
        else
        {
            if (transform.position.x > 5)
            {
                transform.position = new Vector3(4.99f, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -5)
            {
                transform.position = new Vector3(-4.99f, transform.position.y, transform.position.z);
            }
            if (transform.position.y > 4)
            {
                transform.position = new Vector3(transform.position.x, 3.99f, transform.position.z);
            }
            if (transform.position.y < 0)
            {
                transform.position = new Vector3(transform.position.x, 0.01f, transform.position.z);
            }
        }
    }

    public void GetDamage()
    {
        health--;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("kaybettin");
            spawnmanagerscript.OnPlayerDeath();
        }
    }
}
