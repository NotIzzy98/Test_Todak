using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2Start : MonoBehaviour
{
    public GameObject Skill2Cursor;
    public GameObject Skill2Cube;
    public GameObject indicator;
    public float a, b;

    public GameObject center;
    public Transform player;

    public Skill2Movement skill2Movement;
    
    public void Skill2Commence()
    {
        indicator = Instantiate(Skill2Cursor, transform.position, transform.rotation, center.transform);
    }

    public void Skill2Done()
    {
        Destroy(indicator);
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x, 2, player.position.z);
    }

    public void SummonSkill2()
    {
        Instantiate(Skill2Cube, new Vector3(a, 2, b), Quaternion.identity);
    }
}
