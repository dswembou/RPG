using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target = null;
    [SerializeField] private float speed = 1f;
    
    void Update()
    {
        if (target == null) return;
        
        transform.LookAt(GetAimLocation());
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void SetTarget(Transform newTarget)
    {
        this.target = newTarget;
    }

    private Vector3 GetAimLocation()
    {
        CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();
        if (targetCapsule == null)
        {
            return target.position;
        }
        return target.position + Vector3.up * targetCapsule.height / 2;
    }
}
