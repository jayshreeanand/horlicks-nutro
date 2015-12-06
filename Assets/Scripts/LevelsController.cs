using UnityEngine;
using System.Collections;

public class LevelsController : MonoBehaviour {
    // Update is called once per frame
  void Update () {

    for (var i = 0; i < Input.touchCount; ++i) {
        if (Input.GetTouch(i).phase == TouchPhase.Began) {
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
            // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
            if(hitInfo)
            {
                Debug.Log( hitInfo.transform.gameObject.name );
                StartLevel(hitInfo.transform.gameObject);
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
            StartLevel(hitInfo.transform.gameObject);

            // Here you can check hitInfo to see which collider has been hit, and act appropriately.
        }
    }
 
  }

  void StartLevel(GameObject item) {

    if(item.name == "level1") {
       PlayerPrefs.SetInt("mission_level", 1);


    }
    else if (item.name == "level2") {
       PlayerPrefs.SetInt("mission_level", 2);


    }
    else if(item.name == "level3") {
       PlayerPrefs.SetInt("mission_level", 3);


    }
    else {
       PlayerPrefs.SetInt("mission_level", 1);


    }
    Application.LoadLevel("mission");
    
  }


}
