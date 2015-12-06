using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {
  public GameObject item {
    get {
      if(transform.childCount>0){
        return transform.GetChild (0).gameObject;
      }
      return null;
    }
  }

  public void OnDrop (PointerEventData eventData)
  {
    if(!item){
      DragHandler.itemBeingDragged.transform.SetParent (transform);
      DragHandler.itemBeingDragged.transform.localScale = new Vector3( 1.0f, 1.0f, 1.0f );
      DragHandler.itemBeingDragged.transform.localPosition = Vector3.zero;
      GameObject.Find("puzzle_canvas").GetComponent<Inventory>().HasChanged();
    }
  }
}
