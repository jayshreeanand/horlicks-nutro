using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
  public Texture play_again_button_image;
  public Texture next_level_button_image;

  public GUISkin customSkin;

  void OnGUI() {

    int prevLevel = PlayerPrefs.GetInt("prevLevel");
    int score = PlayerPrefs.GetInt("Score");
    int nextLevel = 0;
      if (prevLevel == 6){
        nextLevel = 7;
      }
      else if (prevLevel == 7) {
        nextLevel = 8;
      }
      else if (prevLevel == 8) {
        nextLevel = 6;
      }

      GUI.skin = customSkin;
    if (GUI.Button(new Rect(Screen.width/2 - 80  , Screen.height/2 + 50, 160, 50), play_again_button_image)) {
      PlayerPrefs.SetInt("nextLevel", prevLevel);
      Application.LoadLevel(Random.Range(9,12));
    }
    if (GUI.Button(new Rect(Screen.width/2 - 80  , Screen.height/2 + 100, 160, 50), next_level_button_image)) {
      PlayerPrefs.SetInt("nextLevel", nextLevel);
      Application.LoadLevel(Random.Range(9,12));
    }
    GUI.skin = null;
  }
}
