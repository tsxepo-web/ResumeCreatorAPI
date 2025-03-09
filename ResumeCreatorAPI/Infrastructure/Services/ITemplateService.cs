using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeCreatorAPI.Infrastructure.Services
{
    public interface ITemplateService
    {
        string GenerateTemplate(string templateStyle);
    }
}