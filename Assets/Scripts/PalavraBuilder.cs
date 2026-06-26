using UnityEngine;
using TMPro;

public class PalavraBuilder : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject letterFixedPrefab;
    public GameObject letterSlotPrefab;

    public void Limpar()
    {
        foreach (Transform filho in transform)
        {
            Destroy(filho.gameObject);
        }
    }

    public void MontarPalavra(string palavra, VogaisGameManager gameManager)
    {
        Limpar();

        palavra = palavra.ToUpper();

        foreach (char letra in palavra)
        {
            if ("AEIOU".Contains(letra.ToString()))
            {
                GameObject slot = Instantiate(letterSlotPrefab, transform);

                LetterSlot script = slot.GetComponent<LetterSlot>();

                script.Inicializar(letra.ToString(), gameManager);
            }
            else
            {
                GameObject letraObj = Instantiate(letterFixedPrefab, transform);

                LetterFixed script = letraObj.GetComponent<LetterFixed>();

                script.DefinirLetra(letra);
            }
        }
    }
}