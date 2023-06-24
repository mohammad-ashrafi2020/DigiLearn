using Common.EventBus.Abstractions;
using Common.EventBus.Events;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiLearn.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IEventBus _eventBus;
        public IndexModel(ILogger<IndexModel> logger, IEventBus eventBus)
        {
            _logger = logger;
            _eventBus = eventBus;
        }

        public void OnGet()
        {
            _eventBus.Publish(new UserRegistered()
            {
                PhoneNumber = "091777",
                Email = "Test@test.com"
            }, "test");
        }
    }
}