using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateMachine
{
    public BattleState CurrentBattleState { get; set; }

    public void Initialize(BattleState startingState)
    {
        Debug.Log("Entering initial state");
        Debug.Log(startingState == null);
        CurrentBattleState = startingState;
        CurrentBattleState.EnterState();
    }
}
