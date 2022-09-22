using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Runtime.CompilerServices;
using Unity.XR.CoreUtils;


public class affirmationGun : MonoBehaviour
{

    private GameObject gun;
    private GameObject spawnPoint;
    private Rigidbody rigidBody;
    private XRGrabInteractable interactableWeapon;
    private bool isShooting;

    protected virtual void Awake()
    {
            Debug.Log("test awake");
        interactableWeapon = GetComponent<XRGrabInteractable>();
        rigidBody = GetComponent<Rigidbody>();
    //    interactableWeapon.onActivate.AddListener(StartShooting);
    //    interactableWeapon.onDeactivate.AddListener(StopShooting);
    }

    // private void StartShooting(XRBaseInteractor interactor)
    // {
    //     Shoot();
    // }


    // an array for becket sounds
    [SerializeField] AudioClip[] becketSounds;
    //audio component for unity
    AudioSource myAudioSource;


    // Start is called before the first frame update
    void Start()
    {
    Debug.Log("test start");
    gun = GameObject.Find("Gun").gameObject;
    //gun needs affirmationGun Script, attached becket noises and Audio Source component
    spawnPoint = GameObject.Find("spawnPoint").gameObject;
    //Right click the gun and create a 3d object, sphere. This will make it a child. Rename it "spawnPoint". Scale it down to .001 across the board and move it to the very tip of the gun barrel, this is where the bullets are going to spawn from. Possibly needs Shpere Collider, is Trigger = no
    myAudioSource = GetComponent<AudioSource>();

    isShooting = false;
    Debug.Log("test end start");
    InvokeRepeating("Shoot", 3.0f, 0.5f);
    }

    private void Shoot()
    {
    Debug.Log("test");
    //Bullet assets needs to be in resouces folder to intantiate

    AudioClip clip = becketSounds[UnityEngine.Random.Range(0, becketSounds.Length)];
    myAudioSource.PlayOneShot(clip); 
    //set is shooting to true so we can't shoot continuosly
    isShooting = true;
    //instantiate the bullet
    GameObject bullet = Instantiate(Resources.Load("Bullet", typeof(GameObject))) as GameObject;
    //Get the bullet's rigid body component and set its position and rotation equal to that of the spawnPoint
    Rigidbody rb = bullet.GetComponent<Rigidbody>();
    bullet.transform.rotation = spawnPoint.transform.rotation;
    bullet.transform.position = spawnPoint.transform.position;
    //add force to the bullet in the direction of the spawnPoint's forward vector
    rb.AddForce(spawnPoint.transform.forward * 500f);
    
    //destroy the bullet after 1 second
    Destroy (bullet, 1);
    //wait for 1 second and set isShooting to false so we can shoot again
    // yield return new WaitForSeconds (1f);
    isShooting = false;
    }
    // Update is called once per frame
    void Update()
    {

            // couldnt get the if statement working
            // if (Input.GetMouseButtonDown(0))
            // {
                
            //     // myAudioSource.PlayOneShot(clip);
            //     StartCoroutine ("Shoot");
        //   }
        //declare a new RayCastHit
        // RaycastHit hit;
        // //draw the ray for debuging purposes (will only show up in scene view)
        // Debug.DrawRay(spawnPoint.transform.position, spawnPoint.transform.forward, Color.green);

        // //cast a ray from the spawnpoint in the direction of its forward vector
        // if (Physics.Raycast(spawnPoint.transform.position, spawnPoint.transform.forward, out hit, 100)){

        // //if the raycast hits any game object where its name contains "gus" and we aren't already shooting we will start the shooting coroutine
        // //shoots automatically, as long as gus is in range
        //     if (hit.collider.name.Contains("Gus")) {
        //         if (!isShooting) {
        //             StartCoroutine ("Shoot");
        //         }
        //     }
        // }
    }
}
