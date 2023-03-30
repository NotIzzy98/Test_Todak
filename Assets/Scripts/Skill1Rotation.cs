using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1Rotation : MonoBehaviour
{
    public Skill1JoyStick skill1JoyStick;
    public bool flipRot = true;

    void Update()
    {
        float horizontal = Skill1JoyStick.Horizontal;
        float vertical = Skill1JoyStick.Vertical;
        float angle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
        angle = flipRot ? -angle : angle;
        transform.rotation = Quaternion.Euler(new Vector3(90, 0, angle));
    }
}
