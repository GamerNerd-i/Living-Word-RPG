using System.Collections;

public class BattleState
{
    protected readonly BattleSystem _system;

    public BattleState(BattleSystem system)
    {
        _system = system;
    }

    public virtual IEnumerator EnterState()
    {
        yield break;
    }

    public virtual IEnumerator ExitState()
    {
        yield break;
    }

    public virtual IEnumerator Update()
    {
        yield break;
    }
}
