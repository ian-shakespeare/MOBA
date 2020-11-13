using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour {
  public float MoveSpeed;
  public bool isFriendly;

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
  void OnTriggerEnter( Collider other ) {
    if ( other.gameObject == GameObject.Find("Projectile") ) {
      Debug.Log("Projectile Collision");
    }
  }
  GameObject enemyInRange() {
    Collider[] hitColliders = Physics.OverlapSphere( transform.position, 1.7f );
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
    /*if ( entity.GetType() == typeof(Player) ) {
      Player player = entity.gameObject.GetComponent<Player>();
      return player.getIsFriendly();
    }
    else*/ if ( entity.GetComponent(typeof(Minion)) != null ) {
      Minion minion = entity.gameObject.GetComponent<Minion>();
      return minion.getIsFriendly();
    }
    return false;
  }
}
