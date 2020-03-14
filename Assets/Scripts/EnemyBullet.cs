using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject bulletParticle;
    float specialtimer = 1f;
    void Update()
    {
        specialtimer -= Time.deltaTime;
        if (specialtimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
        Instantiate(bulletParticle, transform.position, transform.rotation);

        if (col.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().currenthealth--;
        }
        else if (!(col.gameObject.tag == "Dragon"))
        {
            return;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Crab").GetComponent<Crab>().health--;
        }
    }
}
