//using ExitGames.Client.Photon;
//using Photon.Pun;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class OperationController : MonoBehaviour, IPhotonPeerListener
//{

//    private static PhotonPeer photonPeer;

//    // Start is called before the first frame update
//    void Start()
//    {
//        photonPeer = new PhotonPeer(this, ConnectionProtocol.Udp);
//        photonPeer.Connect(PhotonNetwork.ServerAddress, "LoadBalancing");
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        photonPeer.Service();
//    }


//    public void DebugReturn(DebugLevel level, string message)
//    {
//        Debug.Log("DebugReturn");
//    }

//    public void OnEvent(EventData eventData)
//    {
//        Debug.Log("OnEvent");
//        switch (eventData.Code)
//        {
//            //case 226: // (226) Evento com estatísticas sobre esta aplicação (jogadores, salas, etc)
//            //    NetworkController networkController = this.GetComponent<NetworkController>();
//            //    networkController.StatisticsAplication();
//            //    break;
//            default:
//                break;
//        }
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
//                Debug.Log("OnStatusChanged Connect");
//                photonPeer.EstablishEncryption();
//                //isConnected = true;
//                break;
//            case StatusCode.Disconnect:
//                Debug.Log("OnStatusChanged Disconnect");
//                //isConnected = false;
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
//                //isConnected = false;
//                break;
//            case StatusCode.DisconnectByServerUserLimit:
//                //isConnected = false;
//                break;
//            case StatusCode.DisconnectByServerLogic:
//                //isConnected = false;
//                break;
//            case StatusCode.DisconnectByServerReasonUnknown:
//                //isConnected = false;
//                break;
//            case StatusCode.EncryptionEstablished:
//                break;
//            case StatusCode.EncryptionFailedToEstablish:
//                break;
//            default:
//                break;
//        }
//    }

//    public void SendOperation(byte customOpCode, Dictionary<byte, object> parameters = null, bool sendReliable = true, byte channelId = 0, bool encrypt = true)
//    {

//        if (photonPeer.PeerState == PeerStateValue.Connected )
//        {
//            photonPeer.OpCustom(customOpCode, parameters, sendReliable, channelId, encrypt);
//        }
//    }

//}
