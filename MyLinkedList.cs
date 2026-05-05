using System;
using System.Collections.Generic;

namespace WindowsFormsApp3
{
    
    // tự tạo mắt xích (node)
    public class MyNode<T>
    {
        public T Value { get; set; }        // Dữ liệu chứa bên trong (ví dụ: cái thẻ Trello)
        public MyNode<T> Next { get; set; } // Sợi dây nối với mắt xích phía sau
        public MyNode<T> Prev { get; set; } // Sợi dây nối với mắt xích phía trước (Danh sách liên kết đôi)

        public MyNode(T value)
        {
            this.Value = value;
            this.Next = null;
            this.Prev = null;
        }
    }

    
    public class MyLinkedList<T>
    {
        public MyNode<T> Head { get; private set; } // Cái đầu tàu
        public MyNode<T> Tail { get; private set; } // Cái đuôi tàu

        public MyLinkedList()
        {
            Head = null;
            Tail = null;
        }

        // thêm một mắt xích vào cuối danh sách
        public void AddLast(T value)
        {
            MyNode<T> newNode = new MyNode<T>(value);
            if (Head == null)
            {
                Head = Tail = newNode; // Nếu danh sách trống, nó vừa là đầu vừa là đuôi
            }
            else
            {
                Tail.Next = newNode;   // Nối đuôi hiện tại với cái mới
                newNode.Prev = Tail;   // Móc ngược cái mới về đuôi hiện tại
                Tail = newNode;        // Gán mác "đuôi" cho cái mới
            }
        }

        // tìm kiếm một mắt xích
        public MyNode<T> Find(T value)
        {
            MyNode<T> current = Head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                {
                    return current;
                }
                current = current.Next; // Nhảy sang mắt xích tiếp theo
            }
            return null; // Tìm hết không thấy
        }

        // xóa một mắt xích
        public void Remove(T value)
        {
            MyNode<T> current = Find(value);
            if (current == null) return; // Không thấy thì thôi

            // Nếu nó có thằng đứng trước -> Nối thằng đứng trước với thằng đứng sau nó
            if (current.Prev != null)
                current.Prev.Next = current.Next;
            else
                Head = current.Next; // Nếu nó là cái đầu tàu, dời đầu tàu ra sau

            // Nếu nó có thằng đứng sau -> Nối thằng đứng sau với thằng đứng trước nó
            if (current.Next != null)
                current.Next.Prev = current.Prev;
            else
                Tail = current.Prev; // Nếu nó là đuôi tàu, dời đuôi tàu lên trước
        }
    }
}