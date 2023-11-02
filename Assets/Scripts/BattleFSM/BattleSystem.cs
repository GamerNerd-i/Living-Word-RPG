using System;
using UnityEngine;

public enum State
{
    Combat,
    Planning,
    Preparation,
    Scouting
}

public class BattleSystem : MonoBehaviour
{
    public int turnCount = 0;

    private BattleState CurrentBattleState;

    public void SetBattleState(State state)
    {
        CurrentBattleState = state switch
        {
            State.Planning => new PlanningState(this),
            State.Scouting => new ScoutingState(this),
            State.Preparation => new PrepState(this),
            State.Combat => new CombatState(this),
            _
                => throw new ArgumentOutOfRangeException(
                    nameof(state),
                    $"Undefined BattleState: {state}"
                ),
        };

        StartCoroutine(CurrentBattleState.EnterState());
    }

    private void Start()
    {
        Debug.Log("Starting Battle");
        SetBattleState(State.Planning);
    }

    private void Update()
    {
        CurrentBattleState.Update();
    }
}
