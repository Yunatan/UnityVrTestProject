using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GvrHead ProvideAccessToGvrHead()
    {
        return this.GetComponentInChildren<CameraManagement>().ProvideAccessToGvrHead();
    }
}
