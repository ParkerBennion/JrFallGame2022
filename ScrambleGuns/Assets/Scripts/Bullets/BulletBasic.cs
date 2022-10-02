using UnityEngine;
using System.Collections;
public class BulletBasic : MonoBehaviour
{
    public SO_Vector3 startPosition;
    public SO_Vector3 endPosition;

    private Rigidbody rb;
    private WaitForSeconds half;

    private void Awake()
    {
        transform.position = startPosition.position;
        rb = GetComponent<Rigidbody>();
        half = new WaitForSeconds(.5f);
        //Debug.Log(endPosition.position);
        //Debug.Log(startPosition.position);
    }

    private void Start()
    {
        StartCoroutine(destruct());
    }


    void Update()
    {
        //rb.velocity = Vector.Lerp(transform.position, endPosition.position, transform.position + Vector3.right * (PawnAttributesSO.speed * Time.deltaTime);
        rb.transform.position = Vector3.Lerp(transform.position, endPosition.position,  .1f);
    }

    private IEnumerator destruct()
    {
        yield return half;
        Destroy(gameObject);
    }
}
