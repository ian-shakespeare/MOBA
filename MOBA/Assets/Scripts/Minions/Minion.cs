using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour {
  public float MoveSpeed;
  public bool isFriendly;
  public float AttackRange;

  void Update() {
    GameObject Enemy = enemyInRange();
    if ( Enemy != null ) {
      attack( Enemy );
    }
    else {
      move();
    }
  }
  void attack( GameObject enemy ) {
    //Debug.Log("Attacking");
  }
  void move() {
    //Debug.Log("Moving");
    transform.Translate ( Vector3.forward * MoveSpeed * Time.deltaTime );
  }
  GameObject enemyInRange() {
    Collider[] hitColliders = Physics.OverlapSphere( transform.position, AttackRange );
    foreach ( var hitCollider in hitColliders ) {
      if ( hitCollider.tag == "Entity" && hitCollider.gameObject != this.gameObject && getOtherFriendly( hitCollider.gameObject ) != getIsFriendly() ) {
        return hitCollider.gameObject;
      }
    }
    return null;
  }
  public void setIsFriendly( bool friendly ) {
    isFriendly = friendly;
  }
  public bool getIsFriendly() {
    return isFriendly;
  }
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
