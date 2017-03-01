using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDpadManagement : MonoBehaviour {

    public void ToggleVisibility()
    {
        var x = this.gameObject;
        x.SetActive(!x.activeSelf);        
    }

    public Rect GetDimensions()
    {
        var rectTransform = this.GetComponent<RectTransform>();
        return rectTransform.rect;
    }
}
