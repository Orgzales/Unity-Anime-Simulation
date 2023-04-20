using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_move : MonoBehaviour
{
public List<GameObject> waypoints;
    public float speed = 2; 
    float original_speed = 0.1f;
    int index = 0;
    public bool isLoop = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);
        if(distance <= 0.05)
        {
            speed = original_speed;
            if(index < waypoints.Count-1)
            {
                index++;
            }
            if(index == 1){
                speed = 2000;
            }
        }
        else
        {
            if(isLoop & index == waypoints.Count-1)
            {
                index= 0;
            }
        }

    }     
}
