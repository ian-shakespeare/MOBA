using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    public bool isFriendly;
    public float AttackRange;

    // Checks to see if enemy is in range, attacks accordingly
    void Update() {
      GameObject Enemy = enemyInRange();
      if ( Enemy != null ) {
        attack( Enemy );
      }
    }

    // Attack code
    void attack( GameObject enemy ) {
      // Attack code goes here
    }

    // Checks for enemies in range, functions the same as in Minion.cs
    GameObject enemyInRange() {
      Collider[] hitColliders = Physics.OverlapSphere( transform.position, AttackRange );
      foreach ( var hitCollider in hitColliders ) {
        if ( hitCollider.tag == "Entity" && hitCollider.gameObject != this.gameObject && getOtherFriendly( hitCollider.gameObject ) != getIsFriendly() ) {
          return hitCollider.gameObject;
        }
      }
      return null;
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
