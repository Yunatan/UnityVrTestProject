using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecenterButtonManagement : MonoBehaviour
{
    public void ToggleVisibility()
    {
        var x = this.gameObject;
        x.SetActive(!x.activeSelf);
    }

    public void SetVisibility(bool value)
    {
        var x = this.gameObject;
        x.SetActive(value);
    }
}
