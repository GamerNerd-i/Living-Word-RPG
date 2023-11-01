using System.Collections;
using UnityEngine;

public class CombatState : BattleState
{
    public CombatState(BattleSystem system)
        : base(system) { }

    public override IEnumerator EnterState()
    {
        base.EnterState();

        Debug.Log("Entering Combat Phase");
        yield break;
    }

    public override IEnumerator ExitState()
    {
        base.ExitState();

        Debug.Log("Exiting Combat Phase");
        yield break;
    }

    public override IEnumerator Update()
    {
        base.Update();
        yield break;
    }
}
