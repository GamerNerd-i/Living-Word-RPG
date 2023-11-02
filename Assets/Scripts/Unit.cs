using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public int maxHP;
    public int currentHP;

    // [SerializeField]
    // private Dictionary<string, (int, decimal)> statBlock = new Dictionary<
    //     string,
    //     (int value, decimal growth)
    // >(6)
    // {
    //     { "Willpower", (0, 0) },
    //     { "Strength", (0, 0) },
    //     { "Knowledge", (0, 0) },
    //     { "Resilience", (0, 0) },
    //     { "Dexterity", (0, 0) },
    //     { "Favor", (0, 0) },
    // };
    public int willpower,
        strength,
        knowledge,
        resilience,
        dexterity;
}
