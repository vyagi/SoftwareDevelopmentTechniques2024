namespace MementoPattern;

public class Word
{
    public readonly Document _document;
    public readonly History _history;

    public Word(Document document, History history)
    {
        _document = document;
        _history = history;
    }

    public void SetContent(string content) 
    {
        _history.Save(new DocumentMemento(_document.GetContent()));
        _document.SetContent(content);
    }

    public string GetContent() => _document.GetContent();

    public void RestoreContent() => _document.SetContent(_history.Retrieve().Content);
}

public class Document
{
    private string _content;

    public string GetContent() => _content;

    public string SetContent(string content) => _content = content;
}

public class DocumentMemento
{
    public string Content { get; }

    public DocumentMemento(string content) => Content = content;
}

public class History 
{
    private readonly Stack<DocumentMemento> _history = new();

    public void Save(DocumentMemento memento) => _history.Push(memento);

    public DocumentMemento Retrieve() => _history.Pop();
}

//Refactor this because it violates SRP
//public class Document
//{
//    private string _content;

//    private readonly Stack<string> _history = new Stack<string>();

//    public string GetContent() => _content;

//    public string SetContent(string content) => _content = content;


//    public void CreateState() => _history.Push(_content);

//    public void RestoreState() => _content = _history.Pop();
//}
