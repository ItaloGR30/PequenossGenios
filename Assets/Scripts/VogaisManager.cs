using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VogaisManager : MonoBehaviour
{
    [Header("Campos da Palavra")]
    public TextMeshProUGUI[] campos; 
    public TextMeshProUGUI palavraCorretaTexto;

    [Header("Botões das Vogais")]
    public Button botaoA;
    public Button botaoE;
    public Button botaoI;
    public Button botaoO;
    public Button botaoU;

    [Header("Botões Extras")]
    public Button botaoLimpar;
    public Button botaoProxima;

    [Header("Feedback")]
    public TextMeshProUGUI feedback;

    private string palavraCorreta = "BOLA";
    private int campoIndex = 0;

    void Start()
    {
        // Liga botões das vogais
        botaoA.onClick.AddListener(() => ClicarLetra("A"));
        botaoE.onClick.AddListener(() => ClicarLetra("E"));
        botaoI.onClick.AddListener(() => ClicarLetra("I"));
        botaoO.onClick.AddListener(() => ClicarLetra("O"));
        botaoU.onClick.AddListener(() => ClicarLetra("U"));

        // Liga botões extras
        botaoLimpar.onClick.AddListener(Limpar);
        botaoProxima.onClick.AddListener(ProximaPalavra);

        AtualizarInterface();
        Limpar();
    }

    void AtualizarInterface()
    {
        if (palavraCorretaTexto != null)
            palavraCorretaTexto.text = palavraCorreta;
    }

    void ClicarLetra(string letra)
    {
        if (campoIndex >= campos.Length) return;

        campos[campoIndex].text = letra;
        campoIndex++;

        if (campoIndex == campos.Length)
            Verificar();
    }

    void Verificar()
    {
        string formado = "";

        foreach (var c in campos)
            formado += c.text;

        if (formado == palavraCorreta)
        {
            feedback.text = "Correto!";
            feedback.color = Color.green;
        }
        else
        {
            feedback.text = "Incorreto!";
            feedback.color = Color.red;
        }
    }

    void Limpar()
    {
        campoIndex = 0;
        foreach (var c in campos)
            c.text = "";

        feedback.text = "";
    }

    void ProximaPalavra()
    {
        // Mude aqui para as próximas palavras
        palavraCorreta = "CASA";

        AtualizarInterface();
        Limpar();
    }
}
