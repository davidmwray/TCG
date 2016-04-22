using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class App : MonoBehaviour
{
	[SerializeField] GameObject CardPrefab;
	public Deck Deck = new Deck();

	void Awake()
	{
		Deck.Init ();
	}

	void Start()
	{
		Draw ();
	}

	void Draw()
	{
		int numCards = 2;

		Card[] drawnCards = new Card[2];
		List<int> indexes = new List<int> ();
		for (int i=0; i < Deck.Cards.Count; i++) 
		{
			indexes.Add (i);
		}

		for (int i=0; i < numCards; i++) 
		{
			int index = new System.Random().Next(indexes.Count);
			drawnCards[i] = Deck.Cards[indexes[index]];
			indexes.RemoveAt (index);
		}

		var handObj = GameObject.Find ("Hand");
		for (int i=0; i < drawnCards.Length; i++) 
		{
			var cardObj = GameObject.Instantiate(CardPrefab);
			cardObj.transform.SetParent (handObj.transform, false);
			cardObj.GetComponent<CardObject>().Init(drawnCards[i]);
		}
	}
}