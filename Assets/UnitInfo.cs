using System.Collections;
using System.Collections.Generic;
using StatEnum;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UnitInfo : MonoBehaviour
{
    [Header("Unit Data")]
    public Unit selectedUnit;
    public StatBlock selectedStats;

    [Header("Flavor Info")]
    public TextMeshProUGUI unitName;

    [Header("Battle Info")]
    public GameObject healthDisplay;
    private UnityEngine.UI.Slider healthBar;
    public List<GameObject> displayStats = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        healthBar = healthDisplay.GetComponent<UnityEngine.UI.Slider>();
        healthBar.maxValue = selectedUnit.maxHP;

        selectedStats = selectedUnit.statBlock;

        unitName.text = selectedUnit.unitName;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = selectedUnit.currentHP;

        foreach (Stat stat in selectedStats._statNames)
        {
            if (stat == Stat.Willpower)
            {
                continue;
            }

            TextMeshProUGUI statText = displayStats[(int)stat - 1]
                .transform.GetChild(1)
                .gameObject.GetComponent<TextMeshProUGUI>();

            statText.text = ((int)selectedStats.stats[stat].Value).ToString();
        }
    }
}
