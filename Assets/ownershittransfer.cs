using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class ownershittransfer : MonoBehaviour , IOnPhotonViewControllerChange
{
    public void OnOwnershipRequest(PhotonView tv, Photon.Realtime.Player pl)
    {
        base.GetComponent<PhotonView>().TransferOwnership(pl);
    }

    public void takecontrol()
    {
        base.GetComponent<PhotonView>().RequestOwnership();
    }

    public void OnControllerChange(Photon.Realtime.Player newController, Photon.Realtime.Player previousController)
    {
        throw new System.NotImplementedException();
    }
}
