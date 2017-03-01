using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasObjectsManagementScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleMovemmentDpadVisibility()
    {
        var x = this.GetComponentInChildren<MovementDpadManagement>(true);
        x.ToggleVisibility();
    }

    public void ToggleRecenterButtonVisibility()
    {
        var x = this.GetComponentInChildren<RecenterButtonManagement>(true);
        x.ToggleVisibility();
    }

    public void SetRecenterButtonVisibility(bool value)
    {
        var x = this.GetComponentInChildren<RecenterButtonManagement>(true);
        x.SetVisibility(value);
    }
}
