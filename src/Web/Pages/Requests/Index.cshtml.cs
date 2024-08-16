using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Requests
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IGroupService _groupService;
        private readonly IAddressSevice _addressService;
        private readonly IScheduleService _scheduleService;

        public IndexModel(ILogger<IndexModel> logger, IGroupService requestService, IAddressSevice addressService, IScheduleService scheduleService)
        {
            _logger = logger;
            _groupService = requestService;
            _addressService = addressService;
            _scheduleService = scheduleService;
        }

        public void OnGet()
        {
        }

        //Відібрати адреси, яким не назначено групу
        public async Task<IActionResult> OnPostGetNotAssignedAddressesAsync()
        {
            var result = await _addressService.GetNotAssignedAddresses();
            return Page();
        }

        //Відібрати графік відключень світла для адреси Бойченко 30
        public async Task<IActionResult> OnPostGetBlackoutScheduleForAddressAsync()
        {
            var address = "Бойченко 30";
            var result = await _groupService.GetBlackoutScheduleForAddress(address);
            return Page();
        }

        //Відібрати групу, якій найчастіше виключають світло в неділю
        public async Task<IActionResult> OnPostGetGroupWithMaxCountBlackoutsAsync()
        {
            var result = await _groupService.GetGroupWithMaxCountBlackouts();
            return Page();
        }

        //Відібрати групу, якій вимикають світло на найбільший час з понеділка по середу включно
        public async Task<IActionResult> OnPostGetGroupWithLongestTimeBlackoutsAsync()
        {
            try
            {
                var result = await _groupService.GetGroupWithLongestTimeBlackouts();
                return Page();
            }
            catch (ArgumentNullException e)
            {
                _logger.LogError(e.Message);
                return Page();
            }
        }

        //Назначити на адресу Бажана 14 групу 4
        public async Task OnPostAssignGroupToAddressAsync()
        {
            var address = "Бажана 14";
            var group = 4;
            try
            {
                await _addressService.AssignGroupToAddress(address, group);
            }
            catch (ArgumentNullException e)
            {
                _logger.LogError(e.Message);
            }
        }

        //Додати 2 нові адреси будь-які
        public async Task OnPostAddTwoNewAddressesAsync()
        {
            var addressDtoList = new List<AddressDto>
            {
                new()
                {
                    Street = "Героїв України 44",
                    GroupId = 1
                },
                new()
                {
                    Street = "Героїв Дніпра 39",
                    GroupId = 2
                }
            };
            await _addressService.AddTwoNewAddresses(addressDtoList);
        }

        //Додати новий графік вимкнення будь-який
        public async Task OnPostAddNewBlackoutScheduleAsync()
        {
            var scheduleDto = new ScheduleDto
            {
                DayOfWeek = "Неділя",
                StartTime = new TimeSpan(12, 0, 0),
                FinishTime = new TimeSpan(16, 0, 0),
                GroupId = 1
            };

            await _scheduleService.AddNewBlackoutSchedule(scheduleDto);
        }
    }
}
