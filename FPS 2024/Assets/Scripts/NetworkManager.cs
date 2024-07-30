using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    #region Singleton

    public static NetworkManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //conecta o servidor Photon usando configurações definidas
    }
    //Método chamado quando conectado ao servidor mestre Photon
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected Succesful"); //Loga uma mensagem no console

        MenuManager.instance.Connected(); //Chama o método Connected do menuManager

    }

    public void JoinRoom(string roomName, string nickname)
    {
        PhotonNetwork.NickName = nickname; //Define o apelido do jogador
        PhotonNetwork.JoinRoom(roomName); // Tenta entrar na sala especificada
    }

    public void CreateRoom(string roomName, string nickname)
    {
        PhotonNetwork.NickName = nickname; //Define o apelido do jogador
        PhotonNetwork.CreateRoom(roomName); // Cria uma sala com o nome especificado
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
}
