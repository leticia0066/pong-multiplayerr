using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text textoPlayer1;
    public TMP_Text textoPlayer2;

    void Update()
    {
        if (ScoreManager.Instance == null)
            return;

        textoPlayer1.text =
            ScoreManager.Instance.pontosPlayer1.Value.ToString();

        textoPlayer2.text =
            ScoreManager.Instance.pontosPlayer2.Value.ToString();
    }
}