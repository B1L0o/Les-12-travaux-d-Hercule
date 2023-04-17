using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class server : MonoBehaviourPunCallbacks
{
	public GameObject player;
    public bool host;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    void spawnplayer()
	{
	PhotonNetwork.Instantiate(player.name,new Vector2(-10,3),Quaternion.identity);
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
		    PhotonNetwork.Instantiate(player.name,new Vector2(-10,3),Quaternion.identity);
	    }
    }
}
