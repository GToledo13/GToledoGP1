using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManger1 : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth = 1;
    playerMovement SPEED;
    public int cointCount;
    //Space
    private void Awake()
    {
        SPEED = GetComponent<playerMovement>();
        currentHealth = 10;
    }
    private void Update()
    {
        if(currentHealth<=0)
        {
            PauseGame();
        }
    }
    public bool pickupItem(GameObject obj)
    {

        switch
            (obj.tag)
        {

            case "Currency":
                cointCount++;
                return true;
            case "Speed+":
               SPEED.SpeedPowerUp();
                return true;
            default:
                return false;
            
        }



    }

    public void TakeDamage()
    {
        currentHealth -= 1;
    }


    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }



}
