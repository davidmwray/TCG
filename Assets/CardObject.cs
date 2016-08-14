using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class CardObject : MonoBehaviour
{
	Card CardData;

	[SerializeField] Text CardName;
	[SerializeField] Text CardDesc;
    [SerializeField] Text CardPower;
    [SerializeField] Text CardType;

    public void Init(Card cardData)
	{
		CardData = cardData;

		SetupCard ();
	}

	void SetupCard()
	{
		CardName.text = CardData.Name;
		CardDesc.text = CardData.Desc;
        CardPower.text = CardData.Power.ToString();
        CardType.text = CardData.Type.ToString();
    }
}
