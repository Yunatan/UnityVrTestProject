using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRModeToggler : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GvrViewer.Instance.VRModeEnabled = false;
        FindObjectOfType<GvrHead>().trackRotation = false;
        FindObjectOfType<GvrHead>().trackPosition = false;
        var playerInstance = ((PlayerController)FindObjectOfType(typeof(PlayerController)));
        var x = (CanvasObjectsManagementScript)Canvas.FindObjectOfType(typeof(CanvasObjectsManagementScript));
        x.SetRecenterButtonVisibility(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GvrViewer.Instance.VRModeEnabled = !GvrViewer.Instance.VRModeEnabled;
        }
	}

    public void ToggleVR()
    {
        GvrViewer.Instance.Recenter();
        GvrViewer.Instance.VRModeEnabled = !GvrViewer.Instance.VRModeEnabled;
        FindObjectOfType<GvrHead>().trackRotation = !FindObjectOfType<GvrHead>().trackRotation;
        var x = (CanvasObjectsManagementScript)Canvas.FindObjectOfType(typeof(CanvasObjectsManagementScript));
        x.ToggleMovemmentDpadVisibility();
        x.ToggleRecenterButtonVisibility();
        Camera.main.transform.rotation = Quaternion.Euler(new Vector3(Camera.main.transform.rotation.x, 0, Camera.main.transform.rotation.z));
    }

    public void Recenter()
    {
        GvrViewer.Instance.Recenter();
    }
}
