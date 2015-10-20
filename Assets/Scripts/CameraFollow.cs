using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

  public Transform player;

	void LateUpdate () {
    //transform.position = player.transform.position + offset;
    transform.position = new Vector3(player.position.x + 7 , 0 , -10);
	}
}
