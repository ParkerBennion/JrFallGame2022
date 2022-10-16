using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu]
public class PawnListener_SO : ScriptableObject
{
    public UnityAction raise;

    public void RaiseAction()
    {
        raise?.Invoke();
    }
}
