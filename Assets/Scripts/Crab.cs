using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    public int health;
    public GameObject swordParticle;
    SpriteRenderer spriteRenderer;
    public float speed;
    int direction;
    float timer = 0.5f;
    public Sprite faceUp;
    public Sprite faceDown;
    public Sprite faceLeft;
    public Sprite faceRight;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        speed = 2;
        direction= Random.Range(0, 4);
        spriteRenderer.sprite = faceUp;
        health = 5;
        
    }
    void Movenment() {
        if (direction == 0) {
            transform.Translate(0,-speed*Time.deltaTime,0);
            spriteRenderer.sprite = faceDown;
        }
        else if (direction == 1)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            spriteRenderer.sprite = faceLeft;
        }
        else if (direction == 2)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            spriteRenderer.sprite = faceRight;
        }
        else if (direction == 3)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            spriteRenderer.sprite = faceUp;
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            timer = 0.5f;
            direction = Random.Range(0,3);
        }
        Movenment();
        
    }
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Sword") {
            health--;
            if (health <= 0) {
                Destroy(gameObject);
                Instantiate(swordParticle, transform.position, transform.rotation);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canAttack = true;
                Destroy(col.gameObject);
            }
        
        }
        if (col.gameObject.tag == "Player")
        {
            health--;
            if (col.gameObject.GetComponent<Player>().iniFrame) {
                col.gameObject.GetComponent<Player>().iniFrame = true;
            }
            col.gameObject.GetComponent<Player>().currenthealth--;
            if (health <= 0)
            {
                
                Instantiate(swordParticle, transform.position, transform.rotation);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canAttack = true;
                Destroy(gameObject);
            }

        }
        if (col.gameObject.tag == "Wall") {
            direction = Random.Range(0,3);
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetInteger("attackDir", 5);
    }
}
