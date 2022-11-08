using UnityEngine;
using System.Collections;
public class BulletBasic : MonoBehaviour
{
    public SO_Vector3 startPosition;
    public SO_Vector3 endPosition;

    private Rigidbody rb;
    private WaitForSeconds half;
    private Vector3 bulletSize,endBulletSize;
    

    private void Awake()
    {
        transform.position = startPosition.position;
        rb = GetComponent<Rigidbody>();
        half = new WaitForSeconds(.5f);
        //bulletSize = new Vector3(.27f, .27f, .27f);
        //endBulletSize = new Vector3(.5f, .5f, .5f);
        //Debug.Log(endPosition.position);
        //Debug.Log(startPosition.position);
    }

    private void Start()
    {
        StartCoroutine(destruct());
    }


    void Update()
    {
        rb.transform.position = Vector3.Lerp(transform.position, endPosition.position,  .01f);
        //transform.localScale = Vector3.Lerp(bulletSize,endBulletSize,.1f);
    }

    private IEnumerator destruct()
    {
        yield return half;
        Destroy(gameObject);
    }
}
