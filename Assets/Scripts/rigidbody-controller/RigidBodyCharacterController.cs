using UnityEngine;

public class RigidBodyCharacterController : MonoBehaviour
{
    Rigidbody rb;
    float speed = 5;
    float jumpPower = 5;
    Vector3 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed;//الحركة

        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 1.3f)//القفز
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpPower, rb.linearVelocity.z);
        }
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
    }
}