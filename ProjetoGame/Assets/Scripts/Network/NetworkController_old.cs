//using System.Collections.Generic;
//using UnityEngine;
//using Photon.Pun;
//using Photon.Realtime;
//using ExitGames.Client.Photon;
//using UnityEngine.UI;

//public class NetworkController : MonoBehaviourPunCallbacks, IPhotonPeerListener
//{

//    public Text txtNickName;
//    public Text txtPlayers;
//    public Text txtPlayersLobby;
//    public TypedLobby typedLobby = new TypedLobby();
//    public RoomOptions roomOptions = new RoomOptions();
//    public AuthenticationValues auth = new AuthenticationValues();




//    void Start()
//    {


//        /*
//        PhotonNetwork.NickName = "DDs_" + System.Guid.NewGuid();
//        auth.AuthType = CustomAuthenticationType.Custom;
        
//        string loginUser = "DDs22";
//        string passwordUser = "123";


//        auth.AddAuthParameter("user", loginUser);
//        auth.AddAuthParameter("password", passwordUser);

//        PhotonNetwork.ConnectUsingSettings();

//        txtNickName.text = auth.UserId;// PhotonNetwork.NickName;

//    */
//    }

//    public void Update()
//    {


//    }

//    public void ConnectLobby(string lobby)
//    {
//        switch (lobby)
//        {
//            case "1x1":
//                typedLobby.Name = "1x1";
//                roomOptions.MaxPlayers = 4;
//                break;
//            case "2x2":
//                typedLobby.Name = "2x2";
//                roomOptions.MaxPlayers = 8;
//                break;
//            case "3x3":
//                typedLobby.Name = "3x3";
//                roomOptions.MaxPlayers = 12;
//                break;
//        }
//        PhotonNetwork.JoinLobby(typedLobby);
//    }

//    public override void OnConnected()
//    {
//        Debug.Log("OnConnected");
//    }

//    public override void OnConnectedToMaster()
//    {

//        Debug.Log("OnConnectedToMaster");

//    }

//    public override void OnCustomAuthenticationFailed(string debugMessage)
//    {
//        Debug.Log("OnCustomAuthenticationFailed");
//    }

//    public override void OnCustomAuthenticationResponse(Dictionary<string, object> data)
//    {
//        Debug.Log("OnCustomAuthenticationResponse");
//    }

//    public override void OnDisconnected(DisconnectCause cause)
//    {
//        Debug.Log("OnDisconnected");
//    }

//    public override void OnRegionListReceived(RegionHandler regionHandler)
//    {
//        Debug.Log("OnRegionListReceived");
//    }

//    public override void OnFriendListUpdate(List<FriendInfo> friendList)
//    {
//        Debug.Log("OnFriendListUpdate");
//    }

//    public override void OnCreatedRoom()
//    {
//        Debug.Log("OnCreatedRoom");
//    }

//    public override void OnCreateRoomFailed(short returnCode, string message)
//    {
//        Debug.Log("OnCreateRoomFailed : " + message);
//    }

//    public override void OnJoinedRoom()
//    {
//        Debug.Log("OnJoinedRoom");
//        txtPlayers.text = "Players Connected : " + PhotonNetwork.CountOfPlayers;
//        txtPlayersLobby.text = "Players Connected in this room : " + PhotonNetwork.CurrentRoom.PlayerCount + " - Connected in lobby ( " + PhotonNetwork.CurrentLobby.Name + " )";

//    }

//    public override void OnJoinRoomFailed(short returnCode, string message)
//    {
//        Debug.Log("OnJoinRoomFailed : " + message);
//    }

//    public override void OnJoinRandomFailed(short returnCode, string message)
//    {
//        Debug.Log("OnJoinRandomFailed : " + returnCode.ToString() + " - " + message);
//        switch (returnCode)
//        {
//            case 32760:
//                PhotonNetwork.CreateRoom("", roomOptions, typedLobby);
//                break;
//            default:
//                break;
//        }
//    }

//    public override void OnLeftRoom()
//    {
//        Debug.Log("OnLeftRoom");
//    }

//    public override void OnJoinedLobby()
//    {
//        Debug.Log("Conectado ao Lobby");
//        PhotonNetwork.JoinRandomRoom();
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
//        if (statusCode == StatusCode.Connect)
//        {
//            //connected = true;
//        }
//        // log status change
//        Debug.Log("Status change: " + statusCode.ToString());
//    }

//    public void OnEvent(EventData eventData)
//    {
//        Debug.Log("OnEvent");
//    }
//}


