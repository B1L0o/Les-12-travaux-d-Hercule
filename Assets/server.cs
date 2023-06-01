using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class server : MonoBehaviourPunCallbacks
{
	private GameObject camFollow;
	private GameObject MainCamera;
	public bool host;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    public override void OnConnectedToMaster()
    {
	PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
	    if (host)
	    {
		    PhotonNetwork.CreateRoom("test");
	    }
	    else
	    {
		    PhotonNetwork.JoinRoom("test");
			var camFollow = GameObject.FindGameObjectWithTag("CamFollow");
			var pl=GameObject.FindGameObjectWithTag("p2");
        	camFollow.GetComponent<cameraFollow>().player=pl;
        	camFollow.transform.GetChild(0).gameObject.GetComponent<cameraFollow>().player = pl;
			pl.GetComponent<PhotonView>().RequestOwnership();
	    }
    }
    
}
