using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angle_laser : MonoBehaviour
{
public List<GameObject> waypoints;
    public float speed = 2; 
    float original_speed = 0.1f;
    int index = 0;
    public bool isLoop = true;
    public AudioSource sound;
    public AudioSource sound2;
    int wait = 0;
    bool fire = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(index > 0){
            wait++;
            if(wait > 120 & fire == true){
                sound2.Play();
                fire = false;
            }
        }
        
        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);

        if(distance <= 0.05)
        {
            
            speed = original_speed;
            if(index < waypoints.Count-1)
            {
                sound.Play();
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
