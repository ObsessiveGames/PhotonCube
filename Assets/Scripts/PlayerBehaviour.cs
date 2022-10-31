using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviourPunCallbacks
{
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Material[] materials;
    private int currentMaterial = 1;

    // Would use the new input system and generate the c# class to have the space only fire upon event, or even create an action.
    private void Update()
    {
        if (!photonView.IsMine) { return; }

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
