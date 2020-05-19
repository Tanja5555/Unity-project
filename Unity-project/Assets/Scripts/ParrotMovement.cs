using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrotMovement : MonoBehaviour

{
    
    private float speed = 10f;
    private float jumpForce = 5f;
	private float xMovement;
	private float zMovement;
    private float rotationSpeed = 9f;
    public float rotX;
    public float rotY;
    public float rotZ;


	[SerializeField] private LayerMask groundMask;
	[SerializeField] Vector3 startPosition;
	private Quaternion startRotation;

	private RaycastHit hitInfo;

    private bool shouldJump = false;
    private bool grounded = false;

    private Rigidbody rb;
    private Vector3 movement;
    

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        xMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        zMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        movement = new Vector3(xMovement, 0f, zMovement);

        transform.Translate(movement);

        rotX -= Input.GetAxis ("Mouse Y") * Time.deltaTime * rotationSpeed;
        rotY += Input.GetAxis ("Mouse X") * Time.deltaTime * rotationSpeed;

        transform.rotation = Quaternion.Euler (0, rotY, 0);

       if (Input.GetKeyDown(KeyCode.Space) && grounded)

        {
            shouldJump = true;
            Debug.Log("Jumping");
        }

        if(Physics.Raycast(transform.position, -transform.up, out hitInfo, 1.6f, groundMask))

        {
            grounded = true;
            
        }

        else

        {
            grounded = false;
        }
    }


    private void FixedUpdate()
    {
        Vector3 newPosition = transform.position + (movement * speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);

        if (shouldJump)

        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            shouldJump = false;
        }
    }

    
}
