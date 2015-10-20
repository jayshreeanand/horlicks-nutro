using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
  public int HP = 3;          // How many times the enemy can be hit before it dies.
	public AudioClip[] deathClips;   
  public Vector2 runVelocity = new Vector2(-4, 0);
  private bool dead = false;  
  public GameObject hundredPointsUI;

  void Start()
  {
    GetComponent<Rigidbody2D>().velocity = runVelocity;

  }

  public void Hurt()
  {
    // Reduce the number of hit points by one.
    HP--;
  }

  void FixedUpdate () {

    if(HP <= 0 && !dead) {
      Destroy(this.gameObject);

    if(name == "monster(Clone)") {
      // Create a vector that is just above the enemy.
      Vector3 scorePos;
      scorePos = transform.position;
      scorePos.y += 1.5f;
       // Instantiate the 100 points prefab at this point.
      Instantiate(hundredPointsUI, scorePos, Quaternion.identity);
      var playerScore = PlayerPrefs.GetInt("Score");
      PlayerPrefs.SetInt("Score", playerScore + 100);
      GameObject score = GameObject.Find("score");
      score.GetComponent<Score>().Update();
       

    }
    
   
    }
  }
}
