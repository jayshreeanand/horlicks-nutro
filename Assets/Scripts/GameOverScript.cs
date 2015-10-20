using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
  int score = 0;
  public Texture button_image;

  private GUIStyle testStyle = new GUIStyle();

  void OnGUI() {

    int prevLevel = PlayerPrefs.GetInt("prevLevel");
    int nextLevel = 0;
      if (prevLevel == 1){
        nextLevel = 2;
      }
      else if (prevLevel == 2) {
        nextLevel = 3;
      }
      else {
        nextLevel = 1;
      }
      print("next level is "+ nextLevel);
    if (GUI.Button(new Rect(Screen.width/2 - 85 , 270, 170, 40), button_image, testStyle)) {
      PlayerPrefs.SetInt("Score", 0);
      Application.LoadLevel(prevLevel);
    }
    if (GUI.Button(new Rect(Screen.width/2 - 85 , 350  , 170 , 40), button_image, testStyle)) {
      PlayerPrefs.SetInt("Score", 0);
      Application.LoadLevel(nextLevel);
    }
  }
}
