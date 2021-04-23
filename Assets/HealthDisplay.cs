using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private Health health;
    // Start is called before the first frame update
    void Awake()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            health.TakeDamage(10f);
        }
        GetComponent<Text>().text = String.Format("{0:0}%", health.GetPercentage());
        //GetComponent<Text>().text = health.GetPercentage().ToString() + "%";

    }
}
