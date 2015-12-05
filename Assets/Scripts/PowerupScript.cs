using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour {
	int playerScore;
  public GameObject hundredPointsUI;

  void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Player") {
      playerScore = PlayerPrefs.GetInt("Score");
      int points = 0;
      GameObject score;
      var powerup_name = "";
      if (name.Contains("carrot")) {
        powerup_name = "carrot";
      } 
      else if (name.Contains("milk")) {
        powerup_name = "milk";
      }
      else if (name.Contains("apple")) {
        powerup_name = "apple";
      }
      else if (name.Contains("pizza")) {
        powerup_name = "pizza";

      }
      else if (name.Contains("burger")) {
        powerup_name = "burger";

      }
      else if (name.Contains("horlicks_mug")) {
        powerup_name = "horlicks_mug";

      }
      else if (name.Contains("horlicks_bottle")) {
        powerup_name = "horlicks_bottle";

      }

      if(powerup_name == "carrot") {
        points = 10;
      }
      else if (powerup_name == "milk") {
        points = 50;
      }
      else if (powerup_name == "apple"){
        points = 10;
      }
      else if (powerup_name == "pizza"){
        points = -10;
      }
      else if (powerup_name == "burger"){
        points = -50;
      }
      else if ((powerup_name == "horlicks_bottle") || (powerup_name == "horlicks_mug")){
        points = 100;
        Vector3 scorePos;
        scorePos = other.transform.position;
        scorePos.y += 1.5f;
        if(hundredPointsUI) {
          Instantiate(hundredPointsUI, scorePos, Quaternion.identity);
        }
      }

      if(powerup_name == "horlicks_bottle") {
        GameObject.FindWithTag("Player").GetComponent<ShieldMode>().ActivateShield();

      }

      IncrementPowerup(powerup_name);
      PlayerPrefs.SetInt("Score", playerScore + points);


      if (MissionCompleted ()) {
        Debug.Log("Level complete");
        int mission_level = PlayerPrefs.GetInt("mission_level");
        int mission_sub_level = PlayerPrefs.GetInt("mission_sub_level");
        PlayerPrefs.SetInt("mission_sub_level", mission_sub_level + 1);
        Application.LoadLevel("puzzle");
      }

      Destroy (this.gameObject);
      score = GameObject.Find("score");
      score.GetComponent<Score>().Update();
    }
  }

  bool MissionCompleted() {
    return !(PlayerPrefs.HasKey("target_horlick_mug") || PlayerPrefs.HasKey("target_carrot") || PlayerPrefs.HasKey("target_apple")); 

  }

  void IncrementPowerup(string powerup_name) {
    Debug.Log(powerup_name + "got!");
    int powerup_count = PlayerPrefs.GetInt(powerup_name);
    PlayerPrefs.SetInt(powerup_name, powerup_count +1);
    if(PlayerPrefs.HasKey("target_" + powerup_name)){
      int powerup_target = PlayerPrefs.GetInt("target_"+ powerup_name);
      int new_target = powerup_target -1;
      Debug.Log(powerup_name + "target is " + new_target);

      if(new_target <= 0) {
        Debug.Log("Part of mission completed");
        PlayerPrefs.DeleteKey("target_"+ powerup_name);
      }
      PlayerPrefs.SetInt("target_"+ powerup_name, new_target);
    }
  }
}
