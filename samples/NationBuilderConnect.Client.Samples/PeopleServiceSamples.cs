using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NationBuilderConnect.Client.Model;
using NationBuilderConnect.Client.Services;
using NationBuilderConnect.Client.Services.Parameters;
using NationBuilderConnect.Client.Utilities;
using NationBuilderConnect.Model;

namespace NationBuilderConnect.Client.Samples
{
    public class PeopleServiceSamples
    {
        public async Task RunAsync()
        {
            using (var service = new PersonService())
            {
                string firstName = "Test", lastName = $"Person{DateTime.UtcNow:yyyyMMddHHmmss}";

                var update = new PersonUpdate
                {
                    FirstName = firstName,
                    LastName = lastName,
                    SupportLevel = SupportLevel.Undecided
                };
                update.SetCustomField("test1", "blah1");

                // Create a new person
                var createResult = await service.CreateAsync(update);

                var personId = createResult.Person.Id;

                // Update the new person's support level
                var updateResult = await service.UpdateAsync(personId, new PersonUpdate
                {
                    SupportLevel = SupportLevel.Supporter
                });

                // Match the new person
                var matched = await service.MatchAsync(new MatchPersonParameters
                {
                    FirstName = firstName,
                    LastName = lastName
                });

                // Search for the new person
                var searchResults = await service.Search(new SearchPeopleParameters
                {
                    FirstName = firstName,
                    LastName = lastName
                }).FirstOrDefaultAsync();

                // Add some tags to the person
                await service.AddTagsAsync(personId, new List<string> { "nbc_testtag1", "nbc_testtag2" });

                // Remove one of the tags we added
                await service.RemoveTagsAsync(personId, new List<string> { "nbc_testtag1" });

                // Add a private note to the person
                await service.AddPrivateNoteAsync(personId, "NBC - Test private note");

                // Get the person details
                var showResult = await service.ShowAsync(personId, true);

                // Get first 5 voters near Chicago
                var nearby = await service.GetNearby(new GetNearbyPeopleParameters(new Coordinates(41.8781, -87.6298), 5000))
                    .SetLimit(5)
                    .ToListAsync();

                // Get first 2 people from the person index
                var indexPeople = await service.GetIndex()
                    .SetLimit(2)
                    .ToListAsync();

                // Get the first 2 pages of people from the people index. Each page will contain 2 people.
                var indexPages = await service.GetIndexAsPages(2)
                    .SetLimit(2)
                    .ToListAsync();

                // Delete the test person we created
                await service.DestroyAsync(personId);
            }
        }

        public void Run()
        {
            using (var service = new PersonService())
            {
                string firstName = "Test", lastName = $"Person{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}";

                var update = new PersonUpdate
                {
                    FirstName = firstName,
                    LastName = lastName,
                    SupportLevel = SupportLevel.Undecided
                };
                update.SetCustomField("test1", "blah1");

                // Create a new person
                var createResult = service.Create(update);

                var personId = createResult.Person.Id;

                // Update the new person's support level
                var updateResult = service.Update(personId, new PersonUpdate
                {
                    SupportLevel = SupportLevel.Supporter
                });

                // Match the new person
                var matched = service.Match(new MatchPersonParameters
                {
                    FirstName = firstName,
                    LastName = lastName
                });

                // Search for the new person
                var searchResults = service.Search(new SearchPeopleParameters
                {
                    FirstName = firstName,
                    LastName = lastName
                }).FirstOrDefault();

                // Add some tags to the person
                service.AddTags(personId, new List<string> { "testtag1", "testtag2" });

                // Remove one of the tags we added
                service.RemoveTags(personId, new List<string> { "testtag1" });

                // Add a private note to the person
                service.AddPrivateNote(personId, "Test private note");

                // Get the person details
                var showResult = service.Show(personId, true);

                // Get first 5 voters near Chicago
                var nearby = service.GetNearby(new GetNearbyPeopleParameters(new Coordinates(41.8781, -87.6298), 5000))
                    .SetLimit(5)
                    .ToList();

                // Get first 2 people from the person index
                var indexPeople = service.GetIndex()
                    .SetLimit(2)
                    .ToList();

                // Get the first 2 pages of people from the people index. Each page will contain 2 people.
                var indexPages = service.GetIndexAsPages(2)
                    .SetLimit(2)
                    .ToList();

                // Delete the test person we created
                service.Destroy(personId);
            }
        }
    }
}