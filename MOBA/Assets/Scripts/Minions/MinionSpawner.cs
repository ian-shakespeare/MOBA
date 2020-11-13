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
            Instantiate( minion, new Vector3( -9, 0, -9), SpawnRotation );
            break;
          case false:
            SpawnRotation = Quaternion.Euler(0, -135, 0);
            minion.setIsFriendly(false);
            Instantiate( minion, new Vector3( 9, 0, 9), SpawnRotation );
            break;
        }
      }

      // Update is called once per frame
      void Update() {
        if ( frames == 60 ) {
          switch( isFriendly ) {
            case true:
              SpawnRotation = Quaternion.Euler(0, 45, 0);
              minion.setIsFriendly(true);
              Instantiate( minion, new Vector3( -9, 0, -9), SpawnRotation );
              break;
            case false:
              SpawnRotation = Quaternion.Euler(0, -135, 0);
              minion.setIsFriendly(false);
              Instantiate( minion, new Vector3( 9, 0, 9), SpawnRotation );
              break;
          }
        }
        frames += 1;
      }
}
