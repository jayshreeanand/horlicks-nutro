using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
  public Texture play_again_button_image;
  public Texture next_level_button_image;

  public GUISkin customSkin;

  void OnGUI() {

    int score = PlayerPrefs.GetInt("Score");
    int mission_level = PlayerPrefs.GetInt("mission_level");


    GUI.skin = customSkin;
    if (GUI.Button(new Rect(Screen.width/2 - 134  , Screen.height/2 + 60, 268, 56), play_again_button_image)) {
      if (PlayerPrefs.HasKey("level_play_count")) {
        int level_play_count = PlayerPrefs.GetInt("level_play_count");
        if(level_play_count > 3){
          PlayerPrefs.SetInt("level_play_count", 0);

          Application.LoadLevel("puzzle");
          } else
          {
            PlayerPrefs.SetInt("level_play_count", level_play_count +1);

          }
        } 
        else {
          PlayerPrefs.SetInt("level_play_count", 1);

        }
        if(mission_level == 1) {
          Application.LoadLevel("level1");
        }
        else if(mission_level == 2) {
          Application.LoadLevel("level2");

        }
        else {
          Application.LoadLevel("level3");
        }

      }

      if (GUI.Button(new Rect(Screen.width/2 - 134  , Screen.height/2 + 120, 268, 56), next_level_button_image)) {
        PlayerPrefs.SetInt("level_play_count", 0);

        int next_level = 1;
        if(mission_level == 1) {
          next_level = 2;
        }
        else if(mission_level == 2) {
          next_level = 3;
        }
        else {
          next_level = 1;
        }
        PlayerPrefs.SetInt("mission_level", next_level);

        Application.LoadLevel("mission");
      }
      GUI.skin = null;
    }
  }
