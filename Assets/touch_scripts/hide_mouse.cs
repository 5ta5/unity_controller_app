using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide_mouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Screen.showCursor = false;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
