using UnityEngine;
using Unity.Netcode;
using System.Linq;
public class Player_strat : NetworkBehaviour
{
    [SerializeField] private GameObject[] player = null;
    
    Ui_Manager ui;
    private ulong clientId = 0;
    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            // ホスト(サーバー)側で、初期位置にtransformを書きかえる
            Debug.Log("オーナー側です");
        }

        // Prefabのオーナー判定
        if (IsClient)
        {
            if (NetworkManager.Singleton != null && NetworkManager.Singleton.IsClient)
            {
                clientId = NetworkManager.Singleton.LocalClient.ClientId;
                Debug.Log("クライアントID: " + clientId);
                ui.Set(clientId);
            }
            else
            {
                Debug.LogWarning("NetworkManagerが初期化されていないか、クライアントとして接続されていません。");
            }
            if (player.Count() >= 2)
            {
                if (clientId < 3)
                {
                    var NetObject = Instantiate(player[clientId - 1], transform.position, Quaternion.identity);
                    NetObject.GetComponent<NetworkObject>().Spawn(true);
                    Debug.Log("生成");
                }
            }
        }
    }/*
    private void Start()
    {
        GameObject U = GameObject.Find("NetWorkUi");
        ui = U.GetComponent<Ui_Manager>();
        // NetworkManagerが初期化されていることを確認
        if (NetworkManager.Singleton != null && NetworkManager.Singleton.IsClient)
        {
            clientId = NetworkManager.Singleton.LocalClient.ClientId;
            Debug.Log("クライアントID: " + clientId);
            ui.Set(clientId);
        }
        else
        {
            Debug.LogWarning("NetworkManagerが初期化されていないか、クライアントとして接続されていません。");
        }
        if (player.Count() >= 2)
        {
            if (clientId < 3)
            {

                MyObject = NetworkBehaviour.Instantiate(player[clientId - 1], transform.position, Quaternion.identity);
                Debug.Log("生成");
            }
        }
    }
  */  
}