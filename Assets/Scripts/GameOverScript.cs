using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
  int score = 0;
  public Texture button_image;
 private GUIStyle testStyle = new GUIStyle();
  void Start() {
    PlayerPrefs.SetInt("prevLevel", Application.loadedLevel);
  }

  public void Run() {
  Application.LoadLevel(0);

  }
  void OnGUI() {
   
    if (GUI.Button(new Rect(Screen.width/2 - 150 , 350, 300, 80), button_image, testStyle)) {

      Application.LoadLevel(1);
    }
  }

  
}
