using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    private CanvasGroup canvasGroup;
    public bool foiColocada = false;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
{
    if (!foiColocada)
    {
        transform.position = startPosition;
    }

    canvasGroup.blocksRaycasts = true;
}
}