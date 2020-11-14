using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  public float ProjectileSpeed;
  public float MaxDistance;
  public int ProjectileDamage;
  public GameObject PlayerObject;

  void Update() {
      transform.Translate( Vector3.forward * Time.deltaTime * ProjectileSpeed );
      MaxDistance += 1 * Time.deltaTime;

      if ( MaxDistance >= 5 ) {
        Destroy( this.gameObject );
      }
  }
  public int getProjectileDamage() {
    return ProjectileDamage * PlayerObject.GetComponent<Player>().playerExp.GetLevel();
  }
  public bool getIsFriendly() {
    return PlayerObject.GetComponent<Player>().getIsFriendly();
  }
}
