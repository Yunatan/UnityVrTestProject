using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRModeToggler : MonoBehaviour {

    Quaternion zeroQuaternion = new Quaternion {
        x = 0,
        y = 0,
        z = 0
    };

    Quaternion rememberd;

	// Use this for initialization
	void Start ()
    {
        GvrViewer.Instance.VRModeEnabled = false;
        FindObjectOfType<GvrHead>().trackRotation = false;
        FindObjectOfType<GvrHead>().target = FindObjectOfType<PlayerController>().transform;
        var x = (CanvasObjectsManagementScript)Canvas.FindObjectOfType(typeof(CanvasObjectsManagementScript));
        x.SetRecenterButtonVisibility(false);
    }
	
    public void ToggleVR()
    {
        var head = FindObjectOfType<GvrHead>();
        GvrViewer.Instance.VRModeEnabled = !GvrViewer.Instance.VRModeEnabled;

        head.trackRotation = !head.trackRotation;
        if (!GvrViewer.Instance.VRModeEnabled)
        {
            var camera = FindObjectOfType<CameraManagement>();
            var player = FindObjectOfType<PlayerController>();

            var rotation = Camera.main.transform.rotation;
            player.SetRotationAndAngles(Quaternion.identity);
            player.SetRotationAndAngles(rotation);
            camera.SetRotation(rotation);
        }
        else
        {
            var camera = FindObjectOfType<CameraManagement>();
            var player = FindObjectOfType<PlayerController>();
            var rotation = Camera.main.transform.rotation;
            player.SetRotationAndAngles(Quaternion.identity);
            camera.SetRotation(Quaternion.identity);
            Recenter();
        }

        var x = (CanvasObjectsManagementScript)Canvas.FindObjectOfType(typeof(CanvasObjectsManagementScript));
        x.ToggleMovemmentDpadVisibility();
        x.ToggleRecenterButtonVisibility();        
    }

    public void Recenter()
    {
        GvrViewer.Instance.Recenter();
    }
}
