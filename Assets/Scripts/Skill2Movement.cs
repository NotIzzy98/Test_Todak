using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2Movement : MonoBehaviour
{
    public float moveSpeed = 1;
    public float a, b;

    public Skill2JoyStick skill2JoyStick;
    public Skill2Start skill2Start;

    void Awake()
    {
        skill2Start = GameObject.Find("Skill2").GetComponent<Skill2Start>();
    }

    void Update()
    {
        float x = Skill2JoyStick.Horizontal;
        float z = Skill2JoyStick.Vertical;
        transform.localPosition = new Vector3(x, 0, z) * moveSpeed;

        a = transform.position.x;
        b = transform.position.z;

        skill2Start.a = a;
        skill2Start.b = b;

    }
}
