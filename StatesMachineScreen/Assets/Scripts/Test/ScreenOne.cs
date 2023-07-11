
using R_ScreenStateMachine;
using UnityEngine;
using UnityEngine.UI;

public class ScreenOne : R_State
{
    [SerializeField] private Button buttonScreenTwo;

    public override R_StateType StateType => R_StateType.ScreenOne;

    public override R_StateType NextState => R_StateType.ScreenTwo;


    private void GoToScreenTwo()
    {
        Debug.Log("CLickando boton screen dos");
        StateMachine.SetState(R_StateType.ScreenTwo);
    }

    public override void ActivateState()
    {
        Debug.Log("On enable");
        buttonScreenTwo.onClick.AddListener(GoToScreenTwo);
    }

    public override void DeactivateState()
    {
        buttonScreenTwo.onClick.RemoveListener(GoToScreenTwo);
    }
}
