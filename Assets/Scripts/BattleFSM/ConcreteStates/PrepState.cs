using UnityEngine;

public class PrepState : BattleState
{
    public PrepState(BattleStateMachine battleFSM)
        : base(battleFSM) { }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Entering Preparation Phase");
    }

    public override void ExitState()
    {
        base.ExitState();
        Debug.Log("Exiting Preparation Phase");
    }

    public override void Update()
    {
        base.Update();
    }
}
