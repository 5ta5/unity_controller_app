using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class touch_x_y : MonoBehaviour
{
    //public Text tex;
    public move_the_button dron;
    UnityEngine.UI.Text tex;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        tex = GetComponent<UnityEngine.UI.Text>();
        tex.text="Xddd";
    }

    // Update is called once per frame
    
    void Update()
    {
        //Input.mousePosition.x
        tex.text="X:"+((dron.dx)/dron.border)/2+"\nY:"+((dron.dy)/dron.border)/2+"\nZ:"+slider.value;
        //tex.text="X:"+Input.Input.GetTouch(0).x+" Y:"+Input.Input.GetTouch(0).y;
        
    }
    
}
