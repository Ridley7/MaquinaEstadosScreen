
using UnityEngine;

public class TestGameManager : MonoBehaviour
{
    [SerializeField] private TestStateMachine testStateMachine;

    private void OnEnable()
    {
        testStateMachine.FinalAction += OnFinalAction;
    }

    private void OnDisable()
    {
        testStateMachine.FinalAction -= OnFinalAction;
    }

    private void OnFinalAction(string message_finish)
    {
        testStateMachine.gameObject.SetActive(false);

        //Llegamos al final de nuestro wizards
        Debug.Log("Nuestra maquina de estados nos dice que: " + message_finish);
    }
}
