using System;
using System.Collections.Generic;

namespace TrelloApp
{
    public class TrelloList
    {
        public string Name { get; set; }
        private TrelloCard header;
        public int Count { get; private set; }

        public TrelloList(string name)
        {
            Name = name;
            header = new TrelloCard("__HEADER__", "", "", "");
            Count = 0;
        }

        public void AddCard(TrelloCard card)
        {
            TrelloCard current = header;
            while (current.Next != null)
                current = current.Next;
            current.Next = card;
            Count++;
        }

        public void AddCardFirst(TrelloCard card)
        {
            card.Next = header.Next;
            header.Next = card;
            Count++;
        }

        public bool RemoveCard(string id)
        {
            TrelloCard current = header;
            while (current.Next != null)
            {
                if (current.Next.Id == id)
                {
                    current.Next = current.Next.Next;
                    Count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public TrelloCard FindCard(string id)
        {
            TrelloCard current = header.Next;
            while (current != null)
            {
                if (current.Id == id) return current;
                current = current.Next;
            }
            return null;
        }

        public List<TrelloCard> GetAllCards()
        {
            var result = new List<TrelloCard>();
            TrelloCard current = header.Next;
            while (current != null)
            {
                result.Add(current);
                current = current.Next;
            }
            return result;
        }

        public List<TrelloCard> SearchCards(string keyword)
        {
            var result = new List<TrelloCard>();
            if (string.IsNullOrWhiteSpace(keyword)) return GetAllCards();
            TrelloCard current = header.Next;
            while (current != null)
            {
                if (current.Title.ToLower().Contains(keyword.ToLower()) ||
                    current.Label.ToLower().Contains(keyword.ToLower()))
                    result.Add(current);
                current = current.Next;
            }
            return result;
        }
    }
}
