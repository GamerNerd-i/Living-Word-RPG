using UnityEngine;

public class CombatState : BattleState
{
    public CombatState(BattleStateMachine battleFSM)
        : base(battleFSM) { }

    public override void EnterState()
    {
        base.EnterState();

        Debug.Log("Entering Combat Phase");
    }

    public override void ExitState()
    {
        base.ExitState();

        Debug.Log("Exiting Combat Phase");
    }

    public override void Update()
    {
        base.Update();
    }
}
