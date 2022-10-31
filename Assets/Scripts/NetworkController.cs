using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks
{
    [SerializeField] private string roomName = "test";
    [SerializeField] private string playerPrefabPath = "Player";

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        if (!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Failed to connect to Photon: " + cause.ToString(), this);
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined a Lobby");
        if (!PhotonNetwork.InRoom)
        {
            PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions(), TypedLobby.Default);
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(playerPrefabPath, transform.position, Quaternion.identity);
    }
}
