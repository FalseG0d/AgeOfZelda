using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class BlueDragon : MonoBehaviour
{
    public int health;
    public GameObject swordParticle;
    public GameObject projectile;
    public GameObject bloodSpill;
    public  float thrustPower;
    SpriteRenderer spriteRenderer;
    //public GameObject fireBall;
    public float speed;
    Animator anim;
    int direction;
    bool canAttack;
    int chance;
    float timer = 0.5f;
    float attackTimer = 2f;
    
    // Start is called before the first frame update
    void Start()
    {

        speed = 2;
        thrustPower = 500;
        canAttack = false;
        anim = GetComponent<Animator>();
        
        direction = Random.Range(0, 4);
        health = 2;

    }
    void Movenment()
    {
        chance = Random.Range(0,1);
        //GameObject fireBall = Instantiate(fireBall, transform.position, fireBall.transform.rotation);
        
        if (direction == 0)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
            anim.SetInteger("dir", 1);
            
            anim.speed = 3;
        }
        else if (direction == 1)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            anim.SetInteger("dir", 3);
            
            anim.speed = 3;
        }
        else if (direction == 2)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            anim.SetInteger("dir", 2);
            
            anim.speed = 3;
        }
        else if (direction == 3)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            anim.SetInteger("dir", 0);
            
            anim.speed = 3;
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0.5f;
            direction = Random.Range(0, 4);
        }
        Movenment();
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0) {
            attackTimer = 2f;
            canAttack = true;
        }
        Attack();

    }
    void Attack() {
        if (!canAttack)
            return;
        canAttack = false;
        
        if (direction == 0) {
            GameObject newProjectile = Instantiate(projectile, transform.position+ new Vector3(0.0f,-1.0f, 0.0f), transform.rotation);
            newProjectile.GetComponent<Rigidbody2D>().AddForce(Vector2.up * -thrustPower);
        }
        else if (direction == 1)
        {
            GameObject newProjectile = Instantiate(projectile, transform.position + new Vector3(0.0f, 1.0f, 0.0f), transform.rotation);
            newProjectile.GetComponent<Rigidbody2D>().AddForce(Vector2.up * thrustPower);
        }
        else if (direction == 2)
        {
            GameObject newProjectile = Instantiate(projectile, transform.position + new Vector3(-1.0f, 0.0f, 0.0f), transform.rotation);
            newProjectile.GetComponent<Rigidbody2D>().AddForce(Vector2.left * thrustPower);
        }
        else if (direction == 3)
        {
            GameObject newProjectile = Instantiate(projectile, transform.position + new Vector3(1.0f, 0.0f, 0.0f), transform.rotation);
            newProjectile.GetComponent<Rigidbody2D>().AddForce(Vector2.left * -thrustPower);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Sword")
        {
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
                Instantiate(swordParticle, transform.position, transform.rotation);
                Instantiate(bloodSpill, transform.position, transform.rotation);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canAttack = true;
                Destroy(col.gameObject);
            }

        }
        if (col.gameObject.tag == "Player")
        {
            health--;
            if (col.gameObject.GetComponent<Player>().iniFrame)
            {
                col.gameObject.GetComponent<Player>().iniFrame = true;
            }
            col.gameObject.GetComponent<Player>().currenthealth--;
            if (health <= 0)
            {

                Instantiate(swordParticle, transform.position, transform.rotation);
                Instantiate(bloodSpill, transform.position, transform.rotation);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canAttack = true;
                Destroy(gameObject);
            }

        }
        if (col.gameObject.tag == "Wall")
        {
            direction = Random.Range(0, 3);
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetInteger("attackDir", 5);
    }
}
