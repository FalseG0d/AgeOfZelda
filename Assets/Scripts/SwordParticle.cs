using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordParticle : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
    void Start()
    {
        timer = 0.15f;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            Destroy(gameObject);
        }
        
    }
}
