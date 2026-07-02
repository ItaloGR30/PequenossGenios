using UnityEngine;
using TMPro;

public class LetterFixed : MonoBehaviour
{
    public TextMeshProUGUI texto;

    public void DefinirLetra(char letra)
    {
        texto.text = letra.ToString();
    }
}