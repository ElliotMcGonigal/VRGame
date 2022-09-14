using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gusScript : MonoBehaviour
{
    //declare the transform of our goal (where the navmesh agent will move towards) and our navmesh agent (in this case our zombie)
    private Transform goal;
    private UnityEngine.AI.NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        //create references
    goal = Camera.main.transform;
    agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    //set the navmesh agent's desination equal to the main camera's position (our first person character)
    agent.destination = goal.position;
    //start the walking animation
    GetComponent<Animation>().Play ("Walk");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
