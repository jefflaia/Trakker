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
using Trakker.Models;
using Trakker.Data.Repositories;

namespace Trakker.Controllers
{
    public partial class SearchController : MasterController
    {

        public SearchController(ITicketService ticketService, IUserRepository userRepo, IProjectRepository projectRepo, ITicketRepository ticketRepo)
            : base(ticketService, userRepo, projectRepo, ticketRepo)
        {
        }

        public virtual ActionResult SearchIndex(string term)
        {

            //Setup indexer

            Directory directory = FSDirectory.GetDirectory("LuceneIndex", true);
            Analyzer analyzer = new StandardAnalyzer();
            IndexWriter writer = new IndexWriter(directory, analyzer, true);

            IndexReader red = IndexReader.Open(directory);
            int totDocs = red.MaxDoc();
            red.Close();

            foreach (var ticket in _ticketRepo.GetTicketsByProject(CurrentProject, 0, 1000).Items)
            {
                AddListingToIndex(ticket, writer);
            }


            writer.Optimize();
            //Close the writer
            writer.Close();

            //Setup searcher
            IndexSearcher searcher = new IndexSearcher(directory);
            MultiFieldQueryParser parser = new MultiFieldQueryParser(
                                         new string[] { 
                                             "summary", "keyName" },
                                         analyzer);






            Query query = parser.Parse(term);
            Hits hits = searcher.Search(query);

            var tickets = new List<Ticket>();

            for (int i = 0; i < hits.Length(); i++)
            {
                Document doc = hits.Doc(i);
                
                int id = 0;
                if (int.TryParse(doc.Get("id"), out id))
                {
                    tickets.Add(_ticketRepo.GetTicketById(id));
                }              
            }

            //Clean up everything
            searcher.Close();
            directory.Close();


            return View(new SearchIndexModel()
            {
                Tickets = tickets
            });
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
