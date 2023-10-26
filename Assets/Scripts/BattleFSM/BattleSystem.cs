using Unity.VisualScripting;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public int turnCount = 0;
    public BattleStateMachine StateMachine { get; set; }
    public PlanningState PlanningPhase { get; set; }
    public ScoutingState ScoutingPhase { get; set; }
    public PrepState PrepPhase { get; set; }
    public CombatState CombatPhase { get; set; }

    private void Awake()
    {
        StateMachine = new BattleStateMachine();

        PlanningPhase = new PlanningState(StateMachine);
        ScoutingPhase = new ScoutingState(StateMachine);
        PrepPhase = new PrepState(StateMachine);
        CombatPhase = new CombatState(StateMachine);
    }

    private void Start()
    {
        Debug.Log("Starting Battle");
        Debug.Log(PlanningPhase == null);
        Debug.Log(ScoutingPhase == null);
        Debug.Log(PrepPhase == null);
        Debug.Log(CombatPhase == null);
        StateMachine.Initialize(PlanningPhase);
    }

    private void Update()
    {
        StateMachine.CurrentBattleState.Update();
    }
}
