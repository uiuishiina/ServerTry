using UnityEngine;
using Unity.Netcode;

public class Server : NetworkBehaviour
{
    [SerializeField] private GameObject[] player = null;
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
            var NetObject = Instantiate(player[0], transform.position, Quaternion.identity);
            NetObject.GetComponent<NetworkObject>().Spawn(true);
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
    /*現在サーバー接続時に両方にplayerが作成されるためサーバーかクライアントか判断しているが起動時にplayerをサーバー側において
     * クライアントから入力だけをクライアントごとに分けて受け取る形にできればいけるかもしれない
     * 案としては
     * if(IsClient && Bule or Rad)
     * でクライアント側をBule or Radできればできる。
     * ServerScriptでサーバーかクライアントか分けたのちサーバーなら；クライアントなら生成してプレイヤーが操作できるように設定する
     * 
     */
}