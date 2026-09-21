using UnityEngine;
using Unity.Netcode;

public class NetworkUI : MonoBehaviour
{
    private void OnGUI()
    {
        // Verifica se existe um NetworkManager na cena
        if (NetworkManager.Singleton == null)
        {
            GUI.Box(
                new Rect(20, 20, 300, 100),
                "ERRO: NetworkManager não encontrado"
            );

            GUI.Label(
                new Rect(35, 55, 270, 50),
                "Adicione um NetworkManager à cena."
            );

            return;
        }

        GUI.Box(
            new Rect(20, 20, 200, 180),
            "PONG MULTIPLAYER"
        );

        // Se ainda não estiver conectado
        if (!NetworkManager.Singleton.IsClient &&
            !NetworkManager.Singleton.IsServer)
        {
            if (GUI.Button(
                new Rect(40, 60, 160, 40),
                "START HOST"))
            {
                NetworkManager.Singleton.StartHost();
            }

            if (GUI.Button(
                new Rect(40, 110, 160, 40),
                "START CLIENT"))
            {
                NetworkManager.Singleton.StartClient();
            }

            if (GUI.Button(
                new Rect(40, 160, 160, 40),
                "START SERVER"))
            {
                NetworkManager.Singleton.StartServer();
            }
        }
        else
        {
            GUI.Label(
                new Rect(40, 60, 160, 30),
                "CONECTADO!"
            );

            GUI.Label(
                new Rect(40, 90, 160, 30),
                "Players: " +
                NetworkManager.Singleton.ConnectedClients.Count
            );

            if (GUI.Button(
                new Rect(40, 130, 160, 40),
                "DESCONECTAR"))
            {
                NetworkManager.Singleton.Shutdown();
            }
        }
    }
}