using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

  public float timeWait = 3f; // Time for load the scene
  private float timeStart = 0f; 

  void Start(){
    timeStart = Time.time;
  }
 
  void Update (){
      string currentLevel = Application.loadedLevelName;

    if (Input.anyKeyDown || (Input.touchCount == 1) || (timeStart+timeWait)<Time.time){

      if (currentLevel == "nutro") {
        Application.LoadLevel("intro");
      }
      
      else if (currentLevel == "intro") {
        Application.LoadLevel("controls");
      }
      else if (currentLevel == "controls") {
        Application.LoadLevel("levels");
      }
      else if ((currentLevel == "fact1") || (currentLevel == "fact2") || (currentLevel == "fact3") || (currentLevel == "fact4")) {
        Application.LoadLevel("mission");
      }
      else if (currentLevel == "smart_kid") {
        Application.LoadLevel(RandomFact());
      }
      
    }
  }

  string RandomFact() {
    int fact_no = Random.Range(1,4);
    string fact_level_name;
    switch(fact_no) {
      case 1:
        fact_level_name = "fact1";
        break;

      case 2:
        fact_level_name = "fact2";
        break;

      case 3:
        fact_level_name = "fact3";
        break;

      case 4:
        fact_level_name = "fact4";
        break;

      default:
        fact_level_name = "fact1";
        break;

    }
    return fact_level_name;
  }
  public void SetLevel(int level_id) {
    PlayerPrefs.SetInt("mission_level", level_id);
    Application.LoadLevel("mission");
  }


}
