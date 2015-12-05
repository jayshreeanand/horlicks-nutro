using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

  public GameObject health_text;

   void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "super_market_items") {
      other.transform.SetParent(transform);
      other.transform.localScale = new Vector3( 1.0f, 1.0f, 1.0f );
      other.transform.localPosition = new Vector3(Random.Range(-2,2), Random.Range(-1,2), 0);
    }
  }
}
