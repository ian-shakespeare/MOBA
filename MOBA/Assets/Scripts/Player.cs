using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed;
    public GameObject PlayerObject;
    public GameObject camera;
    public bool isAlive;
    public bool isFriendly;
    public Health playerHealth;
    public Exp playerExp;
    public bool HasAttackedPlayer;

    void Start() {
      // GetComponent<Rigidbody>().maxDepenetrationVelocity = 10f;
    }
    // Update is called once per frame
    void Update()
    {
        isAlive = true;
        // Player facing direction
        Plane player_plane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hit_distance = 0.0f;

        if (player_plane.Raycast(ray, out hit_distance))
        {
            Vector3 target_point = ray.GetPoint(hit_distance);
            Quaternion target_rotation = Quaternion.LookRotation(target_point - transform.position);
            target_rotation.x = 0;
            target_rotation.z = 0;
            PlayerObject.transform.rotation = Quaternion.Slerp(PlayerObject.transform.rotation, target_rotation, 5f * Time.deltaTime);
        }
        // Player movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
        }

        if (playerHealth.GetHealth() < 0)
        {
            PlayerObject.GetComponent<Renderer>().enabled = false;
            // Spectate Vector
            Vector3 specPosition = new Vector3(0, 20, -45);

            transform.position = specPosition;

        }
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    bool getHasAttackedPlayer() {
        return HasAttackedPlayer;
    }
    public bool getIsFriendly() {
      return isFriendly;
    }
}
    /*
  public IEnumerator Die()
  {
        GetComponent(MeshRenderer).enabled = false;
        // make player unable to move (boolean perhaps?)
        // move to spawn position
        // yield return new WaitForSeconds(secondsUntilRespawn);
        // set player to visible
        // make player able to move
  }
  */
