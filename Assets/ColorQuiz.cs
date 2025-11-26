using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorQuizRobusto : MonoBehaviour
{
    public Image corImage;
    public Button botao1;
    public Button botao2;
    public TMP_Text texto1;      // opcional: se deixar vazio, o script tenta achar automaticamente
    public TMP_Text texto2;
    public TMP_Text feedbackText;

    private string respostaBotao1;
    private string respostaBotao2;
    private string corCorreta;

    private (string nome, Color cor)[] cores =
    {
        ("Vermelho", Color.red),
        ("Azul", Color.blue),
        ("Verde", Color.green),
        ("Amarelo", Color.yellow),
        ("Preto", Color.black),
        ("Branco", Color.white),
        ("Laranja",new Color(1f, 0.5f, 0f)),
        ("Roxo", new Color(0.5f, 0f, 1f)),
        ("Ciano",Color.cyan),
        ("Marrom", new Color(0.6f, 0.3f, 0f)),
        ("Cinza", Color.gray)

    };

    void Awake()
    {
        // tenta encontrar textos dentro dos botões se não foram conectados no Inspector
        if (texto1 == null && botao1 != null)
            texto1 = botao1.GetComponentInChildren<TMP_Text>();
        if (texto2 == null && botao2 != null)
            texto2 = botao2.GetComponentInChildren<TMP_Text>();
        if (feedbackText == null)
            Debug.LogWarning("feedbackText não está ligado no Inspector. Mensagens de feedback não aparecerão.");

        // avisos para ajudar debug
        if (corImage == null) Debug.LogError("corImage NÃO está ligado no Inspector!");
        if (botao1 == null) Debug.LogError("botao1 NÃO está ligado no Inspector!");
        if (botao2 == null) Debug.LogError("botao2 NÃO está ligado no Inspector!");
        if (texto1 == null) Debug.LogWarning("texto1 não encontrado no botão 1 (procure TMP_Text como filho).");
        if (texto2 == null) Debug.LogWarning("texto2 não encontrado no botão 2 (procure TMP_Text como filho).");

        // garantir cor legível dos textos (preto)
        if (texto1 != null) texto1.color = new Color(1f, 0.5f, 0f);
        if (texto2 != null) texto2.color = new Color(1f, 0.5f, 0f);
        if (feedbackText != null) feedbackText.color = Color.white;
    }

    void Start()
    {
        if (feedbackText != null) feedbackText.gameObject.SetActive(false);
        GerarPergunta();
    }

    void GerarPergunta()
    {
        if (feedbackText != null) feedbackText.gameObject.SetActive(false);

        if (corImage == null || botao1 == null || botao2 == null)
        {
            Debug.LogError("Algum elemento essencial não está configurado. Verifique corImage e os botões.");
            return;
        }

        int indexCorreta = Random.Range(0, cores.Length);
        corCorreta = cores[indexCorreta].nome;
        corImage.color = cores[indexCorreta].cor;

        int indexErrada;
        do { indexErrada = Random.Range(0, cores.Length); }
        while (indexErrada == indexCorreta);

        bool colocarCorretaNoBotao1 = Random.value > 0.5f;

        // remove listeners antigos antes de atribuir
        botao1.onClick.RemoveAllListeners();
        botao2.onClick.RemoveAllListeners();

        if (colocarCorretaNoBotao1)
        {
            respostaBotao1 = corCorreta;
            respostaBotao2 = cores[indexErrada].nome;
        }
        else
        {
            respostaBotao1 = cores[indexErrada].nome;
            respostaBotao2 = corCorreta;
        }

        // escreve nos textos (garante fallback se TMP estiver faltando)
        if (texto1 != null) texto1.text = string.IsNullOrEmpty(respostaBotao1) ? "—" : respostaBotao1;
        else Debug.LogWarning("texto1 é null — verifique o filho TMP_Text do Botao1.");

        if (texto2 != null) texto2.text = string.IsNullOrEmpty(respostaBotao2) ? "—" : respostaBotao2;
        else Debug.LogWarning("texto2 é null — verifique o filho TMP_Text do Botao2.");

        // adiciona listeners que comparam as strings guardadas
        botao1.onClick.AddListener(() => Responder(respostaBotao1 == corCorreta));
        botao2.onClick.AddListener(() => Responder(respostaBotao2 == corCorreta));
    }

    void Responder(bool acertou)
    {
        if (feedbackText != null)
        {
            feedbackText.gameObject.SetActive(true);
            feedbackText.text = acertou ? "Correto!" : "Incorreto!";
        }
        else
        {
            Debug.Log(acertou ? "Correto!" : "Incorreto!");
        }

        // próxima pergunta em 1s
        Invoke(nameof(GerarPergunta), 1f);
    }
}
