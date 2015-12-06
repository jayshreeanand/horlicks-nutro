using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MissionCreator : MonoBehaviour {

  public GameObject mission1;
  public GameObject mission2;

  

	void Awake() {
    int mission_level = PlayerPrefs.GetInt("mission_level");
    int mission_sub_level = 1;
    if (!PlayerPrefs.HasKey("mission_sub_level")) {
      PlayerPrefs.SetInt("mission_sub_level", 1);
    }
    else {
      mission_sub_level = PlayerPrefs.GetInt("mission_sub_level");
    }
    if (!(mission_level > 0)) {
      mission_level = 1;
      PlayerPrefs.SetInt("mission_level",mission_level);
    }
    Debug.Log("mission level is "+ mission_level);
    string[] mission_statements = GetMission(mission_sub_level);
    mission1.GetComponent<Text>().text = mission_statements[0];
    mission2.GetComponent<Text>().text = mission_statements[1];

  }

  public void StartMission() {
    int mission_level = PlayerPrefs.GetInt("mission_level");
		
    if(mission_level == 1) {
      Application.LoadLevel("level1");
    }
    else if(mission_level == 2) {
      Application.LoadLevel("level2");

    }
    else {
      Application.LoadLevel("level3");
    }
  }

  public string[] GetMission(int id) {
    string[] mission_detail = new string[3];
    PlayerPrefs.DeleteKey("target_carrot");
    PlayerPrefs.DeleteKey("target_horlicks_mug");
    PlayerPrefs.DeleteKey("target_horlicks_bottle");
    PlayerPrefs.DeleteKey("target_apple");
    PlayerPrefs.DeleteKey("target_milk");

    switch(id) {
      case 1:
        mission_detail[0] = "Collect 4 Horlicks mugs";
        mission_detail[1] = "Collect 3 carrots";
        mission_detail[2] = "1.1";
        PlayerPrefs.SetInt("target_horlicks_mug", 4);
        PlayerPrefs.SetInt("target_carrot", 4);

        break;
      case 2:
        mission_detail[0] = "Collect 3 Horlicks mugs";
        mission_detail[1] = "Collect 5 apples";
        mission_detail[2] = "1.2";
        PlayerPrefs.SetInt("target_apple", 5);
        PlayerPrefs.SetInt("target_horlicks_mug", 5);
        break;

      case 3:
        mission_detail[0] = "Collect 6 Milk Bottles";
        mission_detail[1] = "Collect 2 Horlicks bottles";
        mission_detail[2] = "1.3";
        PlayerPrefs.SetInt("target_milk", 6);
        PlayerPrefs.SetInt("target_horlicks_bottle", 2);
        break;

      case 4:
        mission_detail[0] = "Collect 4 Milk Bottles";
        mission_detail[1] = "Collect 8 apples";
        mission_detail[2] = "1.4";
        PlayerPrefs.SetInt("target_milk", 4);
        PlayerPrefs.SetInt("target_apple", 8);
        break;

      case 5:
        mission_detail[0] = "Collect 5 Horlicks mugs";
        mission_detail[1] = "Collect 5 carrots";
        mission_detail[2] = "1.5";
        PlayerPrefs.SetInt("target_carrot", 5);
        PlayerPrefs.SetInt("target_horlicks_mug", 5);
        break;

      default:
        mission_detail[0] = "Collect 5 Horlicks mugs";
        mission_detail[1] = "Collect 5 carrots";
        mission_detail[2] = "1.1";
        PlayerPrefs.SetInt("target_carrot", 5);
        PlayerPrefs.SetInt("target_horlicks_mug", 5);
        break;


    }
      return mission_detail;


  }
}
