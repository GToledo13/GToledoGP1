using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer1 : MonoBehaviour
{
    playerManger1 playermanger;
    // Start is called before the first frame update
    void Start()
    {
        playermanger = GameObject.FindGameObjectWithTag("Player").GetComponent<playerManger1>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
            {
            playermanger.TakeDamage();
            
            }
    }

}
