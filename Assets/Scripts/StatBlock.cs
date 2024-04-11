using System;
using System.Collections.Generic;
using Kryz.CharacterStats;

[Serializable]
public class StatBlock
{
    public Dictionary<string, CharacterStat> stats = new Dictionary<string, CharacterStat>();
    public Dictionary<string, CharacterStat> growth = new Dictionary<string, CharacterStat>();

    public StatBlock(
        Dictionary<string, CharacterStat> stats,
        Dictionary<string, CharacterStat> growth
    )
    {
        this.stats = stats;
        this.growth = growth;
    }
}
