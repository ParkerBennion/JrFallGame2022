using UnityEngine;

public class TrackPosition : MonoBehaviour
{
    public SO_Vector3 currentPosition;

    private void Update()
    {
        currentPosition.position = transform.position;
    }

    public void printPosition()
    {
        Debug.Log(currentPosition.position);
    }
}
