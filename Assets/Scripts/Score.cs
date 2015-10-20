using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
    // The player's score.
  int playerScore;
  

  void OnDisable() {
    PlayerPrefs.SetInt("Score", playerScore);
  }


  public void Update ()
  {
    playerScore = PlayerPrefs.GetInt("Score");
    // Set the score text.
    GetComponent<GUIText>().text = "Score: " + playerScore;

  }



}
