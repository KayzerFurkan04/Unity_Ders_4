using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserscript : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 10);

        if (transform.position.y > 5)
        {
            Destroy(gameObject);
        }
    }
}
