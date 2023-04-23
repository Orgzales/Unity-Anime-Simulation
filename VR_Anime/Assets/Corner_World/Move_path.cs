using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_path : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float speed = 4;
    int index = 0;
    float original_speed = 4;
    public bool isLoop = true;
    public AudioSource sound;
    int slowdown = 0;
    int stop = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(stop < 180)
        {
            stop++;
        }
        else
        {
            slowdown = slowdown + Random.Range(0, 2);
        }
        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;
        if(index == 16){
            if(slowdown >= Random.Range(300,600)){
                sound.Play();
                slowdown = 0;
                stop = 0;
            }
        }
        if(index > 1 && index < 16){
            if(slowdown >= Random.Range(300,600)){
                sound.Play();
                slowdown = 0;
                stop = 0;
            }
        }

        float distance = Vector3.Distance(transform.position, destination);
        if(distance <= 0.05)
        {

            speed = original_speed;

            if(index < waypoints.Count-1){
                index++;
            }

            if(index == 0){
                speed = .85f;
            }


            if(index == 16){
                speed = 0.05f;
            }
            if(index > 16){
                speed = 1;
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
