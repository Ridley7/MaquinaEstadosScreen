using System;
using System.Collections.Generic;
using UnityEngine;

namespace R_ScreenStateMachine
{
    public abstract class R_StateMachine : MonoBehaviour
    {
        private readonly Stack<R_StateType> previousStates = new Stack<R_StateType>();
        private readonly Dictionary<R_StateType, R_State> stateTypeMap = new Dictionary<R_StateType, R_State>();

        [SerializeField] protected List<R_StateType> statesToSkip;

        protected Action<R_StateType, R_StateType> StateChanged;
        private R_StateType currentState;

        protected void Initialize(List<R_State> estados)
        {
            foreach (var estado in estados)
            {
                stateTypeMap.Add(estado.StateType, estado);
            }
        }

        public void SetState(R_StateType stateType)
        {
            //Guardamos el estado actual
            var previousState = currentState;

            //Si el estados actual no es None, hacemos cosas
            if (previousState != R_StateType.None)
            {
                //La primera es desactivar el estado actual
                DeactivateState(stateTypeMap[previousState]);

                //Comprobamos si es un estado que tenemos que saltarnos por algun motivo
                if (statesToSkip.Contains(stateType))
                {
                    SetState(stateTypeMap[stateType].NextState);
                    return;
                }

                //Si no es un estado que lo tengamos que saltar, lo estaqueamos en la pila
                previousStates.Push(previousState);
            }

            //Asignamos el nuevo estado actual
            currentState = stateType;

            //Si no estamos ante el estado final no lo activamos
            if (stateType != R_StateType.End)
            {
                //Activamos el nuevo estado
                //stateTypeMap[currentState].gameObject.SetActive(true);
                ActivateState(stateTypeMap[currentState]);

            }

            //Indicamos a todos los que esten suscritos al evento StateChanged que se ha producido
            //un cambio de estado. Aparte avisamos cual era el estado anterior y cual es el actual
            StateChanged?.Invoke(currentState, previousState);
        }

        protected void ClearPreviousStates()
        {
            //Limpiamos la pila
            previousStates.Clear();
        }

        public void GoToPreviousState()
        {
            //Regresamos a un estado anterior
            var previousState = currentState;
            DeactivateState(stateTypeMap[previousState]);
            //Obtenemos el estado anterior
            currentState = previousStates.Pop();
            if (currentState != R_StateType.None)
            {
                //Activamos el estado anterior
                ActivateState(stateTypeMap[currentState]);
                //Avisamos de que se ha cambiado el estado
                StateChanged?.Invoke(currentState, previousState);
            }
        }

        private void ActivateState(R_State state)
        {
            state.gameObject.SetActive(true);
            state.ActivateState();
        }

        private void DeactivateState(R_State state)
        {
            state.gameObject.SetActive(false);
            state.DeactivateState();
        }
    }
}


