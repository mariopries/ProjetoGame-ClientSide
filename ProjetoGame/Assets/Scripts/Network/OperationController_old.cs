//using ExitGames.Client.Photon;
//using Photon.Pun;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class OperationController : MonoBehaviourPunCallbacks, IPhotonPeerListener
//{

//    private static PhotonPeer peer = new PhotonPeer(ConnectionProtocol.Udp);
//    private static bool isConnected;


//    public void Start()
//    {
//        peer = new PhotonPeer(this, ConnectionProtocol.Udp);
//        bool isConnected = peer.Connect("127.0.0.1:5055", "Loadbalancing");
//    }

//    public void Update()
//    {
//        peer.Service();
//        if (!isConnected)
//        {

//            //connected = false;

//            //// send hello world when connected
//            //parameter.Add((byte)100, "Hello World");

//            //sendOptions.Encrypt = true;
//            //sendOptions.Channel = 0;
//            //sendOptions.Reliability = true;

//            ////peer.SendOperation(100, new Dictionary<byte, object>(), sendOptions);

//            //peer.OpCustom(100, parameter, sendOptions.Reliability);
//        }

//    }






//    public void DebugReturn(DebugLevel level, string message)
//    {
//        throw new NotImplementedException();
//    }

//    public void OnEvent(EventData eventData)
//    {
//        throw new NotImplementedException();
//    }

//    public void OnOperationResponse(OperationResponse operationResponse)
//    {
//        throw new NotImplementedException();
//    }

//    public void OnStatusChanged(StatusCode statusCode)
//    {
//        throw new NotImplementedException();
//    }
//}
