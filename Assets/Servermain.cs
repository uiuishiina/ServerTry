using Unity.Netcode;
using UnityEngine;

public class Servermain : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        if (NetworkManager.Singleton != null && NetworkManager.Singleton.IsClient)
        {
            var clientId = NetworkManager.Singleton.LocalClient.ClientId;
            Debug.Log("クライアントID: " + clientId);
        }
        else
        {
            Debug.LogWarning("NetworkManagerが初期化されていないか、クライアントとして接続されていません。");
        }
        // ホスト(サーバー)判定
        if (IsServer)
        {
            // ホスト(サーバー)側
            
            Debug.Log("生成");
            Debug.Log("IsServer");
        }

        // Prefabのオーナー判定
        if (IsClient)
        {
            // クライアントがホスト(サーバー)に接続する度に、
            // Prefabが生成されOnNetworkSpawnが実行されるので、
            // オーナーのPrefabオブジェクトのみカメラを移動させるようにしている
            Debug.Log("IsClient");
        }
    }
}
