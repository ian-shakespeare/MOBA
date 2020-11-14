using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    public bool isFriendly;
    public float AttackRange;

    void Update() {
      GameObject Enemy = enemyInRange();
      if ( Enemy != null ) {
        attack( Enemy );
      }
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
    void attack( GameObject enemy ) {
      Debug.Log("Attacking");
    }
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
    public bool getIsFriendly() {
      return isFriendly;
    }
}
