using ContentAPI.Models.Dtos;
using RabbitMQ.Client;

namespace ContentAPI.Services;

public interface ITextSearchService
{
    void Publish(TextSearchContentEvent logCreatedEvent);
}
