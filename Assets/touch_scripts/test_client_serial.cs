using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using System.IO;

public class test_client_serial : MonoBehaviour {
    
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
    
    void Start() {
        socket_connect();
    }
    
    
    void Update(){
        //Debug.Log(buffor);
        send_text("dane");
    }
    
    
}
