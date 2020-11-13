using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public float MoveSpeed;
  public GameObject PlayerObject;
  public GameObject camera;

  // Update is called once per frame
  void Update() {
    // Player facing direction
    Plane player_plane = new Plane( Vector3.up, transform.position );
    Ray ray = UnityEngine.Camera.main.ScreenPointToRay( Input.mousePosition );
    float hit_distance = 0.0f;

    if ( player_plane.Raycast(ray, out hit_distance) ) {
      Vector3 target_point = ray.GetPoint( hit_distance );
      Quaternion target_rotation = Quaternion.LookRotation( target_point - transform.position );
      target_rotation.x = 0;
      target_rotation.z = 0;
      PlayerObject.transform.rotation = Quaternion.Slerp( PlayerObject.transform.rotation, target_rotation, 5f * Time.deltaTime );
    }
    // Player movement
    if ( Input.GetKey( KeyCode.W ) ) {
      transform.Translate ( Vector3.forward * MoveSpeed * Time.deltaTime );
    }
    if ( Input.GetKey( KeyCode.A ) ) {
      transform.Translate( Vector3.left * MoveSpeed * Time.deltaTime );
    }
    if ( Input.GetKey( KeyCode.S ) ) {
      transform.Translate( Vector3.back * MoveSpeed * Time.deltaTime );
    }
    if ( Input.GetKey( KeyCode.D ) ) {
      transform.Translate( Vector3.right * MoveSpeed * Time.deltaTime );
    }
  }
}
