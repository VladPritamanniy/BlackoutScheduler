using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Application.Interfaces;
using Application.Helpers;

namespace Web.Pages.JsonSerialize
{
    public class IndexModel : PageModel
    {
        private readonly IGroupService _requestService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IGroupService requestService, ILogger<IndexModel> logger)
        {
            _requestService = requestService;
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostExportAllAsync()
        {
            var result = await _requestService.GetAllGroup();
            var bytes = await SerializeHelper.SerializeForFile(result);

            return File(bytes, "application/json", "groups.json");
        }

        public async Task<IActionResult> OnPostExportByIdAsync()
        {
            int groupId = 1;
            var result = await _requestService.GetGroupById(groupId);
            var bytes = await SerializeHelper.SerializeForFile(result);

            return File(bytes, "application/json", "group.json");
        }
    }
}
