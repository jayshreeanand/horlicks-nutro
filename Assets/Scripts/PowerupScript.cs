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
      var powerup_name = name.Replace("(Clone)","").Trim();

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

      PlayerPrefs.SetInt("Score", playerScore + points);

      Destroy (this.gameObject);
      score = GameObject.Find("score");
      score.GetComponent<Score>().Update();
    }
  }
}
