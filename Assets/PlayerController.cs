using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GvrHead ProvideAccessToGvrHead()
    {
        return this.GetComponentInChildren<CameraManagement>().ProvideAccessToGvrHead();
    }

    public void SetRotationAndAngles(Quaternion rotation)
    {
        this.transform.rotation = rotation;
        var movement = FindObjectOfType<MovementScript>();
        movement.xAngle = rotation.eulerAngles.y;
        movement.yAngle = rotation.eulerAngles.x;
        movement.xAngTemp = rotation.eulerAngles.y;
        movement.yAngTemp = rotation.eulerAngles.x;
        movement.ApplyRotation();
    }

    public void SetRotation(Quaternion rotation)
    {
        this.transform.rotation = rotation;
    }
}
