using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public Drag.Zone typeOfCard = Drag.Zone.HAND;
    
    public void OnPointerEnter(PointerEventData pointerData)
    {

    }

    public void OnPointerExit(PointerEventData pointerData)
    {

    }


    public void OnDrop(PointerEventData pointerData)
    {
        //Debug.Log(pointerData.pointerDrag.name + "was dropped on " + gameObject.name);

        Drag d = pointerData.pointerDrag.GetComponent<Drag>();

        if (d != null)
        {
            if (typeOfCard == d.typeOfCard || typeOfCard == Drag.Zone.HAND)
            {
                d.parentToReturnTo = this.transform;
            }
        }
    }
}
