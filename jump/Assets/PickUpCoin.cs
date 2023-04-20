using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            playerManger1 manger = collision.GetComponent<playerManger1>();

            if(manger)
            {


                bool pickedUp = manger.pickupItem(gameObject);
                if(pickedUp)
                {
                    Destroy(gameObject);
                }

            }

            




        }


    }
}
