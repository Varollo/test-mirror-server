using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkPlayer : NetworkBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    [ClientCallback]
    private void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        CmdMove(move);
    }

    [Command]
    private void CmdMove(Vector3 move)
    {
        transform.Translate(move * Time.deltaTime * moveSpeed);
        RpcMove(transform.position);
    }

    [ClientRpc]
    private void RpcMove(Vector3 position)
    {
        transform.position = position;
    }
}