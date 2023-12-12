using System;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public int turnCount = 0;

    private BattleState CurrentBattleState;

    public void SetBattleState(BattleState state)
    {
        CurrentBattleState = state;

        StartCoroutine(CurrentBattleState.EnterState());
    }

    private void Start()
    {
        Debug.Log("Starting Battle");
        SetBattleState(new PlanningState(this));
    }

    private void Update()
    {
        CurrentBattleState.Update();
    }
}
