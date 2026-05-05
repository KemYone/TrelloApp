using System;

namespace TrelloApp
{
    public class TrelloCard
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Label { get; set; }
        public string LabelColor { get; set; }
        public string Member { get; set; }
        public int CheckedItems { get; set; }
        public int TotalItems { get; set; }
        public string Link { get; set; }
        public TrelloCard Next { get; set; }

        public TrelloCard(string title, string label, string labelColor,
                          string member, int checkedItems = 0, int totalItems = 0,
                          string link = "")
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Label = label;
            LabelColor = labelColor;
            Member = member;
            CheckedItems = checkedItems;
            TotalItems = totalItems;
            Link = link ?? "";
            Next = null;
        }
    }
}
