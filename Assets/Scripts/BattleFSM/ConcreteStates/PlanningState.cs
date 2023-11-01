using System.Collections;
using UnityEngine;

public class PlanningState : BattleState
{
    public PlanningState(BattleSystem system)
        : base(system) { }

    public override IEnumerator EnterState()
    {
        base.EnterState();

        Debug.Log("Entering Planning Phase");
        yield break;
    }

    public override IEnumerator ExitState()
    {
        base.ExitState();

        Debug.Log("Exiting Planning Phase");
        yield break;
    }

    public override IEnumerator Update()
    {
        base.Update();
        yield break;
    }
}
