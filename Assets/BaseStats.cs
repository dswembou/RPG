using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    [Range(1, 99)] [SerializeField] private int startingLevel = 1;
    [SerializeField] private CharacterClass characterClass;
    [SerializeField] private Progression progression = null;

    public float GetStat(Stats stat)
    {
        return progression.GetStat(stat, characterClass, startingLevel);
    }

    public float GetExperienceReward()
    {
        return 10;
    }
}
