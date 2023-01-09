using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

/// <summary>
/// WebSochetのクライアント
/// </summary>
public class WsClient : MonoBehaviour
{
    WebSocket _ws;
    const string Msg = "Testdayo";
    void Start()
    {

        _ws = new WebSocket("ws://localhost:3000/");
        _ws.OnOpen += (sender, args) => { Debug.Log("WebSocket opened."); };
        _ws.OnMessage += (sender, args) => {
            Debug.Log("OnMessage：" + args.Data);
        };
        _ws.OnError += (sender, args) => { Debug.Log($"WebScoket Error Message: {args.Message}"); };
        _ws.OnClose += (sender, args) => { Debug.Log("WebScoket closed"); };

        _ws.Connect();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("send!");
            _ws.Send(Msg);
        }
    }
    private void OnDestroy()
    {
        _ws.Close();
    }
}
