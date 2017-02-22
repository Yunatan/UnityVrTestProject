using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRModeToggler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GvrViewer.Instance.VRModeEnabled = false;
        ((GvrHead)FindObjectOfType(typeof(GvrHead))).trackRotation = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GvrViewer.Instance.VRModeEnabled = !GvrViewer.Instance.VRModeEnabled;
        }
	}

    public void ToggleVR()
    {
        GvrViewer.Instance.VRModeEnabled = !GvrViewer.Instance.VRModeEnabled;
        GvrViewer.Instance.gameObject.SetActive(!GvrViewer.Instance.gameObject.activeSelf);
        ((GvrHead)FindObjectOfType(typeof(GvrHead))).trackRotation = !((GvrHead)FindObjectOfType(typeof(GvrHead))).trackRotation;
        var x = (CanvasObjectsManagementScript)Canvas.FindObjectOfType(typeof(CanvasObjectsManagementScript));
        x.ToggleMovemmentDpadVisibility();
    }
}
