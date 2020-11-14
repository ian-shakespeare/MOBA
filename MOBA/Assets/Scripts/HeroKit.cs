using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroKit : MonoBehaviour {
  public GameObject PlayerObject;
  public GameObject Projectile;
  public GameObject ProjectileSpawn;
  private bool BasicAttackCD = false;
  private float BasicAttackCDTime;

  void Update() {
    if ( Time.time - BasicAttackCDTime >= PlayerObject.GetComponent<Player>().getAttackSpeed() ) {
      BasicAttackCD = false;
    }
  }

  public void BasicAttack() {
    if ( !BasicAttackCD ) {
      Instantiate( Projectile, ProjectileSpawn.transform.position, ProjectileSpawn.transform.rotation );
      BasicAttackCD = true;
      BasicAttackCDTime = Time.time;
    }
  }
  public void AbiltyQ() {

  }
  public void AbilityE() {

  }
  public void AbilityRMB() {

  }
  public void UltimateAbility() {

  }
}
