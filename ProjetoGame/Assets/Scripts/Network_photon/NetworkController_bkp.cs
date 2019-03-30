//using System.Collections.Generic;
//using UnityEngine;
//using Photon.Pun;
//using Photon.Realtime;
//using ExitGames.Client.Photon;
//using UnityEngine.UI;
//using UnityEditor;

//public class NetworkController : MonoBehaviourPunCallbacks, IPhotonPeerListener, IInRoomCallbacks
//{


//    public Text txtNickName;
//    public Text txtPlayers;
//    public Text txtPlayersLobby;
//    public Text txtStatus;
//    public Button btnGameSolo;
//    public Button btnGameDuo;
//    public Button btnGameGroup;
//    public Button btnIniciar;
//    public TypedLobby typedLobby = new TypedLobby();
//    public RoomOptions roomOptions = new RoomOptions();
//    public AuthenticationValues auth = new AuthenticationValues();


//    void Start()
//    {
//        txtStatus.text = "Aguarde... Conectando aos servidores do jogo.";

//        PhotonNetwork.NickName = "DDs_" + System.Guid.NewGuid();
//        auth.AuthType = CustomAuthenticationType.Custom;
        
//        string loginUser = "DDs22";
//        string passwordUser = "123";

//        auth.UserId = loginUser+'_'+System.Guid.NewGuid().ToString();
//        auth.AddAuthParameter("user", loginUser);
//        auth.AddAuthParameter("password", passwordUser);

//        PhotonNetwork.ConnectUsingSettings();

//        txtNickName.text = auth.UserId;// PhotonNetwork.NickName;


//    }

//    public void Update()
//    {


//    }

//    public void ConnectLobby(string lobby)
//    {
//        txtStatus.text = "Aguarde... Conectando ao lobby.";

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
//        txtStatus.text = "Você está conectado escolha uma opção de partida.";
//        btnGameSolo.gameObject.SetActive(true);
//        btnGameDuo.gameObject.SetActive(true);
//        btnGameGroup.gameObject.SetActive(true);
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
//        btnGameSolo.gameObject.SetActive(false);
//        btnGameDuo.gameObject.SetActive(false);
//        btnGameGroup.gameObject.SetActive(false);

//        txtStatus.text = "Você entrou na sala.";

//        Debug.Log("OnJoinedRoom");
//        this.StatisticsAplication();        

//        Debug.Log("teste operation");


//        OperationController operationController = this.GetComponent<OperationController>();
//        Dictionary<byte, object> parameters = new Dictionary<byte, object>();
//        parameters.Add(40,"TESTE_123");
//        operationController.SendOperation(100, parameters);

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
//        txtStatus.text = "Você conectou ao lobby. encontrando uma sala para se juntar.";
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

//    public override void OnPlayerEnteredRoom(Player newPlayer)
//    {
//        StatisticsAplication();
//    }

//    public override void OnPlayerLeftRoom(Player otherPlayer)
//    {
//        StatisticsAplication();
//    }
//        public void StatisticsAplication()
//    {

//        txtPlayers.text = "Players Connected : " + PhotonNetwork.CountOfPlayers + ". Master: " + PhotonNetwork.IsMasterClient.ToString();
//        if(PhotonNetwork.InRoom)
//        {
//            txtPlayersLobby.text = "Aguarde todos os Players se conectarem para iniciar a partida. ("+ PhotonNetwork.CurrentRoom.PlayerCount +"/"+ PhotonNetwork .CurrentRoom.MaxPlayers +")";
//        }

//        // Aplicar botao iniciar partida
//        if (PhotonNetwork.IsMasterClient)
//        {
//            if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
//            {
//                btnIniciar.gameObject.SetActive(true);
//            }
//            else
//            {
//                btnIniciar.gameObject.SetActive(false);
//            }
//        }

//    }
//}


