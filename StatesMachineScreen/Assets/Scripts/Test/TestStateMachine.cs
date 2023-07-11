using R_ScreenStateMachine;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestStateMachine : R_StateMachine
{
    [SerializeField] private List<R_State> estados;
    [SerializeField] private Button botonAtras;
    [SerializeField] private R_LoadingManager loadingManager;
    [SerializeField] private R_StateType estadoInicial;

    //Esta accion sera la que se ejecute cuando se llegue al estado
    //final. Con mas soltura simplemente se hara uso de la mensajeria.
    public Action<string> FinalAction;

    private void Start()
    {
        Initialize();

        SetState(estadoInicial);
    }

    private void OnEnable()
    {
        StateChanged += OnStateChanged;
        botonAtras.onClick.AddListener(GoToPreviousState);
    }

    private void OnDisable()
    {
        StateChanged -= OnStateChanged;
        botonAtras.onClick.RemoveListener(GoToPreviousState);
    }


    private void OnStateChanged(R_StateType currentState, R_StateType previousState)
    {
        botonAtras.gameObject.SetActive(!PuedoMostrarBotonAtras(currentState));

        Debug.Log("El estado actual es: " + currentState);

        if (currentState == R_StateType.End)
        {
            FinalAction?.Invoke("Fin");
        }
    }

    private void Initialize()
    {
        foreach (var estado in estados)
        {
            estado.Initialize(this, loadingManager);
        }

        base.Initialize(estados);
    }

    private bool PuedoMostrarBotonAtras(R_StateType currentState)
    {
        //Aqui tengo que poner los estados en los que no quiero mostrar el boton atras
        //return currentState == R_StateType.BodyTypeSelection || currentState == R_StateType.LoginWithCodeFromEmail || currentState == R_StateType.AvatarSelection;
        return currentState == R_StateType.ScreenOne || currentState == R_StateType.ScreenThree;
    }


}
