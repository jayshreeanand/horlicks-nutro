using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour, IHasChanged{
  [SerializeField] Transform slots;

  // Use this for initialization
  void Start () {
    HasChanged ();
  }
  
  public void HasChanged ()
  {
    System.Text.StringBuilder builder = new System.Text.StringBuilder();
    foreach (Transform slotTransform in slots){
      GameObject item = slotTransform.GetComponent<Slot>().item;
      if (item){
        builder.Append (item.GetComponent<Text>().text);
      }
    }
    var answer = PlayerPrefs.GetString("answer");
    if (builder.ToString() == answer) {
      Application.LoadLevel("smart_kid");
    }
    Debug.Log(builder.ToString ());
  }
}


namespace UnityEngine.EventSystems {
  public interface IHasChanged : IEventSystemHandler {
    void HasChanged();
  }
}