using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.classes
{
    public class Functions
    {
        public void SearchBook()
        {
            try
            {
                Console.WriteLine("Please enter the book name to search for : ");
                var bookName = Console.ReadLine();
                var foundBooks = Variables.Instance.booksList.Select(x => (x.Name, x.Author, x.PublishDate, x.Rating)).Where(x => x.Name.ToLower().Trim().Contains(bookName.ToLower().Trim()));
                if (foundBooks != null)
                {
                    foreach (var book in foundBooks)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n" + book.Name);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine($"By {book.Author} | Publish Date : {book.PublishDate} | Rating : {book.Rating}");
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine($"Some error occured : {e}");
            }


        }

        public void UpdateBook()
        {
            Console.WriteLine("Please enter the exact book name to update : ");
            var bookName = Console.ReadLine();
            var foundBooks = Variables.Instance.booksList.Where(x => x.Name == bookName).FirstOrDefault();
            if (foundBooks != null)
            {
                Console.WriteLine("Which field would you like to update : \nEnter A for Author, N for Name, P for PublishDate or R for Rating");
                var updateInput = Console.ReadLine();
                var isSuccess = Enum.TryParse(typeof(Constants.UpdateType), updateInput.ToUpper(), out var updateType);
                if (!isSuccess)
                {
                    Console.WriteLine("Invalid Operation");
                }
                else
                {
                    Console.WriteLine("Enter the new value :");
                    var newValue = Console.ReadLine();
                    switch (updateType)
                    {
                        case Constants.UpdateType.A:
                            foundBooks.Author = newValue;
                            break;
                        case Constants.UpdateType.N:
                            foundBooks.Name = newValue;
                            break;
                        case Constants.UpdateType.P:
                            foundBooks.PublishDate = Convert.ToInt32(newValue);
                            break;
                        case Constants.UpdateType.R:
                            foundBooks.Rating = Convert.ToDouble(newValue);
                            break;
                        default:
                            break;
                    }

                    SearchBook();
                }
            }
        }

        public static void AddBooks()
        {
            Variables.Instance.booksList = new List<Book>() {
            new Book() { Author = "J.K. Rowling, Mary GrandPrÃ©", Name = "Harry Potter and the Philosopher's Stone", PublishDate = 1997, Rating = 4.44 },
            new Book() { Author = "Andrzej Sapkowski", Name = "Wieża Jaskółki", PublishDate = 1997, Rating = 4.34},
            new Book() { Author = "Kimberly Lauren", Name = "Beautiful Broken Rules", PublishDate = 2013, Rating = 4.15},
            new Book() { Author = "Alan Bradley", Name = "The Weed That Strings the Hangman's Bag", PublishDate = 2010, Rating = 3.99},
            new Book() { Author = "Jeff Lindsay", Name = "Dexter in the Dark", PublishDate = 2006, Rating = 3.49},
            new Book() { Author = "Aldous Huxley", Name = "The Doors of Perception & Heaven and Hell", PublishDate = 1956, Rating = 3.96},
            new Book() { Author = "Robert Lopshire", Name = "Put Me in the Zoo", PublishDate = 1960, Rating = 4.13},
            new Book() { Author = "Leslie Jamison", Name = "The Empathy Exams: Essays", PublishDate = 2014, Rating = 3.62},
            new Book() { Author = "Stephanie Perkins", Name = "Anna and the French Kiss", PublishDate = 2010, Rating = 4.08},
            new Book() { Author = "Jennifer Estep", Name = "Spider's Bite", PublishDate = 2010, Rating = 3.87},
            new Book() { Author = "Tess Gerritsen", Name = "The Silent Girl", PublishDate = 2011, Rating = 4.13},
            new Book() { Author = "Janette Sebring Lowrey, Gustaf Tenggren", Name = "The Poky Little Puppy (a Little Golden Book)", PublishDate = 1942, Rating = 4.08},
            new Book() { Author = "Laurence Rees", Name = "Auschwitz: A New History", PublishDate = 2005, Rating = 4.24},
            new Book() { Author = "John Layman, Rob Guillory", Name = "Taster's Choice", PublishDate = 2009, Rating = 4},
            new Book() { Author = " Franz Kafka, Nahum N. Glatzer, John Updike, Willa Muir, Edwin Muir, Tania Stern, James Stern, Ernst Kaiser, Eithne Wilkins", Name = "Sämtliche Erzählungen", PublishDate = 1946, Rating = 4.34},
            new Book() { Author = "Isaac Asimov", Name = "Second Foundation (Foundation #3)", PublishDate = 1953, Rating = 4.23},
            new Book() { Author = "Brandon Sanderson", Name = "The Way of Kings, Part 1", PublishDate = 2011, Rating = 4.67},
            new Book() { Author = "James Patterson", Name = "Cross Country", PublishDate = 2008, Rating = 3.83},
            new Book() { Author = "Stephen Crane, George Stade, Richard Fusco", Name = "The Red Badge of Courage", PublishDate = 1895, Rating = 3.64},
            new Book() { Author = "Edward Gorey", Name = "Amphigorey", PublishDate = 1972, Rating = 4.08}
            };
        }
    }
}
