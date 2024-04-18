using System.Collections;
using System.Collections.Generic;
using StatEnum;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;

    public StatBlock statBlock;
    public int maxHP;
    public int currentHP;
    public bool downed;

    public Unit(string name, StatBlock statBlock)
    {
        unitName = name;
        this.statBlock = statBlock;
        maxHP = (int)(statBlock.stats[Stat.Willpower].Value * 3);
        currentHP = maxHP;
        downed = false;
    }

    public bool TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            downed = true;
            currentHP = 0;
        }

        return downed;
    }

    public int BeHealed(int healing, Unit source = null)
    {
        int prevHP = currentHP;
        int nextHP = healing + currentHP;
        currentHP = nextHP >= maxHP ? maxHP : nextHP;
        int amtHealed = currentHP - prevHP;

        if (source != null)
        {
            source.statBlock.GainXP(amtHealed);
        }

        return amtHealed;
    }

    public int Attack(Unit target, Stat attacker, Stat defender)
    {
        var damage = statBlock.stats[attacker].Value;
        var reduction = target.statBlock.stats[defender].Value;
        var damageDealt = (int)(damage - reduction);

        if (TakeDamage(damageDealt))
        {
            statBlock.GainXP((int)target.statBlock.stats[Stat.Willpower].Value);
        }

        return damageDealt;
    }
}
