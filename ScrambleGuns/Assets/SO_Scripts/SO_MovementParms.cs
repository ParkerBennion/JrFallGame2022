using UnityEngine;
[CreateAssetMenu]
public class SO_MovementParms : ScriptableObject
{
    public float speed;
    //how fast they move across the screen
    
    public bool isActive;
    //null
    
    public bool canShoot;
    //if can currently shoot
    
    public GameObject bulletFab;
    //type of bullet it shoots
    
    public float fireRate;
    //fire rate
    
    public int[] codex;
    //the program the enemy will follow
    
    public string stopper;
    //maximum of 2 stoppers
}

