using AngleSharp.Dom;
using DigiLearn.Web.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketModule.Core.DTOs.Tickets;
using TicketModule.Core.Services;

namespace DigiLearn.Web.Areas.Admin.Pages.Tickets
{
    public class IndexModel : BaseRazorFilter<TicketFilterParams>
    {
        private readonly ITicketService _service;

        public IndexModel(ITicketService service)
        {
            _service = service;
        }

        public TicketFilterResult FilterResult { get; set; }

        public async Task OnGet()
        {
            FilterResult = await _service.GetTicketsByFilter(FilterParams);
        }
    }
}
