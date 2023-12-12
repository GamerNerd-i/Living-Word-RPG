using System.Collections;
using UnityEngine;

public class PlanningState : BattleState
{
    public PlanningState(BattleSystem system)
        : base(system) { }

    public override IEnumerator EnterState()
    {
        Debug.Log("Entering Planning Phase");

        yield return new WaitForSeconds(1f);

        if (true) // Scouting mode
        {
            Debug.Log("Initializing Scouting State");
            _system.SetBattleState(new ScoutingState(_system));
        }

        if (true) // Combat Begin
        {
            Debug.Log("Initializing Prep State");
            ExitState();
        }
    }

    public override IEnumerator ExitState()
    {
        Debug.Log("Exiting Planning Phase");
        _system.SetBattleState(new PrepState(_system));
        yield break;
    }

    public override IEnumerator Update()
    {
        base.Update();
        yield break;
    }
}
