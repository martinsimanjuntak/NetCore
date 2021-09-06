using Microsoft.AspNetCore.Mvc;
using NETCore1.Base;
using NETCore1.Models;
using NETCore1.Repository.Data;
using System.Net;
    
namespace NETCore1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController<Person, PersonRepository, string>

    {

        private readonly PersonRepository personRepository;
        public PersonController(PersonRepository repository) : base(repository)
        {
            this.personRepository= repository;
        }

        [HttpGet("getperson")]
        public ActionResult GetPerson()
        {

            try
            {
                return Ok(new
                {
                    data = personRepository.GetPerson(),
                    status = HttpStatusCode.OK,
                    message = "Success"
                });
            }
            catch
            {
                return BadRequest(new
                {
                    status = HttpStatusCode.NoContent,
                    message = "No Data",
                    /*error = e*/
                });
            }

        }
        [HttpGet("getperson/{nik}")]
        public ActionResult GetPerson(string nik)
        {

            try
            {
                return Ok(new
                {
                    data = personRepository.GetPerson(nik),
                    status = HttpStatusCode.OK,
                    message = "Success"
                });
            }
            catch
            {
                return BadRequest(new
                {
                    status = HttpStatusCode.NoContent,
                    message = "No Data",
                });
            }

        }

        [HttpPost("register")]
        public ActionResult Register(PersonViewModel personViewModel)
        {

            try
            {
                if (personRepository.Register(personViewModel) == false)
                {
                    return BadRequest(new
                    {
                       
                        statusCode = HttpStatusCode.BadRequest,
                        message = "Data Sudah Digunakan"
                    });
                    
                   
                }
                else
                {
                    return Ok(new
                    {
                        statusCode = HttpStatusCode.OK,
                        message = "Success"
                    });

                }
                
            }
            catch
            {
                return BadRequest(new
                {
                    status = HttpStatusCode.BadRequest,
                    message = "Data Tidak Bisa dupllikat"
                });

            }

        }






    }
    
}
