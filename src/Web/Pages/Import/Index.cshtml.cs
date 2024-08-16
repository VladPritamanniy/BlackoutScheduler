using Application.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Import
{
    public class IndexModel : PageModel
    {
        private readonly IImportService _importService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IImportService importService, ILogger<IndexModel> logger)
        {
            _importService = importService;
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task OnPostImportDataFromFileAsync()
        {
            try
            {
                await _importService.ImportDataFromFile();
            }
            catch (FormatException e)
            {
                _logger.LogError(e.Message);
                ModelState.AddModelError(string.Empty, e.Message);
            }
        }
    }
}
