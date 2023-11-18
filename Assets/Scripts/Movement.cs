using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform[] waypoints;
    Transform target, restart;

    public int index = 0, speed = 2, maxIndex = -1;
    // Start is called before the first frame update
    void Start()
    {
        //foreach (Transform t in waypoints){
        //    maxIndex++;
        //}
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(this.transform.position == target.position)
        //{
        //    index++;
        //    if(index > maxIndex)
        //    {
        //        index = 0;
        //    }

        //    //waypointTravel();
        //}
        if(this.transform.position == this.target.position)
        {
            transform.position = restart.position;
        }
        transform.position = Vector3.MoveTowards(this.transform.position, this.target.position, Time.deltaTime * speed);
    }

    void waypointTravel()
    {
        target = waypoints[index];
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
    }

    void setInitial()
    {
        restart = this.position;
    }
    Transform getInitial()
    {
        restart = this.position;
    }

}
