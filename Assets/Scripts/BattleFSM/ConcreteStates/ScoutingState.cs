using UnityEngine;

public class ScoutingState : BattleState
{
    public ScoutingState(BattleStateMachine battleFSM)
        : base(battleFSM) { }

    public override void EnterState()
    {
        base.EnterState();

        Debug.Log("Entering Scouting Mode");
    }

    public override void ExitState()
    {
        base.ExitState();
        Debug.Log("Exiting Scouting Mode");
    }

    public override void Update()
    {
        base.Update();
    }
}
