using GraphQL.Client.Abstractions;
using GraphQL.ClientWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.ClientWeb
{
    public class CompanyConsumer
    {
        private readonly IGraphQLClient _client;
        public CompanyConsumer(IGraphQLClient client)
        {
            _client = client;
        }

        public async Task<List<Company>> GetAllCompanies()
        {
            var query = new GraphQLRequest
            {
                Query = @"query{
                          allCompaniesOnly{
                            id,
                            name,
                            nif
                          }
                        }"
            };

            var a = _client.CreateSubscriptionStream<object>(query);
            var response = await _client.SendQueryAsync(query, () => new { allCompaniesOnly = new List<Company>() });
            return response.Data.allCompaniesOnly;
        }
        public async Task<List<Company>> GetAllCompaniesWithoutId()
        {
            var query = new GraphQLRequest
            {
                Query = @"query{
                          allCompaniesOnly{
                            name,
                            nif
                          }
                        }"
            };

            var a = _client.CreateSubscriptionStream<object>(query);
            var response = await _client.SendQueryAsync(query, () => new { allCompaniesOnly = new List<Company>() });
            return response.Data.allCompaniesOnly;
        }
    }
}
