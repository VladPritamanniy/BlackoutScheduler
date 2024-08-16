using System.Text.RegularExpressions;
using Application.Dto;
using Application.Interfaces;
using Core.Repositories.Base;
using Core.Specifications;
using Group = Core.Entities.Group;
using Core.Entities;

namespace Application.Services
{
    public class ImportService : IImportService
    {
        private static string CurrentDirectory = Directory.GetCurrentDirectory();
        private const string FileName = "dataForImport.txt";
        private const string TimeFormat = @"^\d{2}:\d{2}-\d{2}:\d{2}$";
        private readonly IRepository<Group> _groupRepository;
        private readonly IRepository<Schedule> _schedularRepository;

        public ImportService(IRepository<Group> groupRepository, IRepository<Schedule> schedularRepository)
        {
            _groupRepository = groupRepository;
            _schedularRepository = schedularRepository;
        }

        public async Task ImportDataFromFile()
        {
            string path = CurrentDirectory + "\\" + FileName;
            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var model = await ParseScheduleEntry(line);
                    await AddGroupIfExistById(model.GroupId);
                    await AddSchedules(model);
                }
            }
        }

        private async Task<ScheduleImportModel> ParseScheduleEntry(string line)
        {
            var model = new ScheduleImportModel();
            
            var parts = line.Replace(" ", "").Split('.');

            if (!int.TryParse(parts[0].Trim(), out int groupId))
            {
                throw new FormatException($"Wrong format enter data from file. {groupId} - not correct format for id.");
            }
            model.GroupId = groupId;

            var timeRanges = parts[1].Split(';');

            for (int i = 0; i < timeRanges.Length; i++)
            {
                if (!Regex.IsMatch(timeRanges[i], TimeFormat))
                {
                    throw new FormatException($"Wrong format enter data from file. {timeRanges[i]} - not correct format for time.");
                }

                string[] timeGroupItems = timeRanges[i].Split('-');

                var timeModel = new TimeModel();

                if (TimeSpan.TryParse(timeGroupItems[0], out TimeSpan startTime) && TimeSpan.TryParse(timeGroupItems[1], out TimeSpan finishTime))
                {
                    timeModel.StartTime = startTime;
                    timeModel.FinishTime = finishTime;
                }
                model.Times.Add(timeModel);
            }

            return model;
        }

        private async Task AddGroupIfExistById(int id)
        {
            var specification = new GroupItemByIdSpecification(id);
            var result = await _groupRepository.FirstOrDefaultAsync(specification);
            if (result == null)
            {
                var entity = new Group
                {
                    Id = id,
                    Name = "Головна",
                    Description = "Опис головної группи"

                };
                _groupRepository.Add(entity);
                await _groupRepository.SaveChangesAsync();
            }
        }

        private async Task AddSchedules(ScheduleImportModel timesModelList)
        {
            foreach (var item in timesModelList.Times)
            {
                var entity = new Schedule
                {
                    DayOfWeek = "Вівторок",
                    StartTime = item.StartTime,
                    FinishTime = item.FinishTime,
                    GroupId = timesModelList.GroupId
                };
                await _schedularRepository.AddAsync(entity);
            }
            await _schedularRepository.SaveChangesAsync();
        }
    }
}
