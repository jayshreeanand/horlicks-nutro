using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

  public float timeWait = 3f; // Time for load the scene
  private float timeStart = 0f; 

  void Start(){
    timeStart = Time.time;
  }
 
  void Update1 (){
    if (Input.anyKeyDown || (Input.touchCount == 1) || (timeStart+timeWait)<Time.time){
      int currentLevel = Application.loadedLevel;
      if((currentLevel >= 0) && (currentLevel < 4)) {
        Application.LoadLevel(currentLevel + 1);
      }
      else if (currentLevel >= 9) {
        int nextLevel = PlayerPrefs.GetInt("nextLevel");
        Application.LoadLevel(nextLevel);
      }
      else {
      Application.LoadLevel(6);
      }
    }
  }

  public void SetLevel(int level_id) {
    PlayerPrefs.SetInt("mission_level", level_id);
    Application.LoadLevel(15);
  }


}
