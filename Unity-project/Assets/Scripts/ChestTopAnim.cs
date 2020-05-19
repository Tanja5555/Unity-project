using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTopAnim : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Collided with" + other.name);
            anim.SetTrigger("OpenTop");
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Stopped collision with" + other.name);
            anim.enabled = true;
        }
        
    }

    void PauseAnimationEvent()
    {
        Debug.Log("Waiting");
        anim.enabled = false;
    }
}
