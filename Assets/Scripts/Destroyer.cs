using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
	  if (other.tag == "Player") {
      print("player hit collider");
		 Application.LoadLevel(Application.loadedLevel);
    }
    if (other.gameObject.transform.parent) {
      Destroy (other.gameObject.transform.parent.gameObject);
    }
    else {
      Destroy (other.gameObject);
    }
	}
	
}
