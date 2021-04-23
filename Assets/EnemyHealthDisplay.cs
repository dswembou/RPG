using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthDisplay : MonoBehaviour
{
    private Health health;
    //private GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        health = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Health>();
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = String.Format("{0:0}%", health.GetPercentage());
    }
}
