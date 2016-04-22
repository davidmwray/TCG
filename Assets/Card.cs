using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public enum CardType
{
	Creature,
	Event,
}

public class Card
{
	public string Name;
	public string Desc;
	public int Power;
	public int Force;
	public int Cost;
	public string ImagePath;
	public CardType Type;

	public override string ToString()
	{
		string str = "";
		str += Name + ",";
		str += Desc + ",";
		str += Power + ",";

		return str;
	}
}

public class Deck
{
	public List<Card> Cards = new List<Card>();

	public void Init()
	{
		LoadCards ();

		UnityEngine.Debug.Log ("Deck data\n" + ToString ());
	}

	void LoadCards()
	{
		var textFile = Resources.Load("Cards") as TextAsset;
		string textContent = textFile.text;

		var rows = textContent.Split('\n');
		foreach (var row in rows)
		{
			var card = new Card();

			var cols = row.Split(',');
			if (cols.Length < 7)
				continue;

			card.Name = cols[0];
			card.Desc = cols[1];
			card.Power = int.Parse(cols[2]);
			card.Force = int.Parse(cols[3]);
			card.Cost = int.Parse(cols[4]);
			card.ImagePath = cols[5];
			card.Type = (CardType)Enum.Parse(typeof(CardType), cols[6]);

			Cards.Add (card);
		}
	}

	public override string ToString()
	{
		string str = "";
		foreach (var card in Cards)
		{
			str += card.ToString ();
			str += "\n";
		}

		return str;
	}
}

public class DeckLoader
{

}
