using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Health CoreHealth;
    public bool isFriendly;
    public AudioManager audio;

    void Start()
    {
      audio = GameObject.Find("CoreAudio").GetComponent<AudioManager>();
    }
    void Update() {
      if ( CoreHealth.GetHealth() <= 0 ) {
        audio.Play("Destroy");
        Destroy(this.gameObject);
        EndGame();
      }
    }
    void EndGame() {
      Debug.Log("Game Should End");// Instantiate(text) KillPlayer Application.Quit();
      Application.Quit();
    }
    void OnTriggerEnter( Collider other ) {
      if ( other.gameObject.GetComponent<Projectile>() != null && other.gameObject.GetComponent<Projectile>().getIsFriendly() != this.getIsFriendly() ) {
        this.CoreHealth.ModifyHealth( other.gameObject.GetComponent<Projectile>().getProjectileDamage() );
        Destroy( other.gameObject );
      }
    }
    public bool getIsFriendly() {
      return isFriendly;
    }
}
