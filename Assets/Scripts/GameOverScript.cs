using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
  public Texture play_again_button_image;
  public Texture next_level_button_image;

  public GUISkin customSkin;

  void Update () {

    for (var i = 0; i < Input.touchCount; ++i) {
        if (Input.GetTouch(i).phase == TouchPhase.Began) {
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
            // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
            if(hitInfo)
            {
                Debug.Log( hitInfo.transform.gameObject.name );
                OptionSelected(hitInfo.transform.gameObject);
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
            OptionSelected(hitInfo.transform.gameObject);

            // Here you can check hitInfo to see which collider has been hit, and act appropriately.
        }
    }
 
  }

  void OptionSelected(GameObject item) {

    int score = PlayerPrefs.GetInt("Score");
    int mission_level = PlayerPrefs.GetInt("mission_level");
    if(item.name == "play_again_button") {

       int level_play_count = 0;
      if (PlayerPrefs.HasKey("level_play_count")) {
         level_play_count = PlayerPrefs.GetInt("level_play_count");
      }
      else {
        level_play_count = 0;
      }
      if(level_play_count >= 6)
      {
        PlayerPrefs.DeleteKey("level_play_count");
      Debug.Log("level count is "+ level_play_count);

        if(mission_level == 2)
        {
          Application.LoadLevel("market");

        }
        else {
          Application.LoadLevel("puzzle");
        }
        } else
        {
          PlayerPrefs.SetInt("level_play_count", level_play_count +1);
          if(mission_level == 1) 
        {
          Application.LoadLevel("level1");
        }
        else if(mission_level == 2)
        {
          Application.LoadLevel("level2");

        }
        else {
          Application.LoadLevel("level3");
        }

        }


      } else {
         PlayerPrefs.SetInt("level_play_count", 0);

        int next_level = 1;
        if(mission_level == 1)
        {
          next_level = 2;
        }
        else if(mission_level == 2) 
        {
          next_level = 3;
        }
        else {
          next_level = 1;
        }
        PlayerPrefs.SetInt("mission_level", next_level);

        Application.LoadLevel("mission");

      }
  }
 
  }
