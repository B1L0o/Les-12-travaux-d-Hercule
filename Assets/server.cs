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
        // int isHost = PlayerPrefs.GetInt("host", 2);
        // if (isHost==0)
        // {
	        // host = false;
	        // }
        // else if(isHost==1)
        // {
	        // host = true;
	        // }
    }

    // Update is called once per frame
    public override void OnConnectedToMaster()
    {
	PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedRoom()
    {
	    Debug.Log("bbbbbb");
	    if (host==false)
	    {
		    var pl=GameObject.FindGameObjectWithTag("p2");
		    pl.GetComponent<ownershittransfer>().takecontrol();
	    }
	    
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
			//pl.GetComponent<ownershittransfer>().takecontrol();
	    }
    }
    
}

