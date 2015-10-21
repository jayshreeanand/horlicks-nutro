using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
  public void Update ()
  {
    int playerScore = PlayerPrefs.GetInt("Score");
    // Set the score text.
    GetComponent<GUIText>().text = "Score: " + playerScore;
  }
}
