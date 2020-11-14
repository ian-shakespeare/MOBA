using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  public float ProjectileSpeed;
  public float MaxDistance;

  void Update() {
      transform.Translate( Vector3.forward * Time.deltaTime * ProjectileSpeed );
      MaxDistance += 1 * Time.deltaTime;

      if ( MaxDistance >= 5 ) {
        Destroy( this.gameObject );
      }
  }
}
