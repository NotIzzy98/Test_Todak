using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1Spawn : MonoBehaviour
{
    public GameObject projectile;
    public GameObject player;

    public GameObject skill1;

    public float x, z;

    public void Skill1Commence()
    {
        skill1 = Instantiate(projectile, transform.position, transform.rotation);
    }

    public void Phase2()
    {
        player.transform.position = new Vector3(x, 2, z);
        Destroy(skill1);
    }
}
