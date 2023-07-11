
using R_ScreenStateMachine;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTwo : R_State
{
    [SerializeField] private Button buttonScreenThree;

    public override R_StateType StateType => R_StateType.ScreenTwo;

    public override R_StateType NextState => R_StateType.ScreenThree;


    private async void GoToScreenThree()
    {
        //Activamos el loading manager
        LoadingManager.EnableLoading("Cargando");

        //Hacemos una espera
        await Espera(10000);

        //Desactivamos el loading manager
        LoadingManager.DisableLoading();

        //Cargamos la siguiente pantalla
        StateMachine.SetState(R_StateType.ScreenThree);
    }

    private async Task Espera(int milisegundos)
    {
        await Task.Delay(milisegundos);
    }

    public override void ActivateState()
    {
        buttonScreenThree.onClick.AddListener(GoToScreenThree);
    }

    public override void DeactivateState()
    {
        buttonScreenThree.onClick.RemoveListener(GoToScreenThree);
    }
}
