using TestBE.Infrastructure.Lifetimes;
using TestBE.Models.Models.Webhook;

namespace TestBE.Business.WebhookService;

public interface IRegisterWebhookService : IScopedService
{
    Task RegisterUninstallWebhook(RegisterUninstallModel store);
}
