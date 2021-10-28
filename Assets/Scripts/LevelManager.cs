using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
   public static LevelManager instance;

   public Transform respawnPoint;
   public GameObject playerPrefab;

   private void Awake() {
       instance = this;
   }

   public void Respawn() {
       playerPrefab.GetComponent<Rigidbody2D>().position = respawnPoint.position;
        
   }
}
