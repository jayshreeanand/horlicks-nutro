using UnityEngine;
using System.Collections;

public class SpawnObjects : MonoBehaviour {
  public GameObject[] obj;
  public float spawnMin = 1f;
  public float spawnMax = 5f;
  public bool fall = false;
	// Use this for initialization
	void Start () {
	 Spawn();
	}

	void Spawn () {
    var collectible = obj[Random.Range (0, obj.GetLength(0))];
    if(fall) {
      collectible.GetComponent<Rigidbody2D>().isKinematic = false;
    }
    else {
      collectible.GetComponent<Rigidbody2D>().isKinematic = true;
    }
    Instantiate(collectible, transform.position, Quaternion.identity);
    Invoke ("Spawn", Random.Range (spawnMin, spawnMax));
  }
}
