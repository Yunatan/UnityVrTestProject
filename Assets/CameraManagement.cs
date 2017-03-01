using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagement : MonoBehaviour {
    public GvrHead ProvideAccessToGvrHead()
    {
        var x = FindObjectOfType<GvrHead>();
        return x;
    }
}
