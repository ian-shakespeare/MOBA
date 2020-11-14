using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour {
  public float MoveSpeed;
  public bool isFriendly;
  public float AttackRange;
  public Health MinionHealth;
  public int MinionDamage;
  public double AttackSpeed;
  private float rootTime;
  private float internalMoveSpeed;
  public AudioManager audio;

  void Start() {
    internalMoveSpeed = MoveSpeed;
    audio = GameObject.Find("MinionAudio").GetComponent<AudioManager>();
  }

  void Update() {
    //Debug.Log("HELLO");
    // Checks to see if enemy is in range, then attacks or moves accordingly
    if ( MinionHealth.GetHealth() <= 0 ) {
      Destroy(GameObject.Find("MinionAudio"));
      Destroy(this.gameObject);
    }
    if ( Time.time - rootTime >= 5f ) {
      MoveSpeed = internalMoveSpeed;
    }
    GameObject Enemy = enemyInRange();
    if ( Enemy != null ) {
      // Checks to see if they may attack, determined by AttackSpeed
      if ( Time.time % AttackSpeed <= 0.005 ) {
        attack( Enemy );
      }
    }
    else {
      move();
    }
    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
  }

  // Attack and move code
  void attack( GameObject enemy ) {
    if ( enemy.GetComponent<Player>() != null ) {
      Player player = enemy.gameObject.GetComponent<Player>();
      player.playerHealth.ModifyHealth( MinionDamage );
      this.audio.Play("Hit2");
      player.audio.Play("TakeDamage");
    }
    else if ( enemy.GetComponent<Minion>() != null ) {
      Minion minion = enemy.gameObject.GetComponent<Minion>();
      minion.MinionHealth.ModifyHealth( MinionDamage );
      this.audio.Play("Hit1");
    }
    else if ( enemy.GetComponent<Tower>() != null ) {
      Tower tower = enemy.gameObject.GetComponent<Tower>();
      tower.TowerHealth.ModifyHealth( MinionDamage );
      this.audio.Play("Hit1");
    }
    else {
      enemy.gameObject.GetComponent<Core>().CoreHealth.ModifyHealth( MinionDamage );
      this.audio.Play("Hit1");
    }
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
    if ( entity.GetComponent<Player>() != null ) {
      Player player = entity.gameObject.GetComponent<Player>();
      return player.getIsFriendly();
    }
    else if ( entity.GetComponent<Minion>() != null ) {
      Minion minion = entity.gameObject.GetComponent<Minion>();
      return minion.getIsFriendly();
    }
    else if ( entity.GetComponent<Tower>() != null ) {
      return entity.gameObject.GetComponent<Tower>().getIsFriendly();
    }
    else {
      return entity.gameObject.GetComponent<Core>().getIsFriendly();
    }
  }
  void OnTriggerEnter( Collider other ) {
    if ( other.gameObject.GetComponent<Projectile>() != null && other.gameObject.GetComponent<Projectile>().getIsFriendly() != this.getIsFriendly() ) {
      this.MinionHealth.ModifyHealth( other.gameObject.GetComponent<Projectile>().getProjectileDamage() );
      Destroy( other.gameObject );
    }
    if ( other.gameObject.GetComponent<Trap>() != null && other.gameObject.GetComponent<Trap>().getIsFriendly() != this.getIsFriendly() ) {
      this.MinionHealth.ModifyHealth( other.gameObject.GetComponent<Trap>().getTrapDamage() );
      this.MoveSpeed = 0;
      rootTime = Time.time;
      Destroy( other.gameObject );
    }
  }
}
