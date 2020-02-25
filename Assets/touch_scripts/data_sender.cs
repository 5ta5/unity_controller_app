using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;

public class data_sender : MonoBehaviour
{
    //--------------------------------------------remote_module
    private Socket client;
    //private byte[] buffor;
    private bool connected=false;
    public string host="localhost";
    public int port=1234;
    
    void socket_connect(){
        Debug.Log("...");
        client= new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try {
            client.Connect(host, port);
            //client.Receive(buffor);
            connected=true;
            Debug.Log("Connected");
        } catch (SocketException) {
            Debug.Log("Connection Failure");
            return;
        }
        client.Blocking = false;
    }
    
    void send_text(string txtdata){
        if(connected==true){
            byte[] byData = System.Text.Encoding.ASCII.GetBytes(txtdata);
            client.Send(byData);
        }
    }
    //--------------------------------------------
    
    public RectTransform xy_drone;
    public RectTransform z_slider;
    private UnityEngine.UI.Slider slider;
    
    private float x=0;
    private float y=0;
    private float z=0;
    
    private float x_old=-1;
    private float y_old=-1;
    private float z_old=-1;
    
    
    public float x_range=400;
    public float y_range=400;
    public float z_range=1000;
    
    public GameObject debug_text_field;
    private UnityEngine.UI.Text tex;
    
    private int packet_number=0;
    void send_packet(string name, float value){
        send_text(name+"|"+value);
        //tex.text="["+packet_number+"]"+name+"|"+value+"\n";
        tex.text="["+packet_number+"]"+name+"|"+value+"\n"+tex.text;
        
        packet_number++;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        socket_connect();
        tex = debug_text_field.GetComponent<UnityEngine.UI.Text>();
        slider = z_slider.GetComponent<UnityEngine.UI.Slider>();
        tex.text="data_sender_oneline";
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        
        //tex.text="("+xy_drone.anchoredPosition.x+"/"+x_range+")+("+x_range+"/2)";
        x=(xy_drone.anchoredPosition.x/x_range)+0.5f;//+(x_range/2);
        y=(xy_drone.anchoredPosition.y/y_range)+0.5f;//+(y_range/2);
        z=slider.value;
        
        
        if(x!=x_old){
            x_old=x;
            send_packet("x", x);
        }
        if(y!=y_old){
            y_old=y;
            send_packet("y", y);
        }
        if(z!=z_old){
            z_old=z;
            send_packet("z", z);
        }
        
        //tex.text="x:"+x+"\ny:"+y+"\nz:"+z;
    }
}
