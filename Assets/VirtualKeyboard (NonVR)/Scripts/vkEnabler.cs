using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class vkEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ShowVirtualKeyboard(); You can call this method if needed in Start.
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowVirtualKeyboard()
    {
        TNVirtualKeyboard.instance.ShowVirtualKeyboard();
        TNVirtualKeyboard.instance.targetText = gameObject.GetComponent<TMP_InputField>();
    }
}