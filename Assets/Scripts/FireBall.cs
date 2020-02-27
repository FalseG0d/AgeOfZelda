using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject swordParticle;
    //int dir;
    float specialtimer = 1f;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

            specialtimer -= Time.deltaTime;
            if (specialtimer <= 0)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canMove = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canAttack = true;
                Instantiate(swordParticle, transform.position, transform.rotation);
                Destroy(gameObject);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetInteger("attackDir", 5);
            }



    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.tag == "Player"))
        {
            Destroy(gameObject);
            Instantiate(swordParticle, transform.position, transform.rotation);
        }
    }
    void CreateParticle()
    {
        Instantiate(swordParticle, transform.position, transform.rotation);
    }
}
