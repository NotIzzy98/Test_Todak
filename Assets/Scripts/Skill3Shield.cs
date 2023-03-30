using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3Shield : MonoBehaviour
{
    public Transform Player;

    void Awake()
    {
        Player = GameObject.Find("Player").GetComponent<Transform>();
        Destroy(gameObject, 4);
    }
}
