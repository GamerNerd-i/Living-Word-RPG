using System.Collections;
using UnityEngine;

public class CombatState : BattleState
{
    //public PriorityQueue<string, int> actions = new PriorityQueue<string, int>();

    public CombatState(BattleSystem system)
        : base(system) { }

    public override IEnumerator EnterState()
    {
        Debug.Log("Entering Combat Phase");

        for (int action = 3; action > 0; action--)
        {
            Debug.Log("Running combat action: " + action);

            yield return new WaitForSeconds(2f);
        }

        Debug.Log("Checking Win conditions");

        ExitState();
    }

    public override IEnumerator ExitState()
    {
        Debug.Log("Exiting Combat Phase");
        yield return new WaitForSeconds(2f);
        Debug.Log("Returning to Prep Phase");
        _system.SetBattleState(new PrepState(_system));
        yield break;
    }

    public override IEnumerator Update()
    {
        base.Update();
        yield break;
    }
}
