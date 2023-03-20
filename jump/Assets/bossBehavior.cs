using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBehavior : MonoBehaviour
{    // Declares all the the int we need for the script and to be called on from another scripts 
    public bool Phase2 = false;
    public bool Phase3 = false;
    public bool death = false;
    // sets the player as a transform so it can move 
    public Transform player;
    public bool isFlipped = false;
    playerManger1 PlayerManger1;
    public int bossHealth = 10;
    public float attackRange = 2f;
    public float speed = 4.5f;


    // creat a timer system ro shoot this projectile every five seconds 
    // with this number
    public float timer;
    public int waitingTime;


    //crete a shot location as a referecne 
    public Transform shootlocation;
    public GameObject fireball;
    public GameObject fireball2;// drag pir created prefab into this reference 

    // Start is called before the first frame update

    private void Start()
    {
        PlayerManger1 = GameObject.FindGameObjectWithTag("Player").GetComponent<playerManger1>();

        //position,rotation,scale
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


     private void Update()
    { // sets the first phase of attack based on the player from below 7 and above 3 and also sets the speed of the boss and its attack ranage 
        if(bossHealth<7 && bossHealth>3)
        {
            Phase2 = true;
            speed = 2;
            attackRange = 6;
        }//Starts the second phase of the boss attack based on the player health above 3 and when it equal to one 
        else if (bossHealth<3 && bossHealth>=1 )
        {
            Phase2 = false;
            Phase3 = true;
        }
            // when the player health is =0 the game will pause/end 
        else if(bossHealth<0)
        {
           Phase3= false;
            death=true;
        }
        timer += Time.deltaTime;

    }
    
    public void PojectileShoot()
    {
        if (timer < waitingTime)
        {
            if(Phase2)
            { // creates a new gameobject based off our prefab
                GameObject clone = Instantiate(fireball, shootlocation.position, Quaternion.identity);
                timer = 0;
            }
        else if (Phase3)
            {
                GameObject clone = Instantiate(fireball2, shootlocation.position, Quaternion.identity);
                timer = 0;
            }
        }
    }

    // Update is called once per frame
    public void LookAtPlayer()
    {// flips the player positon left,right
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;


        if(transform.position.x> player.position.x&& isFlipped)
        { //  flips the player positon left,right
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = false;
        }
       else if (transform.position.x < player.position.x && isFlipped)
        {   // flips the player postiotn to left ir right 
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    { // when the player is contact wit the boss it aloows it to take damge 
        if(collision.gameObject.tag=="Player")
        {
            PlayerManger1.TakeDamage();
        }
    }










}






