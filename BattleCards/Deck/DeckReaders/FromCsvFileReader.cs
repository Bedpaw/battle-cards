using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BattleCards.Interfaces;

namespace BattleCards.Deck
{
    public class FromCsvFileReader : IDeckReader
    {
        public List<Card> GetListOfCards(string source)
        {
            var dbCollection = File.ReadLines(source).ToList();
            
            return dbCollection
                .Select(line => line.Split(","))
                .Select(splitted => new Card(
                    splitted[0], splitted[1],splitted[2],
                    splitted[3], splitted[4]))
                .ToList();
        }
    }
}