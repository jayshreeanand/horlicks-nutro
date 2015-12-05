using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MissionCreator : MonoBehaviour {

  public GameObject mission1;
  public GameObject mission2;

  

	void Awake() {
    int mission_level = PlayerPrefs.GetInt("mission_level");
    if (!(mission_level > 0)) {
      mission_level = 1;
      PlayerPrefs.SetInt("mission_level",mission_level);
    }
    Debug.Log("mission level is "+ mission_level);
    string[] mission_statements = GetMission(mission_level);
    mission1.GetComponent<Text>().text = mission_statements[0];
    mission2.GetComponent<Text>().text = mission_statements[1];

  }

  public void StartMission() {
    Application.LoadLevel(6);
  }

  public string[] GetMission(int id) {
    string[] mission_detail = new string[3];
    switch(id) {
      case 1:
        mission_detail[0] = "Collect 5 Horlicks mugs";
        mission_detail[1] = "Collect 5 carrots";
        mission_detail[2] = "1.1";
        PlayerPrefs.SetInt("target_carrot", 5);
        PlayerPrefs.SetInt("target_horlicks", 5);
        break;
      case 2:
        mission_detail[0] = "Collect 5 Horlicks mugs";
        mission_detail[1] = "Collect 5 carrots";
        mission_detail[2] = "1.2";
        PlayerPrefs.SetInt("target_carrot", 5);
        PlayerPrefs.SetInt("target_horlicks", 5);
        break;

      case 3:
        mission_detail[0] = "Collect 5 Horlicks mugs";
        mission_detail[1] = "Collect 5 carrots";
        mission_detail[2] = "1.3";
        PlayerPrefs.SetInt("target_carrot", 5);
        PlayerPrefs.SetInt("target_horlicks", 5);
        break;

      case 4:
        mission_detail[0] = "Collect 5 Horlicks mugs";
        mission_detail[1] = "Collect 5 carrots";
        mission_detail[2] = "1.4";
        PlayerPrefs.SetInt("target_carrot", 5);
        PlayerPrefs.SetInt("target_horlicks", 5);
        break;

      case 5:
        mission_detail[0] = "Collect 5 Horlicks mugs";
        mission_detail[1] = "Collect 5 carrots";
        mission_detail[2] = "1.5";
        PlayerPrefs.SetInt("target_carrot", 5);
        PlayerPrefs.SetInt("target_horlicks", 5);
        break;

      default:
        mission_detail[0] = "Collect 5 Horlicks mugs";
        mission_detail[1] = "Collect 5 carrots";
        mission_detail[2] = "1.1";
        PlayerPrefs.SetInt("target_carrot", 5);
        PlayerPrefs.SetInt("target_horlicks", 5);
        break;


    }
      return mission_detail;


  }
}
