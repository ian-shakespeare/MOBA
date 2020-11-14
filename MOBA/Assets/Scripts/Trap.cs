using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject PlayerObject;
    public int TrapDamage;
    public int getTrapDamage() {
      return TrapDamage * PlayerObject.GetComponent<Player>().playerExp.GetLevel();
    }
    public bool getIsFriendly() {
      return PlayerObject.GetComponent<Player>().getIsFriendly();
    }
}
