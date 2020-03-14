using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public GameObject potionParticle;
    void OnCollisionEnter2D(Collision2D col)
    {
        

        if ((col.gameObject.tag == "Sword")|| (col.gameObject.tag == "Player"))
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().currenthealth == GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().maxhealth)
                return;

            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().currenthealth++;

        }

        Instantiate(potionParticle, transform.position, transform.rotation);
        Destroy(gameObject);

    }
}
