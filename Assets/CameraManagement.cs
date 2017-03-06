using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagement : MonoBehaviour {
    public GvrHead ProvideAccessToGvrHead()
    {
        var x = FindObjectOfType<GvrHead>();
        return x;
    }

    public void SetRotation(Quaternion rotation)
    {
        this.transform.rotation = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, 0.0f);
    }
}
