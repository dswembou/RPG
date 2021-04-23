using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] float chaseDistance = 5f;

    // Update is called once per frame
    void Update()
    {
        if(DistanceToPlayer() < chaseDistance)
        {
            print("Moet nu achtervolgen");
        }
    }

    private float DistanceToPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        return Vector3.Distance(player.transform.position, transform.position);
    }
}
