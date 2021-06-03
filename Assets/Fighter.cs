using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] float timeBetweenAttacks = 1f;
    [SerializeField] private Weapon weapon = null;
    [SerializeField] private Transform rightHand, leftHand;

    float timeSinceLastAttack = 0;

    Transform target;

    void Start()
    {
        EquipWeapon();
    }

    void EquipWeapon()
    {
        if (weapon == null) return;
        Animator animator = GetComponent<Animator>();
        weapon.Spawn(rightHand, animator);
    }

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
        return Vector3.Distance(transform.position, target.position) < weapon.GetRange();
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
        if (target == null) return;
        if (weapon.HasProjectile())
        {
            weapon.LaunchProjectile(rightHand, leftHand, target);
        }
        Health health = target.GetComponent<Health>();
        health.TakeDamage(weapon.GetDamage());
    }

    void Shoot()
    {
        Hit();
    }
}
