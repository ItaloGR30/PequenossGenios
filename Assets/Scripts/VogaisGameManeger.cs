using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class VogaisGameManager : MonoBehaviour
{
    [Header("Database")]
    public WordDatabase database;          // opção A 

    [Header("UI")]
    public Image imagemObjeto;             // Image no Canvas
    public TextMeshProUGUI textoPalavra;   // TMP para a palavra com lacunas
    public TextMeshProUGUI textoFeedback;  // TMP para feedback

    [Header("Config")]
    public float tempoParaPróximo = 1.2f;
    public bool usarAudioAoCompletar = true;
    public AudioClip somAcerto;
    public AudioClip somErro;
    AudioSource audioSource;

    private string palavraCompleta;        // "BOLA"
    private char[] palavraComLacunas;      // "B_LA"
    private bool bloqueado = false;        // evita clique múltiplo enquanto animando

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        textoFeedback.text = "";
        CarregarNovoObjeto();
    }

    // Carrega aleatoriamente uma palavra do database (checa qual usar)
    public void CarregarNovoObjeto()
    {
        textoFeedback.text = "";
        bloqueado = false;

        WordData item = null;

        if (database != null && database.palavras != null && database.palavras.Length > 0)
        {
            item = database.palavras[Random.Range(0, database.palavras.Length)];
        }
    
        else
        {
            Debug.LogError("Nenhum database configurado em VogaisGameManager.");
            textoPalavra.text = "ERRO: Sem dados";
            return;
        }

        palavraCompleta = item.palavraCompleta.ToUpper().Trim();
        imagemObjeto.sprite = item.imagem;

        // monta lacunas: substitui apenas vogais por '_'
        palavraComLacunas = palavraCompleta.ToCharArray();
        for (int i = 0; i < palavraComLacunas.Length; i++)
        {
            if ("AEIOU".IndexOf(char.ToUpper(palavraComLacunas[i])) >= 0)
                palavraComLacunas[i] = '_';
        }

        textoPalavra.text = FormatarComEspacos(new string(palavraComLacunas));
    }

    // formato: adiciona espaço entre letras para ficar mais visível (opcional)
    string FormatarComEspacos(string s)
    {
        char[] arr = s.ToCharArray();
        return string.Join(" ", arr);
    }

    // chamado pelos botões: passe "A", "E", "I", "O", "U"
    public void EscolherVogal(string letra)
    {
        if (bloqueado) return;
        letra = letra.ToUpper();

        bool acertou = false;

        for (int i = 0; i < palavraComLacunas.Length; i++)
        {
            if (palavraComLacunas[i] == '_' && palavraCompleta[i].ToString() == letra)
            {
                palavraComLacunas[i] = letra[0];
                acertou = true;
            }
        }

        textoPalavra.text = FormatarComEspacos(new string(palavraComLacunas));

        if (acertou)
        {
            // feedback positivo
            textoFeedback.text = "✔ Correto!";
            if (usarAudioAoCompletar && somAcerto != null)
            {
                audioSource.PlayOneShot(somAcerto);
            }

            // se completou palavra, aguarda e carrega próxima
            if (!new string(palavraComLacunas).Contains("_"))
            {
                StartCoroutine(EsperarEAvancar());
            }
        }
        else
        {
            textoFeedback.text = "✖ Tente novamente!";
            if (usarAudioAoCompletar && somErro != null)
            {
                audioSource.PlayOneShot(somErro);
            }
        }
    }

    IEnumerator EsperarEAvancar()
    {
        bloqueado = true;
        yield return new WaitForSeconds(tempoParaPróximo);
        CarregarNovoObjeto();
    }

    // Método utilitário para permitir reiniciar externamente
    public void Reiniciar()
    {
        CarregarNovoObjeto();
    }
}
