using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public List<Transform> waypoint = new List<Transform>();
    public string NPCname;
    //public Transform[] waypoints;
    //Transform target, restart;
    NavMeshAgent agent;
    float distance;

    public int index = 0, speed = 2, maxIndex;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        maxIndex = waypoint.Count;
        transform.LookAt(waypoint[index].position);
        waypointTravel();

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
        
        //rotation fix
        //if(transform.rotation.x >= 30)
        //{
        //float myTargetRotationX = transform.rotation.x - 9; //get the X rotation from anotherObject
        //float myTargetRotationY = transform.rotation.y; //get the Y rotation from this object
        //float myTargetRotationZ = transform.rotation.z; //get the Z rotation from this object
        //Vector3 myEulerAngleRotation = new Vector3(myTargetRotationX, myTargetRotationY, myTargetRotationZ);
        //transform.rotation = Quaternion.Euler(myEulerAngleRotation);

        //}
        

        distance = Vector3.Distance(waypoint[index].position, transform.position);
        if (distance <= 2)
        {
            index++;
            Debug.Log(this.NPCname + " at " + index);
            if (index == maxIndex)
            {
                index = 0;
            }
            transform.LookAt(waypoint[index].position);
            
            waypointTravel();
        }
        
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

        //if(NPCname == "Children on a boat without life jackets.")
        //{
        //    if(index == 0)
        //    {
        //        transform.LookAt(waypoint[maxIndex].position);
        //    }
        //    else
        //    {
        //        transform.LookAt(waypoint[index-1].position);
        //    }
        //}
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
