using System;
using System.Collections.Generic;
using Kryz.CharacterStats;
using StatEnum;
using UnityEngine;

[Serializable]
public class StatBlock : ISerializationCallbackReceiver
{
    [Header("Levels and XP")]
    public int unitLevel = 1;
    public int xpCurrent = 0;
    public int xpToNext = 50;
    const int xpScale = 50;
    public Dictionary<Stat, CharacterStat> stats = new Dictionary<Stat, CharacterStat>();
    public Dictionary<Stat, CharacterStat> growths = new Dictionary<Stat, CharacterStat>();

    //Instance vars for serialization
    private int defaultStatLimit = 5;
    private float defaultGrowthLimit = 1f;

    [Header("Stats")]
    public List<Stat> _statNames = new List<Stat>();

    public List<CharacterStat> _statValues = new List<CharacterStat>();

    public List<CharacterStat> _growthValues = new List<CharacterStat>();

    public StatBlock()
    {
        var random = new System.Random();

        _statNames.Add(Stat.Willpower);
        _statNames.Add(Stat.Strength);
        _statNames.Add(Stat.Knowledge);
        _statNames.Add(Stat.Toughness);
        _statNames.Add(Stat.Resilience);
        _statNames.Add(Stat.Dexterity);
        _statNames.Add(Stat.Favor);

        foreach (var stat in _statNames)
        {
            stats.Add(stat, new CharacterStat(random.Next(1, defaultStatLimit + 1)));
            // Debug.Log(stat + ": " + stats[stat].Value.ToString());
            growths.Add(
                stat,
                new CharacterStat(
                    (float)Math.Round((random.NextDouble() * (defaultGrowthLimit - 0.1)) + 0.1, 2)
                )
            );
            // Debug.Log(stat + ": " + growths[stat].Value.ToString());
        }
    }

    public StatBlock(Dictionary<Stat, float[]> block)
    {
        foreach (var stat in block)
        {
            _statNames.Add(stat.Key);
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

        foreach (Stat stat in _statNames)
        {
            float growth = growths[stat].Value;
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

        foreach (Stat stat in _statNames)
        {
            _statValues.Add(stats[stat]);
            _growthValues.Add(growths[stat]);
        }
    }

    public void OnAfterDeserialize()
    {
        foreach (Stat stat in _statNames)
        {
            // Debug.Log(stat + "Index: " + (int)stat);
            // Debug.Log(_statValues[(int)stat].Value);
            stats[stat] = _statValues[(int)stat];
            growths[stat] = _growthValues[(int)stat];
        }
    }
}
