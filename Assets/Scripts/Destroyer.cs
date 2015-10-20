﻿using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {
  public GameObject runPlatform;

	void OnTriggerEnter2D(Collider2D other) {
	  if (other.tag == "Player") {
      PlayerPrefs.SetInt("prevLevel", Application.loadedLevel);
      Application.LoadLevel(0);
    }
    if (other.gameObject.transform.parent) {
      
          //Destroy (other.gameObject.transform.parent.gameObject);
    }
    else {
      if((other.tag == "platform") || (other.tag ==  "powerup") || (other.tag ==  "mountain") || (other.tag ==  "Enemy")) {
      Destroy (other.gameObject);
        
      }
      if(other.tag == "run-platform") {
        Instantiate(runPlatform, new Vector3(other.gameObject.transform.position.x + 33.3f, -4.2f, 0), Quaternion.identity);
        Destroy (other.gameObject, 10);
      }
      
    }
	}
	
}