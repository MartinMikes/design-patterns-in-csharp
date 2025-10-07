using System;

namespace FactoryMethod
{
    // Product interface
    public interface IDocument
    {
        void Open();
        void Save();
    }

    // Concrete Products
    public class PdfDocument : IDocument
    {
        public void Open() => Console.WriteLine("Opening PDF document");
        public void Save() => Console.WriteLine("Saving PDF document");
    }

    public class WordDocument : IDocument
    {
        public void Open() => Console.WriteLine("Opening Word document");
        public void Save() => Console.WriteLine("Saving Word document");
    }

    // Creator (abstract class)
    public abstract class DocumentCreator
    {
        // Factory Method
        public abstract IDocument CreateDocument();

        public void ProcessDocument()
        {
            IDocument doc = CreateDocument();
            doc.Open();
            doc.Save();
        }
    }

    // Concrete Creators
    public class PdfDocumentCreator : DocumentCreator
    {
        public override IDocument CreateDocument()
        {
            return new PdfDocument();
        }
    }

    public class WordDocumentCreator : DocumentCreator
    {
        public override IDocument CreateDocument()
        {
            return new WordDocument();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Factory Method Pattern Demo ===\n");

            DocumentCreator creator;

            // Create and process a PDF document
            Console.WriteLine("Creating PDF document:");
            creator = new PdfDocumentCreator();
            creator.ProcessDocument();

            Console.WriteLine("\nCreating Word document:");
            creator = new WordDocumentCreator();
            creator.ProcessDocument();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
