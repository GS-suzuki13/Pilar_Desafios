using System;
using System.Collections.Generic;

namespace BookReservation
{
    class Program
    {
        static void Main(string[] args)
        {

            Options options = new();
            ReservationList reserve = new();
            InsertBook insert = new();

            options.Starter();
            options.Selected = Console.ReadLine();
            int number = Int32.Parse(options.Selected);

            if (number == 1)
            {
                reserve.ListBook();
            }
            else if (number == 2)
            {
                insert.Insert();
            }
            else if (number == 3)
            {
                Console.WriteLine(" ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine(" ");
            };

        }
    }
    public class Book
    {
        public int Id;
        public string Name;
        public string Author;
        public string ReleaseDate;
        public DateTime ReservationDate;
        public string Genre;
        public string Diff;

        public void Greeting()
        {
            Console.WriteLine($"{Name}, {Author}, {ReleaseDate}, {ReservationDate}, {Genre}, {Diff}");
        }

        public Book(String Name,
            string Author,
            string ReleaseDate,
            DateTime ReservationDate,
            string Genre)
        {
            this.Name = Name;
            this.Author = Author;
            this.ReleaseDate = ReleaseDate;
            this.ReservationDate = ReservationDate;
            this.Genre = Genre;
        }
    }
    public class BookAdded
    {
        public string Name;
        public string Author;
        public DateTime ReleaseDate;
        public int DaysSinceLaunch;

        public BookAdded(string Name, string Author, DateTime ReleaseDate, int DaysSinceLaunch)
        {
            this.Name = Name;
            this.Author = Author;
            this.ReleaseDate = ReleaseDate;
            this.DaysSinceLaunch = DaysSinceLaunch;
        }
    }

    public class Options
    {
        public string Selected;

        public void Starter()
        {
            Console.Write("-- Reserva de Livros--\r\n" +
                "- Selecione Uma Opção -\r\n" +
                "1 -> Lista de Reservas\r\n" +
                "2 -> Inserir Livros\r\n" +
                "3 -> Sair\r\n");
        }
    }

    public class Filter
    {
        SortBookByAuthor byAuthor= new();
        ListBook book = new();
        public void FilterBooks(List<BookAdded> books)
        {
            Console.Write("** Filtrar Livros Por: **\r\n" +
                "1 -> Autor\r\n" +
                "2 -> Data\r\n" +
                "3 -> Sair\r\n");

            string selected = Console.ReadLine();
            int number = Int32.Parse(selected);
            if (number == 1)
            {
                byAuthor.FilterBookByAuthor(books);
            }
            else if (number == 2)
            {
                book.SortListOfDays(books);
            }
            else if (number == 3)
            {
                Console.ReadKey();
            }
        }
    }

    public class ListBook
    {
        SortBookByDate indexElement = new();
        List<int> ListOfDays = new();

        public void SortListOfDays(List<BookAdded> books)
        {
            foreach (BookAdded book in books)
            {
                ListOfDays.Add(book.DaysSinceLaunch);
            }

            int temp = 0;
            for (int write = 0; write < ListOfDays.Count; write++)
            {
                for (int sort = 0; sort < ListOfDays.Count - 1; sort++)
                {
                    if (ListOfDays[sort] > ListOfDays[sort + 1])
                    {
                        temp = ListOfDays[sort + 1];
                        ListOfDays[sort + 1] = ListOfDays[sort];
                        ListOfDays[sort] = temp;
                    }
                }
            }
            indexElement.FilterBookByDate(ListOfDays, books);
        }
    }

    public class SortBookByAuthor
    {
        public void FilterBookByAuthor(List<BookAdded> books)
        {
            List<string> bookAuthor = new();
            List<string> bookName = new();

            foreach (BookAdded book in books)
            {
                if (!bookAuthor.Contains(book.Author))
                {
                    bookAuthor.Add(book.Author);
                }
            }

            for (int i = 0; i < bookAuthor.Count; i++)
            {
                Console.Write($"\r\n- Autor: {bookAuthor[i]} - ");
                foreach (BookAdded book1 in books)
                {
                    if (bookAuthor[i] == book1.Author)
                    {
                        Console.Write(book1.Name + ", ");
                    }
                }
            }
            Console.WriteLine(" ");
            Console.ReadKey();
        }
    }

    public class SortBookByDate
    {
        public void FilterBookByDate(List<int> ListOfDays, List<BookAdded> books)
        {
            List<string> bookName = new();
            List<string> bookAuthor = new();
            List<DateTime> bookReleaseDate = new();

            foreach (int l in ListOfDays)
            {
                foreach (BookAdded book in books)
                {
                    int i = 0;
                    if (l == book.DaysSinceLaunch)
                    {
                        bookName.Add(book.Name);
                        bookReleaseDate.Add(book.ReleaseDate);
                        bookAuthor.Add(book.Author);
                        Console.WriteLine($"Data de Lançamento: {book.ReleaseDate.ToString("dd/MM/yyyy")} - Livro: {book.Name} - Autor: {book.Author}");
                    }
                    i++;
                }
            }
            Console.WriteLine(" ");
            Console.ReadKey();
        }
    }

    public class ReservationList
    {
        Book[] newBooks = {
                new Book("O Pequeno Príncipe", "Saint-Exupéry","06/04/1943", Convert.ToDateTime("22/01/2020"), "Children"),
                new Book("Terra do Homens", "Saint-Exupéry", "07/04/1943", Convert.ToDateTime("02/05/2022"), "Biography"),
                new Book("Voo Noturno", "Saint-Exupéry", "05/03/1931", Convert.ToDateTime("24/04/2022"), "Romance")
        };

        public void ListBook()
        {
            DateTime Today = DateTime.Now;
            Console.Write("-- Lista De Reservas--\r\n");
            foreach (Book book in newBooks)
            {
                int BookingDays = ((int)(Today - Convert.ToDateTime(book.ReservationDate)).TotalDays);
                if (BookingDays <= 30)
                {
                    Console.WriteLine($"- {book.Name} / {BookingDays} dias de reserva -");
                }
                else
                {
                    int DaysOfDelay = (BookingDays - 30);
                    decimal Fine = (((decimal)((double)DaysOfDelay / 100) * 10) + 10);
                    Console.WriteLine($"- {book.Name} / {BookingDays} dias de reserva / Dias de atraso {DaysOfDelay} / Multa R${Fine} -");
                }
            }
            Console.WriteLine(" ");
            Console.ReadLine();
        }
    }

    public class InsertBook
    {
        Filter filter = new();

        public void Insert()
        {
            bool conditionFirst = true;
            bool conditionTwo = true;
            List<BookAdded> books = new();
            DateTime Today = DateTime.Now;

            while (conditionFirst)
            {
                while (conditionTwo)
                {
                    Console.Write("Insira o NOME do Livro: ");
                    string Name = Console.ReadLine();
                    Console.Write("Insira o AUTOR a do Livro: ");
                    string Author = Console.ReadLine();
                    Console.Write("Insira a DATA DE LANÇAMENTO do livro (dd/MM/yyyy): ");
                    DateTime Date = Convert.ToDateTime(Console.ReadLine());
                    int DaysSinceLaunch = ((int)(Today - Convert.ToDateTime(Date)).TotalDays);

                    if (Date <= Today)
                    {
                        BookAdded bookadd = new(Name, Author, Date, DaysSinceLaunch);
                        books.Add(bookadd);
                    }

                    Console.Write("\r\nDeseja adicionar mais livros? (S/N): ");
                    string more = Console.ReadLine();
                    Console.ReadKey();
                    if (more == "S" || more == "s")
                    {
                        conditionTwo = true;
                    }
                    else if (more == "N" || more == "n")
                    {
                        filter.FilterBooks(books);
                        conditionTwo = false;
                        conditionFirst = false;
                    }
                    else
                    {
                        Console.Write($"Digito incorreto, por segurança será encerrado {more}");
                        conditionTwo = false;
                        conditionFirst = false;
                    }
                }
            }
        }
    }
}
