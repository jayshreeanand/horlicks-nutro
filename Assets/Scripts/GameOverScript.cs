﻿using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
  int score = 0;
  public Texture button_image;

  private GUIStyle testStyle = new GUIStyle();

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
      else {
        nextLevel = 6;
      }
      PlayerPrefs.SetInt("nextLevel", nextLevel);
    if (GUI.Button(new Rect(Screen.width/2 - 125 , 385, 250, 50), button_image)) {
      Application.LoadLevel(9);
    }
    if (GUI.Button(new Rect(Screen.width/2 - 125 , 455  , 250 , 50), button_image)) {
      Application.LoadLevel(nextLevel);
      Application.LoadLevel(11);

    }
  }
}
