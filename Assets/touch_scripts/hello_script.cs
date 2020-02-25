using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hello_script : MonoBehaviour
{
    
    public string host="localhost";
    public int port=1234;
    public UnityEngine.UI.Text texhost;
    public UnityEngine.UI.Text texport;
    public GameObject hello_screan;
    public data_sender ds;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("wtf?!?");
        texhost.text=host;
        texport.text=port.ToString();
        
        texhost.text = "A simple line of text.";
        
        Debug.Log("wtf["+texhost.text+"?="+host+"]");
    }

    public void button_click()
    {
        Debug.Log("hello_button_down");
        if(texhost.text!=""){
            host=texhost.text;
        }
        if(texport.text!=""){
            int.TryParse(texport.text, out port);
        }
        ds.host=host;
        ds.port=port;
        ds.gameObject.active=true;
        hello_screan.active=false;
    }
}
