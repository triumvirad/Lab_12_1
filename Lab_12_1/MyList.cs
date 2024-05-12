using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization.Json;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using static System.Net.Mime.MediaTypeNames;
namespace Lab_12_1
{
    public class MyList<T> where T: IInit, ICloneable, new()
    {
        public Point<T>? beg = null;
        public Point<T>? end = null;

        int count = 0;
        
        public int Count => count; // свойство для чтения

        public Point<T> MakeRandomData() // случайный элемент типа Т
        {
            T data = new T();
            data.RandomInit();
            return new Point<T>(data);
        }

        public T MakeRandomItem() // случайное информационное поле
        {
            T data = new T();
            data.RandomInit();
            return data;
        }

        public void AddToBegin(T item) // добавление в начало
        {
            T newData = (T)item.Clone(); //глубокое копирование
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (beg != null)
            {
                beg.Pred = newItem;
                newItem.Next = beg;
                beg = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public void AddToEnd(T item) //добавление в конец
        {
            T newData = (T)item.Clone(); //глубокое копирование
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (end != null)
            {
                end.Next = newItem;
                newItem.Pred = end;
                end = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public MyList() { } // конструктор без параметров

        public MyList(int size) // конструктор с параметром 'размер'
        {
            if (size <= 0) throw new Exception("size less zero");
            beg = MakeRandomData();
            end = beg;
            for (int i = 1; i < size; i++)
            {
                T newItem = MakeRandomItem();
                AddToEnd(newItem);
            }
        }

        public MyList(T[] collection) // способ задать несколько элементов в виде массива
        {
            if (collection == null) throw new Exception("empty collection: null");
            if (collection.Length == 0) throw new Exception("empty collection");
            T newData = (T)collection[0].Clone();
            beg = new Point<T>(newData);
            end = beg;
            for (int i = 1; i < collection.Length; i++)
            {
                AddToEnd(collection[i]);
            }
        }

        public void PrintList() // печать списка
        {
            if (count == 0) Console.WriteLine("this list is empty");
            Point<T>? current = beg;
            for (int i = 0; current != null; i++)
            {
                Console.WriteLine(current);
                current = current.Next;
            }
        }

        public Point<T>? FindItem(T item) //поиск элемента
        {
            Point<T>? current = beg;
            while (current != null)
            {
                if (current.Data == null) 
                {
                    throw new Exception("Data is null");
                }
                if (current.Data.Equals(item))
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public bool RemoveItem(T item) // удаление элемента
        {
            if (beg == null) throw new Exception("the empty list");
            Point<T>? pos = FindItem(item);
            if (pos == null) return false;
            count--;
            // один элемент
            if (beg == end)
            {
                beg = end = null;
                return true;
            }
            // первый элемент
            if (pos.Pred == null)
            {
                beg = beg?.Next;
                beg.Pred = null;
                return true;
            }
            // последний элемент
            if (pos.Next == null)
            {
                end = end.Pred;
                end.Next = null;
                return true;
            }
            // для остальных случаев
            Point<T> next = pos.Next;
            Point<T> pred = pos.Pred;
            pos.Next.Pred = pred;
            pos.Pred.Next = next;
            return true;
        }

        public void RemoveItem2(T item) // Удаление элемента с полем и всех последующих
        {
            if (beg == null) throw new Exception("the empty list");
            Point<T>? tek = beg;
            while (tek != null)
            {
                if (tek.Data != null && tek.Data.Equals(item))
                {
                    if (tek.Next != null) tek.Next.Pred = null; // Удаление текущего элемента и всех последующих
                    end = tek.Pred;
                    end.Next = null;
                    count--;
                    break;
                }
                tek = tek.Next; // Переходим к следующему элементу
            }
        }

        public MyList<T> CloneList() // глубокое копирование
        {
            MyList<T> clone = new();
            if (beg == null) return clone;
            Point<T>? current = beg;
            while (current != null)
            {
                clone.AddToEnd(current.Data);
                current = current.Next;
            }
            return clone;
        }

        public void ClearList() // удалить список из памяти
        {
            Point<T>? current = beg;
            while (current != null)
            {
                current.Pred = null;
                current = current.Next;
            }
            beg = null;
            end = null;
            count = 0;
        }

        public void AddByPlace() // добавить случайные элементы на места нечётных элементов
        {
            if (beg == null) throw new Exception("Список пуст.");
            Point<T>? current = beg;
            int index = 1;
            while (current != null)
            {
                if (index % 2 != 0)
                {
                    // Создаем новый элемент 
                    T newData = new();
                    newData.RandomInit();
                    Point<T> newPoint = new(newData);
                    // Добавляем новый элемент после текущего
                    newPoint.Next = current.Next;
                    if (current.Next != null) current.Next.Pred = newPoint;
                    current.Next = newPoint;
                    newPoint.Pred = current;
                    count++;
                }
                // Переходим к следующему элементу
                current = current.Next;
                index++;
            }
        }
    }
}