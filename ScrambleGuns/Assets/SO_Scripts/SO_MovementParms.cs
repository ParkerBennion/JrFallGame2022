using UnityEngine;
[CreateAssetMenu]
public class SO_MovementParms : ScriptableObject
{
    public float speed;
    public bool isPlayer;
    public bool isActive;
    //public float bulletFireRate;
    public bool canShoot;
    public bool canJump;
    public GameObject bulletFab;
    public float fireRate;
}
