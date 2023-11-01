using System.Collections;
using UnityEngine;

public class ScoutingState : BattleState
{
    public ScoutingState(BattleSystem system)
        : base(system) { }

    public override IEnumerator EnterState()
    {
        base.EnterState();

        Debug.Log("Entering Scouting Mode");
        yield break;
    }

    public override IEnumerator ExitState()
    {
        base.ExitState();
        Debug.Log("Exiting Scouting Mode");
        yield break;
    }

    public override IEnumerator Update()
    {
        base.Update();
        yield break;
    }
}
