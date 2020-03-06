using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
        if (col.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().currenthealth++;
        }
        else if (col.gameObject.tag == "Sword")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().currenthealth++;
        }
    }
}
