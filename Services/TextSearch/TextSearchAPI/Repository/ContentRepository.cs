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

            // foreach (var hit in result.Hits) hit.Source.Id = hit.Id;
            return result.Documents.ToImmutableList();

        }

        public async Task<Content?> SaveAsync(Content content)
        {
            content.Created = DateTime.Now;

            var response = await _client.IndexAsync(content, x => x.Index(indexName));


            if (!response.IsValid) return null;

            // content.Id = response.Id;

            return content;


        }
    }
}