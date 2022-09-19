using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ppScript : MonoBehaviour
// this is all code to be added to player script
{
    //to declare----
    // an array for becket sounds
    [SerializeField] AudioClip[] becketSounds;
    //audio component for unity
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {   // to be added to start
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    //update is a place holder for the shooting function in play script
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioClip clip = becketSounds[UnityEngine.Random.Range(0, becketSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
}
