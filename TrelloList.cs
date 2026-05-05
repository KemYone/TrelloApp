using System;

namespace WindowsFormsApp3
{
    public class TrelloList
    {
        // Bây giờ Cột chỉ cần lưu mỗi Tên cột là đủ!
        public string Name { get; set; }

        public TrelloList(string name)
        {
            Name = name;
        }
    }
}