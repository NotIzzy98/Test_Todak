using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3Start : MonoBehaviour
{
    public GameObject shield;
    public GameObject player;

    public void SpawnShield()
    {
        GameObject skill3 = Instantiate(shield, transform.position, Quaternion.identity, player.transform);
        Destroy(skill3, 4);
    }
}
