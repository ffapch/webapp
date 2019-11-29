using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapp.Data;

namespace webapp.Controllers
{
    [Route("/")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ValueDbContext _dbContext;

        public ValuesController(ValueDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("/db/get")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetDb()
        {
            return _dbContext.Values.Select(x => x.Name).ToArray();
        }

        [Route("/db/add/{valueName}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Add(string valueName)
        {
            await _dbContext.Values.AddAsync(new Data.Entities.ValueEntity
            {
                Name = valueName
            });

            await _dbContext.SaveChangesAsync();

            return _dbContext.Values.Select(x => x.Name).ToArray();
        }
    }
}
