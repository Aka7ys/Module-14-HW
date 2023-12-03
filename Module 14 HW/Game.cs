using System;
using System.Collections.Generic;
using System.Linq;

class Game
{
    private List<Player> players;
    private List<Karta> deck;

    public Game(int numberOfPlayers)
    {
        if (numberOfPlayers < 2)
        {
            throw new ArgumentException("Number of players should be at least 2.");
        }

        players = new List<Player>();
        deck = GenerateDeck();
        ShuffleDeck();

        for (int i = 0; i < numberOfPlayers; i++)
        {
            players.Add(new Player());
        }

        DealCards();
    }

    private List<Karta> GenerateDeck()
    {
        List<Karta> newDeck = new List<Karta>();
        string[] masts = { "Черви", "Бубны", "Трефы", "Пики" };
        string[] tips = { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };

        foreach (var mast in masts)
        {
            foreach (var tip in tips)
            {
                newDeck.Add(new Karta(mast, tip));
            }
        }

        return newDeck;
    }

    private void ShuffleDeck()
    {
        Random rand = new Random();
        deck = deck.OrderBy(card => rand.Next()).ToList();
    }

    private void DealCards()
    {
        int playerIndex = 0;

        foreach (var card in deck)
        {
            players[playerIndex].Cards.Add(card);
            playerIndex = (playerIndex + 1) % players.Count;
        }
    }

    public void PlayGame()
    {
        while (players.Count > 1)
        {
            List<Karta> cardsInPlay = players.Select(player => player.Cards.First()).ToList();

            int maxIndex = cardsInPlay.IndexOf(cardsInPlay.Max());
            Player winner = players[maxIndex];

            foreach (var card in cardsInPlay)
            {
                winner.Cards.Add(card);
            }

            foreach (var player in players)
            {
                player.Cards.RemoveAt(0);
            }

            Console.WriteLine($"Игрок {maxIndex + 1} выиграл этот раунд!");
        }

        Console.WriteLine($"Игрок {players.IndexOf(players.First()) + 1} победил в игре!");
    }
}
