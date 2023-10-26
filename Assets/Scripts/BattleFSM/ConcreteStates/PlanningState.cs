using UnityEngine;

public class PlanningState : BattleState
{
    public PlanningState(BattleStateMachine battleFSM)
        : base(battleFSM) { }

    public override void EnterState()
    {
        base.EnterState();

        Debug.Log("Entering Planning Phase");
    }

    public override void ExitState()
    {
        base.ExitState();

        Debug.Log("Exiting Planning Phase");
    }

    public override void Update()
    {
        base.Update();
    }
}
