using GraphQL.Domain.DTOs;
using GraphQL.Infrastructure.DataAccess;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.WebApi.GraphQLConfiguration
{
    public class Subscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<CompanyDto>> OnCompanyCreate([Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, CompanyDto>("CompanyCreated", cancellationToken);
        }


        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<EmploymentDto>> OnEmployeeGet([Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, EmploymentDto>("ReturnedEmployee", cancellationToken);
        }
    }
}
