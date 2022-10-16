using UnityEngine;
using UnityEngine.Events;

public class MasterCallerAction : MonoBehaviour
{
    public PawnListener_SO ListenerOB;

    public UnityEvent onRaiseEvent;
    private void Start()
    {
        ListenerOB.raise += Raise;
    }

    private void Raise()
    {
        onRaiseEvent.Invoke();
    }
}
