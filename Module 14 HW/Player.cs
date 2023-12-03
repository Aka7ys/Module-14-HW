using System;
using System.Collections.Generic;

class Player
{
    public List<Karta> Cards { get; set; }

    public Player()
    {
        Cards = new List<Karta>();
    }

    public void DisplayCards()
    {
        foreach (var card in Cards)
        {
            Console.WriteLine($"{card.Tip} {card.Mast}");
        }
    }
}
