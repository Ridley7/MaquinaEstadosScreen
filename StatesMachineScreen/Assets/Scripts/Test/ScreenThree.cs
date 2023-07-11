
using R_ScreenStateMachine;
using UnityEngine;
using UnityEngine.UI;

public class ScreenThree : R_State
{
    [SerializeField] private Button buttonFinish;

    public override R_StateType StateType => R_StateType.ScreenThree;

    public override R_StateType NextState => R_StateType.End;


    private void Finish()
    {
        StateMachine.SetState(R_StateType.End);
    }

    public override void ActivateState()
    {
        buttonFinish.onClick.AddListener(Finish);
    }

    public override void DeactivateState()
    {
        buttonFinish.onClick.RemoveListener(Finish);
    }
}
