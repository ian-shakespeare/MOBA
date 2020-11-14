using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroKit : MonoBehaviour {
  public GameObject PlayerObject;
  public GameObject Projectile;
  public GameObject ProjectileSpawn;
  public GameObject Trap;
  private bool BasicAttackCD = false;
  private float BasicAttackCDTime;
  private bool AbilityQCD;
  private float AbilityQCDTime;

  void Update() {
    if ( Time.time - BasicAttackCDTime >= PlayerObject.GetComponent<Player>().getAttackSpeed() ) {
      BasicAttackCD = false;
    }
    if ( Time.time - AbilityQCDTime >= PlayerObject.GetComponent<Player>().getAbilityQCD() && AbilityQCD ) {
      AbilityQCD = false;
    }
  }

  public void BasicAttack() {
    if ( !BasicAttackCD ) {
      Instantiate( Projectile, ProjectileSpawn.transform.position, ProjectileSpawn.transform.rotation );
      BasicAttackCD = true;
      BasicAttackCDTime = Time.time;
      PlayerObject.GetComponent<Player>().audio.Play("Bow");
    }
  }
  public void AbilityQ() {
    if ( !AbilityQCD ) {
      Instantiate( Trap, ProjectileSpawn.transform.position, ProjectileSpawn.transform.rotation );
      PlayerObject.GetComponent<Player>().audio.Play("TrapSet");
      AbilityQCD = true;
      AbilityQCDTime = Time.time;
    }
  }
}
