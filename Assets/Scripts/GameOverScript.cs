using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
  int score = 0;

  void Start() {
    score = PlayerPrefs.GetInt("Score");
  }

  void OnGUI() {
    GUI.Label(new Rect(Screen.width/2 - 40, 50, 150, 30), "GAME OVER!");
    GUI.Label(new Rect(Screen.width/2 - 40, 300, 80, 30), "SCORE:" + score);
    if (GUI.Button(new Rect(Screen.width/2 - 30, 350, 60, 30), "Retry?")) {
      PlayerPrefs.SetInt("Score", 0);
      Application.LoadLevel(1);
    }
  }
}
