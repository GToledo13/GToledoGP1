using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public List<Transform> points;
    public int nextId;
    private int idchangeVaule = 1;
    public float speed;
    public int player;
    





    // Update is called once per frame
    void Update()
    {
        MoveToNextPoint();

          
    }


    private void MoveToNextPoint()

    {

        Transform goalPoint = points[nextId];
        if (goalPoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, goalPoint.position)<1f)
            {
            if (nextId == points.Count - 1)
            {
                idchangeVaule = -1;
            }
            if(nextId==0)
            {
                idchangeVaule = 1;
            }

            nextId += idchangeVaule;
            }

    }


    
    


    
}
