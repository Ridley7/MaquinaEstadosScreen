
using UnityEngine;

namespace R_ScreenStateMachine
{
    public enum R_StateType
    {
        None,
        ScreenOne,
        ScreenTwo,
        ScreenThree,
        End,
    }

    public abstract class R_State : MonoBehaviour
    {
        protected R_StateMachine StateMachine;
        protected R_LoadingManager LoadingManager;

        public abstract R_StateType StateType { get; }
        public abstract R_StateType NextState { get; }

        public abstract void ActivateState();

        public abstract void DeactivateState();

        public void Initialize(R_StateMachine stateMachine, R_LoadingManager loadingManager)
        {
            StateMachine = stateMachine;
            LoadingManager = loadingManager;
            gameObject.SetActive(false);

        }
    }
}


