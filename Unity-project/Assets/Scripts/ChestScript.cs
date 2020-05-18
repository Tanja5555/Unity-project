using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    [SerializeField] private Light[] lightObjects;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var lightObject in lightObjects)
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                lightObject.enabled = !lightObject.enabled;
            }
        }
    }

    
}
