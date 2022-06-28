using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewActive", menuName = "Skills/ActiveSkill")]
public class ActiveSkill : Skills
{
    public int apCost;
    public float baseDamage;
    private float damage;
    public float multiplier;
    public bool isPhysical;
    public StatusElements element;

    public bool isMovement;

    public float CalcDamage(CharStats stats, Dictionary<StatusElements, float> elemBuff = null)
    {
        if (isPhysical)
        {
            damage = stats.physicalDamage * multiplier + baseDamage;
        }
        else
        {
            damage = stats.magicalDamage * multiplier + baseDamage;
        }
        if (elemBuff != null && element != StatusElements.None)
        {
            damage *= elemBuff[element];
        }
        return Mathf.Round(damage);
    }
    public float CalcDamage(float damage)
    {
        this.damage = damage;
        return damage;
    }

}
