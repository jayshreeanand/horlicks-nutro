﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SupermarketItems : MonoBehaviour {
  public GameObject basket;
  public int nutrition_value;
  public GameObject nutrition_text;
	
	// Update is called once per frame
	void Update () {

    for (var i = 0; i < Input.touchCount; ++i) {
        if (Input.GetTouch(i).phase == TouchPhase.Began) {
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
            // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
            if(hitInfo)
            {
                Debug.Log( hitInfo.transform.gameObject.name );
                MoveToBasket(hitInfo.transform.gameObject);
                // Here you can check hitInfo to see which collider has been hit, and act appropriately.
            }
        }
    }
 
	
     if (Input.GetMouseButtonDown (0)) {
        Debug.Log ("Clicked");
        Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
        // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
        if(hitInfo)
        {
            Debug.Log( hitInfo.transform.gameObject.name );
            MoveToBasket(hitInfo.transform.gameObject);

            // Here you can check hitInfo to see which collider has been hit, and act appropriately.
        }
    }
 
	}


  void MoveToBasket(GameObject item) {
    int nutrition_percentage = 0;
    if(PlayerPrefs.HasKey("nutrition")) {
      nutrition_percentage = PlayerPrefs.GetInt("nutrition");
    }
    int new_nutrition_percentage = nutrition_percentage + nutrition_value;
      Debug.Log("nutrition is " + new_nutrition_percentage+ "%");

    PlayerPrefs.SetInt("nutrition", new_nutrition_percentage);
     item.transform.SetParent(basket.transform);
      item.transform.localScale = new Vector3( 1.0f, 1.0f, 1.0f );
      item.transform.localPosition = new Vector3(Random.Range(-2,3), Random.Range(0,1), 0);
      nutrition_text.GetComponent<Text>().text = new_nutrition_percentage + "%";

      if (new_nutrition_percentage > 100) {
        PlayerPrefs.SetInt("nutrition", 0);

        Application.LoadLevel("mission");
      }
}
}