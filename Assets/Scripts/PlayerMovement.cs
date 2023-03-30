using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1;
    public float rotationSpeed = 1;

    private Rigidbody rigidBody;
    public JoyStickController joyStickController;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float hori = JoyStickController.Horizontal;
        float verti = JoyStickController.Vertical;
        rigidBody.velocity = new Vector3(hori * moveSpeed, rigidBody.velocity.y, verti * moveSpeed);

        if(rigidBody.velocity != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(rigidBody.velocity, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
        }
    }
}
