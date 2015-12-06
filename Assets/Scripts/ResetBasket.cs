using UnityEngine;
using System.Collections;

public class ResetBasket : MonoBehaviour {

	// Use this for initialization
	void Awake () {
	 PlayerPrefs.DeleteKey("nutrition");
	}
	
}
