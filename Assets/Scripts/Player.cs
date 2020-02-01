using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public float speed;
    Animator anim;
    public Image[] hearts;
    public int maxhealth;
    public int currenthealth;
    public float thrustPower;
    public GameObject sword;
    public bool canMove;
    public bool canAttack;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        maxhealth = 5;
        canMove = true;
        canAttack = true;
        speed = 10;
        thrustPower = 400;
        currenthealth = maxhealth;
        gethealth();
        
    }
    void gethealth() {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < currenthealth; i++) {
            hearts[i].gameObject.SetActive(true);
        }
    
    }
    void Attack() {
        anim.SetInteger("attackDir", anim.GetInteger("dir"));
        if (!canAttack) {
            return;
        }
        canAttack = false;
        canMove = false;
        GameObject newSword = Instantiate(sword,transform.position,sword.transform.rotation);
        if (currenthealth == maxhealth) {
            newSword.GetComponent<Attack>().special = true;
            canMove = true;
            thrustPower = 700;
        }
        else
        {
            newSword.GetComponent<Attack>().special = false;
            thrustPower = 250;
        }
        #region//SwordRotation
        int swordDir =anim.GetInteger("dir");
        if (swordDir == 0) {
            newSword.transform.Rotate(0, 0, 0);
            newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.up*thrustPower);
        }
        else if (swordDir == 1)
        {
            newSword.transform.Rotate(0, 0, 180);
            newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.down * thrustPower);
        }
        else if (swordDir == 2)
        {
            newSword.transform.Rotate(0, 0, 90);
            newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.left * thrustPower);
        }
        else if (swordDir == 3)
        {
            newSword.transform.Rotate(0, 0, -90);
            newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.right * thrustPower);
        }
        #endregion
        

    }
    // Update is called once per frame
    void Update()
    {
        Movenment();
        if (Input.GetKey(KeyCode.Space)) {
            Attack();
        }
        if (Input.GetKey(KeyCode.P))
        {
            currenthealth--;
        }
        if (currenthealth>maxhealth)
        {
            currenthealth=maxhealth;
        }
        gethealth();
    }
    void Movenment() {
        if (!canMove) {
            return;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, speed * Time.deltaTime, 0); anim.SetInteger("dir", 0); anim.speed = 3;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0); anim.SetInteger("dir", 1); anim.speed = 3;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0); anim.SetInteger("dir", 2); anim.speed = 3;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0); anim.SetInteger("dir", 3); anim.speed = 3;
        }
        else {
            anim.speed = 0;
        }

    }
}
