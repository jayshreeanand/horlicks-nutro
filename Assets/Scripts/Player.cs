using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
  public Vector2 runVelocity = new Vector2(8, 0);
	// Use this for initialization
	void Start () {
    GetComponent<Rigidbody2D>().velocity = runVelocity;
	}
	
	// Update is called once per frame
	void Update () {
	
   
	}

}
