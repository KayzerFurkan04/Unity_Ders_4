using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class enemyscript : MonoBehaviour
{
    public float speed = 3.0f;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -3)
        {
            float x_position = Random.Range(-5, 5);
            transform.position = new Vector3(x_position, 6, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " vuruldu");
        if (other.tag == "player")
        {
            playerscript playerscript = other.GetComponent<playerscript>();
            playerscript.GetDamage();
            Destroy(this.gameObject);
        }
        else if (other.tag == "laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
