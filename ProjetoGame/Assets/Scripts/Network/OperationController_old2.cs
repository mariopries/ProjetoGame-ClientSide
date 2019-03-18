//using ExitGames.Client.Photon;
//using Photon.Realtime;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class OperationController : MonoBehaviour, IPhotonPeerListener
//{
//    private PhotonPeer peer;
//    private bool isConnected = false;

//    // Start is called before the first frame update
//    void Start()
//    {
//        peer = new PhotonPeer(this, ConnectionProtocol.Udp);
//        peer.Connect("127.0.0.1:5055", "Loadbalancing");
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        peer.Service();
//    }


//    public void DebugReturn(DebugLevel level, string message)
//    {
//        Debug.Log("DebugReturn : " + message);
//    }

//    public void OnOperationResponse(OperationResponse operationResponse)
//    {
//        Debug.Log("OnOperationResponse");
//    }

//    public void OnStatusChanged(StatusCode statusCode)
//    {
//        switch (statusCode)
//        {
//            case StatusCode.Connect:
//                isConnected = true;
//                break;
//            case StatusCode.Disconnect:
//                isConnected = true;
//                break;
//            case StatusCode.Exception:
//                break;
//            case StatusCode.ExceptionOnConnect:
//                break;
//            case StatusCode.SecurityExceptionOnConnect:
//                break;
//            case StatusCode.SendError:
//                break;
//            case StatusCode.ExceptionOnReceive:
//                break;
//            case StatusCode.TimeoutDisconnect:
//                break;
//            case StatusCode.DisconnectByServerTimeout:
//                isConnected = false;
//                break;
//            case StatusCode.DisconnectByServerUserLimit:
//                isConnected = false;
//                break;
//            case StatusCode.DisconnectByServerLogic:
//                isConnected = false;
//                break;
//            case StatusCode.DisconnectByServerReasonUnknown:
//                isConnected = false;
//                break;
//            case StatusCode.EncryptionEstablished:
//                break;
//            case StatusCode.EncryptionFailedToEstablish:
//                break;
//            default:
//                break;
//        }
//    }

//    public void OnEvent(EventData eventData)
//    {
//        Debug.Log("OnEvent");
//    }

//    private void SendOperation(byte operationCode, Dictionary<byte, object> operationParameters, SendOptions sendOptions)
//    {
//        if (isConnected)
//        {
//            peer.SendOperation(operationCode, operationParameters, sendOptions);
//        }
//    }

//}