Book book = new Book() {Isbn = "12345", Author = "Zeynel Şahin", Tittle = "Kral"};

book.ShowBook();
CareTaker history = new CareTaker();
history.Memento = book.CreateUndo();

book.Isbn = "5432";
book.Tittle = "Kartal";

book.ShowBook();

book.RestoreFromUndo(history.Memento);
book.ShowBook();

class Book
{
    private string _tittle;
    private string _author;
    private string _isbn;
    private DateTime _lastEdited;
    public string Tittle
    {
        get { return _tittle; }
        set
        {
            _tittle = value; 
            SetLastEdited();
        }
    }

    public string Author
    {
        get { return _author; }
        set
        {
            _author = value; 
            SetLastEdited();
        }
    }

    public string Isbn
    {
        get { return _isbn; }
        set
        {
            _isbn = value;
            SetLastEdited();
        }
    }

    private void SetLastEdited()
    {
        _lastEdited = DateTime.UtcNow;
    }
    public Memento CreateUndo()
    {
        return new Memento(_isbn, _tittle, _author, _lastEdited);
    }

    public void RestoreFromUndo(Memento memnto)
    {
        _tittle = memnto.Tittle;
        _isbn = memnto.Isbn;
        _author = memnto.Author;
        _lastEdited = memnto.LastEdited;
    }

    public void ShowBook()
    {
        Console.WriteLine("{0}, {1}, {2} edited{3}",Isbn,Tittle,Author,_lastEdited);
    }
}

class Memento
{
    public Memento(string isbn, string tittle, string author, DateTime lastEdited)
    {
        Isbn = isbn;
        Tittle = tittle;
        Author = author;
        LastEdited = lastEdited;
    }

    public string Isbn { get; set; }
    public string Tittle { get; set; }
    public string Author { get; set; }
    public DateTime LastEdited { get; set; }

    
    
}

class CareTaker
{
    public Memento Memento { get; set; }
}