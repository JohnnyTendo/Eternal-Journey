using Systems.Collections;
using UnityEngine;

public class SnapToGrid : MonoBehaviour 
{
  void OnSceneGUI() {
        Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
        this.x = Mathf.RoundToInt(ray.origin.x);
        this.y = Mathf.RoundToInt(ray.origin.y);
  }
}
