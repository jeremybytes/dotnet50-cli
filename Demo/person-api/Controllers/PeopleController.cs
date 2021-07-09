using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace person_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        IPeopleProvider provider;

        public PeopleController(IPeopleProvider provider)
        {
            this.provider = provider;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return provider.GetPeople();
        }

        [HttpGet("{id}")]
        public Person Get(int id)
        {
            try
            {
                return provider.GetPerson(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
