using System.Collections;
using UnityEngine;

public class ReticleFollow : MonoBehaviour
{
    private Camera cameraObj;
    private bool dragable;
    private Vector3 position, offset;

    private void Start()
    {
        cameraObj = Camera.main;
        StartCoroutine(followCursor());
    }

    public IEnumerator followCursor()
    {
        offset = transform.position - cameraObj.ScreenToWorldPoint(Input.mousePosition);
        dragable = true;
        yield return new WaitForFixedUpdate();
        
        
        while (dragable)
        {
            yield return new WaitForFixedUpdate();
            position = cameraObj.ScreenToWorldPoint(Input.mousePosition)+offset;
            transform.position = position;
        }
    }
}