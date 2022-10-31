using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviourPunCallbacks
{
    // local player
    public static PlayerBehaviour instance;
    public Player photonPlayer;

    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Material[] materials;
    private int currentMaterial;

    private void Awake()
    {
        currentMaterial = 1;
    }

    [PunRPC]
    public void Initialize(Player player)
    {
        photonPlayer = player;

        if (player.IsLocal)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (!base.photonView.IsMine) { return; }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentMaterial < materials.Length)
            {
                currentMaterial++;
            }
            else
            {
                currentMaterial = 1;
            }

            photonView.RPC("ColorChange", RpcTarget.AllBuffered, currentMaterial);
        }
    }

    [PunRPC]
    public void ColorChange(int currentMaterial)
    {
        meshRenderer.material = materials[currentMaterial - 1];
    }
}
