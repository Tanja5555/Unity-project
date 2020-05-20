using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutFall : MonoBehaviour
{
    [HideInInspector] new public Rigidbody rb;
    public bool useGravity = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        StartCoroutine(MakeCoconutFall());                
    }

    private IEnumerator MakeCoconutFall()
    {
        yield return new WaitForSecondsRealtime(3f);
        rb.useGravity = false;

        if (useGravity)
        {
            rb.AddForce(Physics.gravity * (rb.mass * rb.mass));
        }

    }
}
