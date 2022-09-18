using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class gusScript : MonoBehaviour
{
    public Transform target;
    public UnityEngine.AI.NavMeshAgent agent;
    public Animator animator;
    float dist;
    
    void Start()
    {
    animator = GetComponent<Animator>();
    target = GameObject.Find("Sphere").transform;
    NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    dist = agent.remainingDistance;
    animator.SetBool("isWalking", true);

    }

    
    
    
    void Update()
    
  {

    agent.SetDestination(target.position);
    Check();
  }

  void Check()
  {
    if(Vector3.Distance(agent.destination, agent.transform.position) <= agent.stoppingDistance)
    {
      if(!agent.hasPath||agent.velocity.sqrMagnitude==0f)
      {
          print ("at destination");
          animator.SetBool("isWalking", false);
          
      }
    }
  }

// void OnTriggerEnter (Collider col)

//   {
//     GetComponent<CapsuleCollider>().enabled = false;
//     animator.SetBool("isWalking", false);
//     //destroy this gus in six seconds.
//     Destroy (gameObject, 6);
//     //instantiate a new gus
//     // GameObject gus = Instantiate(Resources.Load("Gus", typeof(GameObject))) as GameObject;

//     // //set the coordinates for a new vector 3
//     // float randomX = UnityEngine.Random.Range (-12f,12f);
//     // float constantY = .01f;
//     // float randomZ = UnityEngine.Random.Range (-13f,13f);
//     // //set the guss position equal to these new coordinates
//     // gus.transform.position = new Vector3 (randomX, constantY, randomZ);

//     // //if the gus gets positioned less than or equal to 3 scene units away from the camera we won't be able to shoot it
//     // //so keep repositioning the gus until it is greater than 3 scene units away. 
//     // while (Vector3.Distance (gus.transform.position, Camera.main.transform.position) <= 3) {
      
//     //   randomX = UnityEngine.Random.Range (-12f,12f);
//     //   randomZ = UnityEngine.Random.Range (-13f,13f);

//     //   gus.transform.position = new Vector3 (randomX, constantY, randomZ);
//     // }
//     }

}
