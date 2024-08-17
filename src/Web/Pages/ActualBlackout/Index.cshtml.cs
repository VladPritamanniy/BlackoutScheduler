using Application.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.ActualBlackout
{
    public class IndexModel : PageModel
    {
        private readonly IGroupService _groupService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IGroupService groupService, ILogger<IndexModel> logger)
        {
            _groupService = groupService;
            _logger = logger;
        }

        public string Result { get; set; }

        public async Task OnGet()
        {
            int groupId = 1;

            try
            {
                var isBlackout = await _groupService.ActualBlackoutByGroupId(groupId);
                if (isBlackout)
                {
                    Result = "Світла нема.";
                }
                else
                {
                    Result = "Світло є.";
                }
            }
            catch (ArgumentNullException e)
            {
                _logger.LogError(e.Message);
                ModelState.AddModelError(string.Empty, e.Message);
            }
        }
    }
}
