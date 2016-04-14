using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Transform parentToReturnTo = null;

    public enum Zone { CREATURE, DECKMASTER, EVENT, HAND };
    public Zone typeOfCard = Zone.CREATURE;

	public void OnBeginDrag(PointerEventData pointerData)
    {
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData pointerData)
    {
        this.transform.position = pointerData.position;
    }

    public void OnEndDrag(PointerEventData pointerData)
    {
        this.transform.SetParent(parentToReturnTo);

        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }
}
