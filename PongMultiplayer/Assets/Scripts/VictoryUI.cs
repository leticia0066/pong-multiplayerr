using UnityEngine;
using TMPro;
using Unity.Netcode;

public class VictoryUI : MonoBehaviour
{
    public GameObject victoryPanel;
    public TMP_Text victoryText;

    private void Start()
    {
        victoryPanel.SetActive(false);
    }

    private void Update()
    {
        if (ScoreManager.Instance == null)
            return;

        if (!ScoreManager.Instance.jogoTerminado.Value)
        {
            victoryPanel.SetActive(false);
            return;
        }

        victoryPanel.SetActive(true);

        int vencedor = ScoreManager.Instance.vencedor.Value;

        if (vencedor == 1)
        {
            victoryText.text = "PLAYER 1 VENCEU!";
        }
        else if (vencedor == 2)
        {
            victoryText.text = "PLAYER 2 VENCEU!";
        }
    }

    public void Reiniciar()
    {
        if (NetworkManager.Singleton == null)
            return;

        if (NetworkManager.Singleton.IsServer)
        {
            ScoreManager.Instance.ReiniciarPartida();
        }
        else
        {
            PedirReinicioServerRpc();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void PedirReinicioServerRpc()
    {
        ScoreManager.Instance.ReiniciarPartida();
    }
}