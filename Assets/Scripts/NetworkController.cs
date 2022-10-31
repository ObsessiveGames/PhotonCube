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
        // connect to the master server
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        if (!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
        Debug.Log("We are now connected to the " + PhotonNetwork.CloudRegion + " server!");
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
        GameObject playerObj = PhotonNetwork.Instantiate(playerPrefabPath, transform.position, Quaternion.identity);

        // initialize player
        playerObj.GetComponent<PhotonView>().RPC("Initialize", RpcTarget.All, PhotonNetwork.LocalPlayer);
    }
}
