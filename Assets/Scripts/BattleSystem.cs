using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    START,
    PLAYERTURN,
    ENEMYTURN,
    WON,
    LOST
}

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    public GameObject allyPrefab;
    public GameObject enemyPrefab;
    Unit allyUnit;
    Unit enemyUnit;

    public Transform allyTile;
    public Transform enemyTile;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        GameObject playerGO = Instantiate(allyPrefab, allyTile);
        allyUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyTile);
        enemyUnit = enemyGO.GetComponent<Unit>();
    }
}
