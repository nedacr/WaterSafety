using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public List<Transform> waypoint = new List<Transform>();
    //public Transform[] waypoints;
    //Transform target, restart;
    NavMeshAgent agent;
    float distance;

    public int index = 0, speed = 2, maxIndex = -1;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        maxIndex = waypoint.Count;

    }

    // Update is called once per frame
    void Update()
    {
        //if (this.transform.position == target.position)
        //{
        //    index++;
        //    if (index > maxIndex)
        //    {
        //        index = 0;
        //    }

        waypointTravel();
        //}
        //if (this.transform.position == this.target.position)
        //{
        //    transform.position = restart.position;
        //}
        //transform.position = Vector3.MoveTowards(this.transform.position, this.target.position, Time.deltaTime * speed);
    }

    void waypointTravel()
    {
        //target = waypoints[index];
        //transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);

        distance = Vector3.Distance(waypoint[index].position, transform.position);
        if(distance <= 2)
        {
            index++;
            if(index >= maxIndex)
            {
                index = 0;
            }
        }
        agent.SetDestination(waypoint[index].position);
    }

    //void setInitial()
    //{
    //    restart = this.position;
    //}
    //Transform getInitial()
    //{
    //    restart = this.position;
    //}

}
