using System;
using System.Linq;
using System.Threading.Tasks;
using NationBuilderConnect.Client.Services;
using NationBuilderConnect.Client.Services.Parameters;
using NationBuilderConnect.Client.Utilities;

namespace NationBuilderConnect.Client.Samples
{
    public class ListServiceSamples
    {
        public async Task RunAsync()
        {
            var now = DateTime.UtcNow;
            var nowString = now.ToString("yyyyMMddHHmmss");
            var initialName = "b-" + nowString;
            var updateName = "a-" + nowString;

            using (var service = new ListService())
            {
                // Create a list
                var afterCreate = await service.CreateAsync(new CreateListParameters(initialName, initialName, 1));

                // Update the list
                var afterUpdate = await service.UpdateAsync(afterCreate.Id, new UpdateListParameters(updateName, updateName, 1));

                // Get 8 lists, with page size of 3
                var lists = await service.GetIndex(3).SetLimit(8).ToListAsync();

                // Get 1 page of lists, size 3
                var listPages = await service.GetIndexAsPages(3).SetLimit(1).ToListAsync();

                // Add people to the list
                await service.AddPeopleAsync(afterCreate.Id, Enumerable.Range(1, 100).ToList());

                // Get the people in the list
                var people = await service.GetPeople(afterCreate.Id).ToListAsync();

                // Remove some of the people from the list
                await service.RemovePeopleAsync(afterCreate.Id, Enumerable.Range(50, 80).ToList());

                // Add a tag to the people in the list
                await service.AddTagAsync(afterCreate.Id, "nbc_testtag1");

                // Remove the tag from the people in the list
                await service.RemoveTagAsync(afterCreate.Id, "nbc_testtag1");

                // Delete the list
                await service.DeleteAsync(afterCreate.Id);
            }
        }

        public void Run()
        {
            var now = DateTime.UtcNow;
            var nowString = now.ToString("yyyyMMddHHmmss");
            var initialName = "b-" + nowString;
            var updateName = "a-" + nowString;

            using (var service = new ListService())
            {
                // Create a list
                var afterCreate = service.Create(new CreateListParameters(initialName, initialName, 1));

                // Update the list
                var afterUpdate = service.Update(afterCreate.Id, new UpdateListParameters(updateName, updateName, 1));

                // Get 8 lists, with page size of 3
                var lists = service.GetIndex(3).SetLimit(8).ToList();

                // Get 1 page of lists, size 3
                var listPages = service.GetIndexAsPages(3).SetLimit(1).ToList();

                // Add people to the list
                service.AddPeople(afterCreate.Id, Enumerable.Range(1, 100).ToList());

                // Get the people in the list
                var people = service.GetPeople(afterCreate.Id).ToList();

                // Remove some of the people from the list
                service.RemovePeople(afterCreate.Id, Enumerable.Range(50, 80).ToList());

                // Add a tag to the people in the list
                service.AddTag(afterCreate.Id, "nbc_testtag1");

                // Remove the tag from the people in the list
                service.RemoveTag(afterCreate.Id, "nbc_testtag1");

                // Delete the list
                service.Delete(afterCreate.Id);
            }
        }
    }
}