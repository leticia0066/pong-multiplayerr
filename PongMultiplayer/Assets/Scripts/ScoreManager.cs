using UnityEngine;
using Unity.Netcode;

public class ScoreManager : NetworkBehaviour
{
    public static ScoreManager Instance;

    public NetworkVariable<int> pontosPlayer1 =
        new NetworkVariable<int>(0);

    public NetworkVariable<int> pontosPlayer2 =
        new NetworkVariable<int>(0);

    public NetworkVariable<bool> jogoTerminado =
        new NetworkVariable<bool>(false);

    public NetworkVariable<int> vencedor =
        new NetworkVariable<int>(0);

    public int pontosParaVencer = 5;

    private void Awake()
    {
        Instance = this;
    }

    public void PontoPlayer1()
    {
        if (!IsServer || jogoTerminado.Value)
            return;

        pontosPlayer1.Value++;

        VerificarVitoria();

        if (!jogoTerminado.Value)
            ReiniciarBola();
    }

    public void PontoPlayer2()
    {
        if (!IsServer || jogoTerminado.Value)
            return;

        pontosPlayer2.Value++;

        VerificarVitoria();

        if (!jogoTerminado.Value)
            ReiniciarBola();
    }

    void VerificarVitoria()
    {
        if (pontosPlayer1.Value >= pontosParaVencer)
        {
            vencedor.Value = 1;
            jogoTerminado.Value = true;
        }
        else if (pontosPlayer2.Value >= pontosParaVencer)
        {
            vencedor.Value = 2;
            jogoTerminado.Value = true;
        }
    }

    void ReiniciarBola()
    {
        GameObject bola = GameObject.FindGameObjectWithTag("Ball");

        if (bola == null)
            return;

        Rigidbody2D rb = bola.GetComponent<Rigidbody2D>();

        bola.transform.position = Vector3.zero;

        float direcaoX = Random.value < 0.5f ? -1f : 1f;
        float direcaoY = Random.Range(-0.7f, 0.7f);

        Vector2 direcao = new Vector2(
            direcaoX,
            direcaoY
        ).normalized;

        rb.linearVelocity = direcao * 6f;
    }

    public void ReiniciarPartida()
    {
        if (!IsServer)
            return;

        pontosPlayer1.Value = 0;
        pontosPlayer2.Value = 0;
        vencedor.Value = 0;
        jogoTerminado.Value = false;

        ReiniciarBola();
    }
}