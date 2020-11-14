using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour {
      public bool isFriendly;
      public Minion minion;
      private Quaternion SpawnRotation;
      private int frames = 0;

      // Start initializes the rotation of the minions and spawns a single one
      void Start() {
        switch( isFriendly ) {
          case true:
            SpawnRotation = Quaternion.Euler(0, 45, 0);
            minion.setIsFriendly(true);
            break;
          case false:
            SpawnRotation = Quaternion.Euler(0, -135, 0);
            minion.setIsFriendly(false);
            break;
        }
        Instantiate( minion, new Vector3( transform.position.x, 0, transform.position.z), SpawnRotation );
      }

      // Update spawns an additional minion after 60 frames, or one second
      void Update() {
        if ( frames == 60 ) {
          switch( isFriendly ) {
            case true:
              SpawnRotation = Quaternion.Euler(0, 45, 0);
              minion.setIsFriendly(true);
              break;
            case false:
              SpawnRotation = Quaternion.Euler(0, -135, 0);
              minion.setIsFriendly(false);
              break;
          }
          Instantiate( minion, new Vector3( transform.position.x, 0, transform.position.z), SpawnRotation );
        }
        frames += 1;
      }
}
