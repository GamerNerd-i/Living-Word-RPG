using System;
using System.Collections.Generic;
using Kryz.CharacterStats;
using StatEnum;
using UnityEngine;

[Serializable]
public class StatBlock : ISerializationCallbackReceiver
{
    public int unitLevel = 1;
    public int xpCurrent = 0;
    public int xpToNext = 50;
    const int xpScale = 50;
    public Dictionary<Stat, CharacterStat> stats = new Dictionary<Stat, CharacterStat>();
    public Dictionary<Stat, CharacterStat> growths = new Dictionary<Stat, CharacterStat>();

    //Instance vars for serialization
    private int defaultStat = 1;
    private float defaultGrowth = 0.5f;

    public List<Stat> _keys = new List<Stat>();
    public List<CharacterStat> _statValues = new List<CharacterStat>();
    public List<CharacterStat> _growthValues = new List<CharacterStat>();

    public StatBlock()
    {
        _keys.Add(Stat.Willpower);
        _keys.Add(Stat.Strength);
        _keys.Add(Stat.Knowledge);
        _keys.Add(Stat.Toughness);
        _keys.Add(Stat.Resilience);
        _keys.Add(Stat.Dexterity);
        _keys.Add(Stat.Favor);

        foreach (var stat in _keys)
        {
            stats.Add(stat, new CharacterStat(defaultStat));
            growths.Add(stat, new CharacterStat(defaultGrowth));
        }
    }

    public StatBlock(Dictionary<Stat, float[]> block)
    {
        foreach (var stat in block)
        {
            _keys.Add(stat.Key);
            stats.Add(stat.Key, new CharacterStat(stat.Value[0]));
            growths.Add(stat.Key, new CharacterStat(stat.Value[1]));
        }
    }

    public Dictionary<Stat, int> GainXP(int xp)
    {
        xpCurrent += xp;
        Dictionary<Stat, int> totalStatUps = new Dictionary<Stat, int>();
        foreach (var stat in stats.Keys)
        {
            totalStatUps.Add(stat, 0);
        }

        while (xpCurrent >= xpToNext)
        {
            var statUps = LevelUp();
            foreach (var stat in stats.Keys)
            {
                totalStatUps[stat] += statUps[stat];
            }
        }

        return totalStatUps;
    }

    public Dictionary<Stat, int> LevelUp()
    {
        unitLevel += 1;
        xpCurrent = xpCurrent >= xpToNext ? xpCurrent - xpToNext : 0;
        xpToNext += xpScale;

        return RollStatIncreases();
    }

    private Dictionary<Stat, int> RollStatIncreases()
    {
        var random = new System.Random();
        Dictionary<Stat, int> statUps = new Dictionary<Stat, int>();

        foreach (Stat stat in _keys)
        {
            var growth = growths[stat].Value;
            int bonus = 0;

            while (growth >= 1.0)
            {
                bonus++;
                growth--;
            }

            bonus += random.NextDouble() < growth ? 1 : 0;

            stats[stat].BaseValue += bonus;
            statUps.Add(stat, bonus);
        }

        return statUps;
    }

    public void OnBeforeSerialize()
    {
        _statValues.Clear();
        _growthValues.Clear();

        foreach (Stat stat in _keys)
        {
            _statValues.Add(stats[stat]);
            _growthValues.Add(growths[stat]);
        }
    }

    public void OnAfterDeserialize()
    {
        foreach (Stat stat in _keys)
        {
            stats[stat] = _statValues[(int)stat];
            growths[stat] = _statValues[(int)stat];
        }
    }
}
