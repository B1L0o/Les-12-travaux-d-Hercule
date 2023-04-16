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
        if (host)
        {
            PhotonNetwork.CreateRoom("test");
			PhotonNetwork.Instantiate(player.name,new Vector2(-10,3),Quaternion.identity);
        }
        else
        {
            PhotonNetwork.JoinRoom("test");
			PhotonNetwork.Instantiate(player.name,new Vector2(-10,3),Quaternion.identity);
        }
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
}
