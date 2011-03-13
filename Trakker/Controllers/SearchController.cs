using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lucene.Net.Search;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Analysis;
using Lucene.Net.Store;
using Lucene.Net.Analysis.Standard;
using Trakker.Data;
using Trakker.Data.Services;

namespace Trakker.Controllers
{
    public partial class SearchController : MasterController
    {

        public SearchController(ITicketService ticketService, IUserService userService, IProjectService projectService)
            : base(projectService, ticketService, userService)
        {
        }

        public virtual ActionResult SearchIndex()
        {

            //Setup indexer

            Directory directory = FSDirectory.GetDirectory("LuceneIndex", true);
            Analyzer analyzer = new StandardAnalyzer();
            IndexWriter writer = new IndexWriter(directory, analyzer, true);

            IndexReader red = IndexReader.Open(directory);
            int totDocs = red.MaxDoc();
            red.Close();

            foreach (var ticket in _ticketService.GetAllTickets())
            {
                AddListingToIndex(ticket, writer);
            }


            writer.Optimize();
            //Close the writer
            writer.Close();

            //Setup searcher
            IndexSearcher searcher = new IndexSearcher(directory);
            QueryParser parser = new QueryParser("postBody", analyzer);


            //Clean up everything
            searcher.Close();
            directory.Close();

            red = IndexReader.Open(directory);
            totDocs = red.MaxDoc();
            red.Close();


            return View();
        }

        private static void Search(string text, IndexSearcher searcher, QueryParser parser)
        {
            //Supply conditions
            Query query = parser.Parse(text);

            //Do the search
            Hits hits = searcher.Search(query);

            //Display results
            Console.WriteLine("Searching for '" + text + "'");
            int results = hits.Length();
            Console.WriteLine("Found {0} results", results);
            for (int i = 0; i < results; i++)
            {
                Document doc = hits.Doc(i);
                float score = hits.Score(i);
                Console.WriteLine("--Result num {0}, score {1}", i + 1, score);
                Console.WriteLine("--ID: {0}", doc.Get("id"));
                Console.WriteLine("--Text found: {0}" + Environment.NewLine, doc.Get("postBody"));
            }
        }

        private static void AddListingToIndex(Ticket ticket, IndexWriter writer)
        {
            Document doc = new Document();
            doc.Add(new Field("id", ticket.Id.ToString(), Field.Store.YES, Field.Index.UN_TOKENIZED));
            doc.Add(new Field("summary", ticket.Summary, Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("keyName", ticket.KeyName, Field.Store.YES, Field.Index.TOKENIZED));
            writer.AddDocument(doc);
        }

    }
}
