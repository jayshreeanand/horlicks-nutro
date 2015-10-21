using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

  public GameObject explosion;    // Prefab of explosion effect.


	// Use this for initialization
	void Start () {
	   // Destroy the rocket after 2 seconds if it doesn't get destroyed before then.
    Destroy(this.gameObject, 2);
	}

  void OnExplode()
  {
    // Create a quaternion with a random rotation in the z-axis.
    Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

    // Instantiate the explosion where the rocket is with the random rotation.
    Instantiate(explosion, transform.position, randomRotation);
  }

  void OnTriggerEnter2D (Collider2D col)
  {
    // If it hits an enemy...
    if(col.tag == "Enemy")
    {
      // ... find the Enemy script and call the Hurt function.
      col.gameObject.GetComponent<Enemy>().Hurt();

      // Call the explosion instantiation.
      OnExplode();

      // Destroy the rocket.
      Destroy (gameObject);
    }
  }
}
