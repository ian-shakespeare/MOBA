using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour {
  public float MoveSpeed;
  public bool isFriendly;
  public float AttackRange;

  void Update() {
    // Checks to see if enemy is in range, then attacks or moves accordingly
    GameObject Enemy = enemyInRange();
    if ( Enemy != null ) {
      attack( Enemy );
    }
    else {
      move();
    }
  }

  // Attack and move code
  void attack( GameObject enemy ) {
    // Attack code goes here
  }
  void move() {
    transform.Translate ( Vector3.forward * MoveSpeed * Time.deltaTime );
  }

  // Enemy in range code, works by taking a list of collisions in a sphere (radius defined by AttackRange) and checks to see if colliders are enemies
  GameObject enemyInRange() {
    Collider[] hitColliders = Physics.OverlapSphere( transform.position, AttackRange );
    foreach ( var hitCollider in hitColliders ) {
      if ( hitCollider.tag == "Entity" && hitCollider.gameObject != this.gameObject && getOtherFriendly( hitCollider.gameObject ) != getIsFriendly() ) {
        return hitCollider.gameObject;
      }
    }
    return null;
  }

  // Changes the value of isFriendly (used by MinionSpawner.cs)
  public void setIsFriendly( bool friendly ) {
    isFriendly = friendly;
  }

  // Returns isFriendly
  public bool getIsFriendly() {
    return isFriendly;
  }

  // Checks the isFriendly value of an entity
  public bool getOtherFriendly( GameObject entity ) {
    if ( entity.GetComponent<Player>() ) {
      Player player = entity.gameObject.GetComponent<Player>();
      return player.getIsFriendly();
    }
    else if ( entity.GetComponent<Minion>() != null ) {
      Minion minion = entity.gameObject.GetComponent<Minion>();
      return minion.getIsFriendly();
    }
    else {
      return entity.gameObject.GetComponent<Tower>().getIsFriendly();
    }
  }
}
