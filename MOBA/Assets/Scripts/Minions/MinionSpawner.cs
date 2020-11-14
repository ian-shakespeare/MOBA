using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour {
      public bool isFriendly;
      public Minion minion;
      private Quaternion SpawnRotation;
      private int frames = 0;

      // Start is called before the first frame update
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

      // Update is called once per frame
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
