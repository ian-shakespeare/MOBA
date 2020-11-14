using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    public bool isFriendly;
    public float AttackRange;
    public Health TowerHealth;
    public int TowerDamage;
    public double AttackSpeed;

    // Checks to see if enemy is in range, attacks accordingly
    void Update() {
      if ( TowerHealth.GetHealth() <= 0 ) {
        Destroy( this.gameObject );
      }
      GameObject Enemy = enemyInRange();
      if ( Enemy != null && Time.time % AttackSpeed <= 0.005 ) {
        attack( Enemy );
      }
    }

    // Attack code
    void attack( GameObject enemy ) {
      if ( enemy.GetComponent<Minion>() != null ) {
        Minion minion = enemy.gameObject.GetComponent<Minion>();
        minion.MinionHealth.ModifyHealth( TowerDamage );
      }
      else if ( enemy.GetComponent<Player>() != null ) {
        Player player = enemy.gameObject.GetComponent<Player>();
        player.playerHealth.ModifyHealth( TowerDamage );
      }
    }

    // Checks for enemies in range, functions the same as in Minion.cs
    GameObject enemyInRange() {
      GameObject smallest = null;
      Collider[] hitColliders = Physics.OverlapSphere( transform.position, AttackRange );
      foreach ( var hitCollider in hitColliders ) {
        if ( hitCollider.tag == "Entity" && hitCollider.gameObject != this.gameObject && getOtherFriendly( hitCollider.gameObject ) != getIsFriendly() ) {
          if( smallest == null || Vector3.Distance(hitCollider.gameObject.transform.position, transform.position) < Vector3.Distance(smallest.gameObject.transform.position, transform.position) ||
          ( smallest.gameObject.GetComponent<Player>() != null && hitCollider.gameObject.GetComponent<Minion>() != null ) ) {
            smallest = hitCollider.gameObject;
          }
        }
      }
      return smallest;
    }

    // Checks the friendly value of entity
    public bool getOtherFriendly( GameObject entity ) {
      if ( entity.GetComponent<Player>() != null ) {
        Player player = entity.gameObject.GetComponent<Player>();
        return player.getIsFriendly();
      }
      else if ( entity.GetComponent<Minion>() != null ) {
        Minion minion = entity.gameObject.GetComponent<Minion>();
        return minion.getIsFriendly();
      }
      return false;
    }

    // returns friendly value
    public bool getIsFriendly() {
      return isFriendly;
    }
}
