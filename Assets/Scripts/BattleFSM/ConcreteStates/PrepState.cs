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

        //Turn Actions

        //Scouting Mode

        //Combat Phase
        if (true)
        {
            ExitState();
            yield break;
        }
    }

    public override IEnumerator ExitState()
    {
        Debug.Log("Exiting Preparation Phase");
        _system.SetBattleState(new CombatState(_system));
        yield break;
    }

    public override IEnumerator Update()
    {
        base.Update();
        yield break;
    }
}
