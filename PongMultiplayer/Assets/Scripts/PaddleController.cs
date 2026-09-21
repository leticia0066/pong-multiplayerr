using UnityEngine;
using Unity.Netcode;

public class PaddleController : NetworkBehaviour
{
    public float velocidade = 7f;

    public bool jogador1 = true;

    void Update()
    {
        // Só o dono deste objeto pode controlar a raquete
        if (!IsOwner)
            return;

        float movimento = 0f;

        if (jogador1)
        {
            if (Input.GetKey(KeyCode.W))
                movimento = 1f;

            if (Input.GetKey(KeyCode.S))
                movimento = -1f;
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
                movimento = 1f;

            if (Input.GetKey(KeyCode.DownArrow))
                movimento = -1f;
        }

        transform.position +=
            Vector3.up * movimento * velocidade * Time.deltaTime;

        float y = Mathf.Clamp(
            transform.position.y,
            -3.2f,
            3.2f
        );

        transform.position = new Vector3(
            transform.position.x,
            y,
            transform.position.z
        );
    }
}