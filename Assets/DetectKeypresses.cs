using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityRawInput;


public class DetectKeypresses : MonoBehaviour
{

    private readonly Array keyCodes = Enum.GetValues(typeof(RawKey));
    private List<string> keys = new List<string>();
    public TMP_Text textbox;

    private void Start()
    {
        RawKeyInput.Start(true);
        RawKeyInput.OnKeyUp += HandleKeyUp;
        RawKeyInput.OnKeyDown += HandleKeyDown;


    }
    private void HandleKeyUp(RawKey key) {
        keys.Remove(key.ToString());
    }
    private void HandleKeyDown(RawKey key) {
        keys.Add(key.ToString());
    }

    void Update()
    {
        //keys.Clear();
        textbox.text = "";
       /* //if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in keyCodes)
            {
                //if (Input.GetKey(keyCode))
                {
                    if (RawKeyInput.IsKeyDown(RawKey.Space))
                    {
                        

                    //keys.Add(keyCode.ToString());
                    }

                }
            }
        }
       */

        for(int i = 0; i < keys.Count; i++)
        {

            if (keys[i] == "Mouse0") keys[i] = "LMB";
            if (keys[i] == "Mouse1") keys[i] = "RMB";
            if (keys[i] == "Mouse2") keys[i] = "MMB";

            textbox.text += keys[i] + " ";
            if (i != keys.Count - 1) textbox.text += "+ ";
        }
    }
}
