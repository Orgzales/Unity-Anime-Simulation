using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialLaser : MonoBehaviour
{
public List<GameObject> waypoints;
    public float speed = 2; 
    float original_speed = 0.1f;
    int index = 0;
    public bool isLoop = true;
    public AudioSource sound;
    public AudioSource sound2;
    int wait = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(index == 2){
            wait++;
            if(wait > 30 ){
                sound2.Play();
                wait = 0;
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
                index++;
            }
            if(index == 1){
                sound.Play();
                speed = 2000;
            }
            if(index == 3){
                speed = 5000;
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
