using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTopAnim : MonoBehaviour
{
    Animator anim;
    private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;


    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {           
            Debug.Log("Collided with" + other.name);           
            anim.SetTrigger("OpenTop");
            StartCoroutine(PlaySound());
            
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {           
            Debug.Log("Stopped collision with" + other.name);
            anim.enabled = true;
            audioSource.PlayOneShot(audioClip);
        }      
    }

    void PauseAnimationEvent()
    {
        Debug.Log("Waiting");
        anim.enabled = false;
    }

    private IEnumerator PlaySound()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        yield return new WaitForSecondsRealtime(0.5f);
        audioSource.PlayOneShot(audioClip);
        Debug.Log("Stopped Coroutine at timestamp : " + Time.time);
    }
}
