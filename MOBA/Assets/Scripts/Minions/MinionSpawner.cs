using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MinionSpawner : MonoBehaviour {
      public bool isFriendly;
      public Minion minion;
      public float SpawnRate;
      private Quaternion SpawnRotation;
      private int frames = 0;
      private float internalSpawnRate;

      // Start initializes the rotation of the minions and spawns a single one
      void Start() {
        internalSpawnRate = SpawnRate;
        SpawnWave();
      }

      // Update spawns an additional minion after SpawnRotation (25 seconds) duration, ignore internalSpawnRate, just saves value
      void Update() {
        SpawnRate -= Time.deltaTime;
        if ( SpawnRate <= 0.0f )  {
          SpawnWave();
          SpawnRate = internalSpawnRate;
        }
      }

      // Spawns a wave by calling SpawnMinion 3 times, with each minion in an offset position
      void SpawnWave() {
        SpawnMinion( new Vector3( transform.position.x, 0, transform.position.z) );
        SpawnMinion( new Vector3( transform.position.x + 1, 0, transform.position.z) );
        SpawnMinion( new Vector3( transform.position.x - 1, 0, transform.position.z) );
      }

      // Spawns a minion after setting isFriendly according to the spawner
      void SpawnMinion( Vector3 position ) {
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
          Instantiate( minion, position, SpawnRotation );
        }
      }
