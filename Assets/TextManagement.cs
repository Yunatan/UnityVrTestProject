using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManagement : MonoBehaviour {
    public void AppendMesage(string message)
    {
        this.GetComponent<Text>().text = message;
    }
}
