using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState
{
    protected BattleStateMachine battleFSM;

    public BattleState(BattleStateMachine battleFSM)
    {
        this.battleFSM = battleFSM;
    }

    public virtual void EnterState() { }

    public virtual void ExitState() { }

    public virtual void Update() { }
}
