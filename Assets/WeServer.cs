using UnityEngine;
using System.Collections;
using WebSocketSharp;
using WebSocketSharp.Net;
using WebSocketSharp.Server;

public class WeServer : MonoBehaviour
{
    WebSocketServer _server;
    // Start is called before the first frame update
    void Start()
    {
        // �|�[�g3000�ŃC���X�^���X����
        _server = new WebSocketServer(3000);
        // WebSocket�쐬
        _server.AddWebSocketService<Echo>("/");
        _server.Start();
    }
    private void OnDestroy()
    {
        _server.Stop();
    }
}
public class Echo : WebSocketBehavior
{
    protected override void OnMessage(MessageEventArgs e)
    {
        Sessions.Broadcast(e.Data);
    }
}
