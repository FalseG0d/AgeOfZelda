using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    float timer = 0.25f;
    float specialtimer = 1f;
    public bool special=true;
    public GameObject swordParticle;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (!special)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canMove = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canAttack = true;
                Destroy(gameObject);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetInteger("attackDir",5);
            }
        }
        else {
            specialtimer -= Time.deltaTime;
            if (specialtimer <= 0) {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canAttack = true;
                Instantiate(swordParticle,transform.position,transform.rotation);
                Destroy(gameObject);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetInteger("attackDir", 5);
            }
        }
        

    }
}
