using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    public GameObject projectile;

    public void BasicAttackCommence()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
