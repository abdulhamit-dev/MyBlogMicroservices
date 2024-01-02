using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Nest;
using TextSearchAPI.Models;

namespace TextSearchAPI.Repository
{
    public class ContentRepository
    {
        private readonly ElasticClient _client;
        private const string indexName = "content";

        public ContentRepository(ElasticClient client)
        {
            _client = client;
        }
        public async Task<ImmutableList<Content>> GetAllAsync()
        {
            var result = await _client.SearchAsync<Content>(s => s.Index(indexName).Query(q => q.MatchAll()));

            return result.Documents.ToImmutableList();

        }
        public async Task<ImmutableList<Content>> SearchAsync(string searchText)
        {
            var result = await _client.SearchAsync<Content>(s => s
                .Index(indexName)
                .Query(q => q
                    .Bool(b => b
                        .Should(
                            bs => bs.Wildcard(w => w.Field(f => f.Title).Value("*" + searchText + "*")),
                            bs => bs.Wildcard(w => w.Field(f => f.Text).Value("*" + searchText + "*"))
                        )
                    )
                )
            );

            return result.Documents.ToImmutableList();
        }

        public async Task<Content?> SaveAsync(Content content)
        {


            var response = await _client.IndexAsync(content, x => x.Index(indexName));


            if (!response.IsValid) return null;


            return content;


        }
    }
}