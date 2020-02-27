using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject bulletParticle;
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(bulletParticle, transform.position, transform.rotation);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().currenthealth--;
        }
        else if (!(col.gameObject.tag == "Dragon"))
        {
            Destroy(gameObject);
            Instantiate(bulletParticle, transform.position, transform.rotation);
        }
    }
}
