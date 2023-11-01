using System.Collections;
using UnityEngine;

public class PrepState : BattleState
{
    public PrepState(BattleSystem system)
        : base(system) { }

    public override IEnumerator EnterState()
    {
        base.EnterState();
        Debug.Log("Entering Preparation Phase");
        yield break;
    }

    public override IEnumerator ExitState()
    {
        base.ExitState();
        Debug.Log("Exiting Preparation Phase");
        yield break;
    }

    public override IEnumerator Update()
    {
        base.Update();
        yield break;
    }
}
