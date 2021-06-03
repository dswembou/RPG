using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, ISaveable
{
    [SerializeField] private float healthPoints = 100f;

    private bool isDead = false;    
    // Start is called before the first frame update
    void Start()
    {
        //healthPoints = GetComponent<BaseStats>().GetStat(Stats.Health);
        //print("setting health points..");
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        healthPoints = Mathf.Max(healthPoints - damage, 0);
        if (healthPoints == 0)
        {
           Die();
        }
    }

    public float GetPercentage()
    {
        return 100 * (healthPoints / GetComponent<BaseStats>().GetStat(Stats.Health));
    }
    void Die()
    {
        if (isDead)
        {
            return;
        }
        else
        {
            isDead = true;
            GetComponentInChildren<Animator>().SetTrigger("die");
        }

    }

    void AwardExperience(GameObject instigator)
    {
        Experience experience = instigator.GetComponent<Experience>();
        if (experience == null) return;

        experience.GainExperience(GetComponent<BaseStats>().GetExperienceReward());
    }

    public object CaptureState()
    {
        return healthPoints;
    }

    public void RestoreState(object state)
    {
        print("restoring..");
        healthPoints = (float) state;
        if (healthPoints <= 0)
        {
            Die();
        }
    }
}