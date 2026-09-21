using UnityEngine;
using Unity.Netcode;

public class BallController : NetworkBehaviour
{
    public float velocidade = 6f;

    private Rigidbody2D rb;

    public override void OnNetworkSpawn()
    {
        rb = GetComponent<Rigidbody2D>();

        if (IsServer)
        {
            IniciarBola();
        }
    }

    void IniciarBola()
    {
        float direcaoX = Random.value < 0.5f ? -1f : 1f;
        float direcaoY = Random.Range(-0.7f, 0.7f);

        Vector2 direcao = new Vector2(
            direcaoX,
            direcaoY
        ).normalized;

        rb.linearVelocity = direcao * velocidade;
    }
}