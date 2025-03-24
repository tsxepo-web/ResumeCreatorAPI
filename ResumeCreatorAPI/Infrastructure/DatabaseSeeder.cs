using System.Globalization;
using MongoDB.Driver;
using ResumeCreatorAPI.Domain;
using ResumeCreatorAPI.Infrastructure.MongoDb;

namespace ResumeCreatorAPI.Infrastructure
{
    public class DatabaseSeeder
    {
        private readonly IMongoCollection<Resume> _resumeCollection;

        public DatabaseSeeder(MongodbContext context)
        {
            _resumeCollection = context.Resumes;
        }

        public async Task SeedAsync()
        {
            var existingCount = await _resumeCollection.CountDocumentsAsync(_ => true);
            if (existingCount > 0) return; 

            var sampleResumes = new List<Resume>
        {
            new()
            {
                Id = null,
                Basics = new Basics
                {
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    Phone = "(123) 456-7890",
                    Summary = "Experienced software developer",
                    Location = new Location
                    {
                        Address = "123 Main St",
                        City = "New York",
                        Region = "NY",
                        CountryCode = "US",
                        PostalCode = "10001"
                    }
                },
                Work = new List<Work>
                {
                    new Work
                    {
                        Name = "Tech Corp",
                        Position = "Senior Developer",
                        StartDate = DateTime.Parse("2001-01-01", System.Globalization.CultureInfo.InvariantCulture),
                        EndDate = DateTime.Parse("2001-01-01", System.Globalization.CultureInfo.InvariantCulture),
                        Summary = "Worked on full-stack development",
                        Highlights = new List<string> { "Led a team of 5 developers" }
                    }
                },
                Education = new List<Education>
                {
                    new Education
                    {
                        Institution = "MIT",
                        Area = "Computer Science",
                        StudyType = "Bachelor",
                        StartDate = DateTime.Parse("2015-09-01", System.Globalization.CultureInfo.InvariantCulture),
                        EndDate = DateTime.Parse("2019-06-01", System.Globalization.CultureInfo.InvariantCulture),
                        Score = 3.9
                    }
                },
                Skills = new List<Skill>
                {
                    new Skill { Name = "C#", Keywords = new List<string> { "ASP.NET", "Entity Framework" } },
                    new Skill { Name = "JavaScript", Keywords = new List<string> { "Angular", "React" } }
                }
            },
            new()
            {
                Id = null,
                Basics = new Basics
                {
                    Name = "John Doris",
                    Email = "john.doris@example.com",
                    Phone = "(123) 456-7890",
                    Summary = "Experienced software developer",
                    Location = new Location
                    {
                        Address = "123 Main St",
                        City = "Durban",
                        Region = "NY",
                        CountryCode = "US",
                        PostalCode = "10001"
                    }
                },
                Work = new List<Work>
                {
                    new Work
                    {
                        Name = "Tech Corp",
                        Position = "Senior Developer",
                        StartDate = DateTime.Parse("2001-01-01", System.Globalization.CultureInfo.InvariantCulture),
                        EndDate = DateTime.Parse("2001-01-01", System.Globalization.CultureInfo.InvariantCulture),
                        Summary = "Worked on full-stack development",
                        Highlights = new List<string> { "Led a team of 5 developers" }
                    }
                },
                Education = new List<Education>
                {
                    new Education
                    {
                        Institution = "MIT",
                        Area = "Computer Science",
                        StudyType = "Bachelor",
                        StartDate = DateTime.Parse("2015-09-01", System.Globalization.CultureInfo.InvariantCulture),
                        EndDate = DateTime.Parse("2019-06-01", System.Globalization.CultureInfo.InvariantCulture),
                        Score = 3.9
                    }
                },
                Skills = new List<Skill>
                {
                    new Skill { Name = "C#", Keywords = new List<string> { "ASP.NET", "Entity Framework" } },
                    new Skill { Name = "JavaScript", Keywords = new List<string> { "Angular", "React" } }
                }
            }
        };

            await _resumeCollection.InsertManyAsync(sampleResumes);
        }
    }
}