using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public JoyStickController joyStickController;
    public bool flipRot = true;

    void Update()
    {
        float horizontal = JoyStickController.Horizontal;
        float vertical = JoyStickController.Vertical;
        float angle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
        angle = flipRot ? -angle : angle;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
