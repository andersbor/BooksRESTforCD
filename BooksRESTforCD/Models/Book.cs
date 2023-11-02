namespace BooksRESTforCD.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"{Id} {Title} {Price}";
        }

        public void ValidateTitle()
        {
            if (Title == null)
            {
                throw new ArgumentNullException(nameof(Title));
            }
            if (Title.Length < 3)
            {
                throw new ArgumentException("Title must be at least 3 characters long", nameof(Title));
            }
        }

        public void ValidatePrice()
        {
            if (Price < 1)
            {
                throw new ArgumentException("Price must be positive", nameof(Price));
            }
        }

        public void Validate()
        {
            ValidateTitle();
            ValidateTitle();
        }
    }
}
