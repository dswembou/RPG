using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
public class Weapon : ScriptableObject
{
    [SerializeField] private AnimatorOverrideController animatorOverride = null;
    [SerializeField] private GameObject weaponPrefab = null;
    [SerializeField] private float weaponDamage = 5f;
    [SerializeField] private float weaponRange = 2f;
    [SerializeField] private Projectile projectile = null;
    [SerializeField] private bool isRightHanded = true;

    public void Spawn(Transform handTransform, Animator animator)
    {
        Instantiate(weaponPrefab, handTransform);
        animator.runtimeAnimatorController = animatorOverride;
    }

    private Transform GetTransform(Transform rightHand, Transform leftHand)
    {
        Transform handTransform;
        handTransform = isRightHanded ? rightHand : leftHand;
        return handTransform;
    }

    public bool HasProjectile()
    {
        return projectile != null;
    }

    public void LaunchProjectile(Transform rightHand, Transform leftHand, Transform target)
    {
        Projectile projectileInstance =
            Instantiate(projectile, GetTransform(rightHand, leftHand).position, Quaternion.identity);
        projectileInstance.SetTarget(target);
    }

    public float GetDamage()
    {
        return weaponDamage;
    }

    public float GetRange()
    {
        return weaponRange;
    }
}
