using UnityEngine;
using Unity.Netcode;

public class Goal : MonoBehaviour
{
    public bool pontoParaPlayer1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!NetworkManager.Singleton.IsServer)
            return;

        if (!other.CompareTag("Ball"))
            return;

        if (ScoreManager.Instance == null)
            return;

        if (pontoParaPlayer1)
        {
            ScoreManager.Instance.PontoPlayer1();
        }
        else
        {
            ScoreManager.Instance.PontoPlayer2();
        }
    }
}