using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NativeWebSocket;

public class Connection : MonoBehaviour
{
    WebSocket websocket;
    public GameObject sclash;


  // Start is called before the first frame update
  async void Start()
  {
    // websocket = new WebSocket("ws://echo.websocket.org");
    websocket = new WebSocket("ws://192.168.0.103:3000");

    websocket.OnOpen += () =>
    {
      Debug.Log("Connection open!");
    };

    websocket.OnError += (e) =>
    {
      Debug.Log("Error! " + e);
    };

    websocket.OnClose += (e) =>
    {
      Debug.Log("Connection closed!");
    };

    websocket.OnMessage +=(e) =>
    {
        // Reading a plain text message
        var message = System.Text.Encoding.UTF8.GetString(e);
        Debug.Log("Received OnMessage! " + message);
    };

    // Keep sending messages at every 0.3s
    InvokeRepeating("SendWebSocketMessage", 0.0f, 0.3f);

    await websocket.Connect();
  }

  void Update()
  {
    #if !UNITY_WEBGL || UNITY_EDITOR
      websocket.DispatchMessageQueue();
    #endif
  }

  async void SendWebSocketMessage()
  {
    if (websocket.State == WebSocketState.Open)
    {

        
      if(sclash.GetComponent<ReportClash>().current_note != null){

      await websocket.SendText(sclash.GetComponent<ReportClash>().current_note);

      }
            //// Sending bytes
            //await websocket.Send(new byte[] { 10, 20, 30 });

            // Sending plain text
            //await websocket.SendText("plain text message");
        }
  }

  private async void OnApplicationQuit()
  {
    await websocket.Close();
  }
}
