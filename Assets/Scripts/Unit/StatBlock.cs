using System;
using System.Collections.Generic;
using Kryz.CharacterStats;
using StatEnum;

[Serializable]
public class StatBlock
{
    public int unitLevel = 1;
    public int xpCurrent = 0;
    public int xpToNext = 50;
    readonly Dictionary<Stat, CharacterStat> stats = new Dictionary<Stat, CharacterStat>();
    readonly Dictionary<Stat, CharacterStat> growth = new Dictionary<Stat, CharacterStat>();

    public StatBlock(Dictionary<Stat, float[]> block)
    {
        foreach (var stat in block)
        {
            stats.Add(stat.Key, new CharacterStat(stat.Value[0]));
            growth.Add(stat.Key, new CharacterStat(stat.Value[1]));
        }
    }
}
