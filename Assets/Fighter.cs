using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] float weaponRange = 2f;
    [SerializeField] float timeBetweenAttacks = 1f;
    [SerializeField] float weaponDamage = 20f;


    float timeSinceLastAttack = 0;

    Transform target;

    private void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
        if (target == null) return;
        
        if(!GetIsInRange())
        {
            GetComponent<Mover>().MoveTo(target.position);
        }
        else
        {
            GetComponent<Mover>().Stop();
            AttackAnimation();
        }
    }

    void AttackAnimation()
    {
        if(timeSinceLastAttack > timeBetweenAttacks)
        {
            GetComponent<Animator>().SetTrigger("attack");
            timeSinceLastAttack = 0f;
        }
    }

    private bool GetIsInRange()
    {
        return Vector3.Distance(transform.position, target.position) < weaponRange;
    }
    public void Attack(CombatTarget combatTarget)
    {
        print("Take that you dirty peasant!");
        target = combatTarget.transform;
    }

    public void Cancel()
    {
        target = null;
    }

    // Animation event
    void Hit()
    {
        Health health = target.GetComponent<Health>();
        health.TakeDamage(weaponDamage);
    }
}
