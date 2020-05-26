using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOnCollision : MonoBehaviour
{
    [SerializeField] private GroundCheck groundCheck;
    public float jumpForce = 5f;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && groundCheck.isGrounded)
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            groundCheck.isGrounded = false;          
        }        
    }

}
