using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

  public GameObject player;
  private Vector3 offset;

	// Use this for initialization
	void Start () {
	  player = GameObject.FindGameObjectWithTag("Player");
    offset = transform.position;
	}
	
	void LateUpdate () {
    //transform.position = player.transform.position + offset;
    transform.position = new Vector3(transform.position.x + offset.x, transform.position.y , transform.position.z);
	 
	}
}
