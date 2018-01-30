using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;

public enum ServerCommands
{
    CanHit,
    Hit
}


public class PhotonServer : MonoBehaviour, IPhotonPeerListener
{
    [SerializeField] private string _connectionString = "";

    [SerializeField] private string _appName = "";

    private PhotonPeer Peer;

    // Use this for initialization
    void Start()
    {
        Peer = new PhotonPeer(this, ConnectionProtocol.Tcp);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DebugReturn(DebugLevel level, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnOperationResponse(OperationResponse operationResponse)
    {
        throw new System.NotImplementedException();
    }

    public void OnStatusChanged(StatusCode statusCode)
    {
        throw new System.NotImplementedException();
    }

    public void OnEvent(EventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void SendOperation()
    {
        Peer.OpCustom(1, new Dictionary<byte, object> {{1, "_"}}, false);
    }
}