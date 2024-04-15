using System;
using System.Collections.Generic;
using Kryz.CharacterStats;
using StatEnum;

[Serializable]
public class StatBlock
{
    public int unitLevel = 1;
    public int xpCurrent = 0;
    private int xpToNext = 50;
    const int xpScale = 50;
    public readonly Dictionary<Stat, CharacterStat> stats = new Dictionary<Stat, CharacterStat>();
    readonly Dictionary<Stat, CharacterStat> growths = new Dictionary<Stat, CharacterStat>();

    public StatBlock(Dictionary<Stat, float[]> block)
    {
        foreach (var stat in block)
        {
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
        var random = new Random();
        Dictionary<Stat, int> statUps = new Dictionary<Stat, int>();

        foreach (Stat stat in stats.Keys)
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
}
