using UnityEngine;

public class ColorShift : MonoBehaviour
{
    public SpriteRenderer[] Renderers; //objects that you want to change

    public Color[] startColors;
    public Color[] endColors;

    public float destroyTime;
    private float elapsTime;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Renderers.Length; i++)
        {
            Renderers[i].color = startColors[i].linear;
        }//sets color
    }
    private void Update()
    {
        elapsTime += Time.deltaTime;
       float percentageComplete = elapsTime / destroyTime;

       for (int i = 0; i < Renderers.Length; i++)
       {
           Renderers[i].color = Vector4.Lerp(startColors[i], endColors[i], percentageComplete);
       }//changes color over time of all selected sprites.
    }
}
