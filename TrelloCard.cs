using System;

namespace WindowsFormsApp3
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

        // ĐÃ XÓA SỢI DÂY "Next" CŨ. TrelloCard giờ chỉ là 1 kho lưu dữ liệu thuần túy.

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
        }
    }
}