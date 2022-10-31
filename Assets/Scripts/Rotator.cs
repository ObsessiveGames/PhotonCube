using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviourPun
{
    private Vector3 RotateAmount = new Vector3(0, 15, 0);
    private bool isRotating = true;

    private void Update()
    {
        if (!base.photonView.IsMine) { return; }

        if (Input.GetKeyDown(KeyCode.R))
            isRotating = !isRotating;

        if (isRotating)
            transform.Rotate(RotateAmount * Time.deltaTime);
    }
}
