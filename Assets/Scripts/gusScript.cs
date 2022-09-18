using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class gusScript : MonoBehaviour
{
  // declaring variables
    public Transform target;
    public UnityEngine.AI.NavMeshAgent agent;
    public Animator animator;
    float dist;
    
    void Start()
    {
      //makes sure the animation takes over gus
    animator = GetComponent<Animator>();
    //sets Gus's destination to Player
    target = GameObject.Find("playerObject").transform;
    // walking AI
    NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    //distance from Gus to Player, only important to gus
    dist = agent.remainingDistance;
    // tells animator to start walking, after half a second of idle
    animator.SetBool("isWalking", true);

    }

    
    
    
    void Update()
    
  {
    //on each frame tells gus where to walk
    agent.SetDestination(target.position);
    //gus checking their distance from player
    Check();
  }

//gus checking distance
  void Check()
  {
    if(Vector3.Distance(agent.destination, agent.transform.position) <= agent.stoppingDistance)
    {
      if(!agent.hasPath||agent.velocity.sqrMagnitude==0f)
      {
          print ("at destination");
          //when gus gets to player, theyll stop walking
          animator.SetBool("isWalking", false);
          
      }
    }
  }

void OnTriggerEnter (Collider col)

  {
    // GetComponent<CapsuleCollider>().enabled = false;
    animator.SetBool("isWalking", false);
    //destroy this gus in six seconds.
    Destroy (gameObject, 2);
    //instantiate a new gus
    GameObject gus = Instantiate(Resources.Load("Gus", typeof(GameObject))) as GameObject;

    // //set the coordinates for a new vector 3
    float randomX = UnityEngine.Random.Range (-12f,12f);
    float constantY = .01f;
    float randomZ = UnityEngine.Random.Range (-13f,13f);
     //set the guss position equal to these new coordinates
    gus.transform.position = new Vector3 (randomX, constantY, randomZ);

    //if the gus gets positioned less than or equal to 3 scene units away from the camera we won't be able to cheer them up 
    //so keep repositioning the gus until it is greater than 3 scene units away. 
    while (Vector3.Distance (gus.transform.position, Camera.main.transform.position) <= 3) {
      
    randomX = UnityEngine.Random.Range (-12f,12f);
    randomZ = UnityEngine.Random.Range (-13f,13f);

    gus.transform.position = new Vector3 (randomX, constantY, randomZ);
    }
    }

}
