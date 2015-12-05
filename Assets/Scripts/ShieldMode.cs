using UnityEngine;
using System.Collections;

public class ShieldMode : MonoBehaviour {
  public GameObject bubble;
	
   public void ActivateShield() {

            GameObject bubble_shield = Instantiate(bubble);
            bubble_shield.transform.SetParent(transform);
            bubble_shield.transform.localScale = new Vector3( 1.0f, 1.0f, 1.0f );
            bubble_shield.transform.localPosition = Vector3.zero;
            Invoke("DeactivateShield", 5);
        }

        public void DeactivateShield() {
             GameObject bubble_shield = transform.Find("bubble(Clone)").gameObject;
             Destroy(bubble_shield);
        }
}
