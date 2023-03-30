using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1Projectile : MonoBehaviour
{
    public float projectileSpeed = 1;

    public Skill1Spawn skill1Spawn;

    private Rigidbody rigidBody;

    public float x, z;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        skill1Spawn = GameObject.Find("Skill1Spawn").GetComponent<Skill1Spawn>();        
    }

    // Update is called once per frame
    void Start()
    {
        rigidBody.velocity = transform.forward * projectileSpeed;
    }

    void Update()
    {
        x = transform.position.x;
        z = transform.position.z;

        skill1Spawn.x = x;
        skill1Spawn.z = z;
        Object.Destroy(gameObject, 2);
    }
}
