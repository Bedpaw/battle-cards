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
                    splitted[0], new Dictionary<int, Category>
                    {
                        {0, new Category("1", int.Parse(splitted[1]))},
                        {1, new Category("2", int.Parse(splitted[2]))},
                        {2, new Category("3", int.Parse(splitted[3]))},
                        {3, new Category("4", int.Parse(splitted[4]))},
                    })).ToList();
        }
        
    }
}