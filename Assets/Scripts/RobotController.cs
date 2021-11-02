using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    public float moveSpeed = 30f;
    public float turnSpeed = 10f;
    public float deadZone = 0.2f;

    private Animator robotAnim;
    private Rigidbody rigidBody;
    private Joystick joystick;

    void OnEnable()
    {
        robotAnim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
    }

    
    void Update()
    {
        // move!
        if(joystick.Direction.magnitude >= deadZone)
        {
            rigidBody.AddForce(transform.forward * moveSpeed);
            robotAnim.SetBool("Walk_Anim", true);
        }
        else
        {
            robotAnim.SetBool("Walk_Anim", false);
        }

        // rotate!
        Vector3 targetDirection = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);
        Vector3 direction = Vector3.RotateTowards(transform.forward, targetDirection, Time.deltaTime * turnSpeed, 0.0f);
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
