using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class LetterSlot : MonoBehaviour, IDropHandler
{
    [HideInInspector]
    public string correctLetter;

    public TextMeshProUGUI letterText;

    private bool preenchido = false;
    private VogaisGameManager gameManager;

    public void Inicializar(string letra, VogaisGameManager manager)
    {
        correctLetter = letra;
        gameManager = manager;

        letterText.text = "";
        preenchido = false;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (preenchido)
            return;

        DragItem item = eventData.pointerDrag.GetComponent<DragItem>();

        if (item == null)
            return;

        if (item.name.ToUpper() == correctLetter)
        {
            preenchido = true;

            letterText.text = correctLetter;

            item.gameObject.SetActive(false);

            gameManager.LetraCorreta();
        }
    }
}