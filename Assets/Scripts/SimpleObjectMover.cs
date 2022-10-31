using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SimpleObjectMover : MonoBehaviourPun
{
    [SerializeField] private float moveSpeed = 1f;

    private void Update()
    {
        if (base.photonView.IsMine)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            transform.position += (new Vector3(x, y, 0f) * moveSpeed * Time.deltaTime);
        }
    }
}
