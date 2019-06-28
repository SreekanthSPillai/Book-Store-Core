using BusinessLibrary.Model;
using BusinessLibrary.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace AspNetCoreReactRedux.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        [Route("Contacts")]
        public async Task<IActionResult> Contacts()
        {
            return Ok(await _contactService.GetContacts());
        }

        [HttpPost]
        [Route("SaveContact")]
        public async Task<IActionResult> SaveContact([FromBody] ContactModel model)
        {
            return Ok(await _contactService.SaveContact(model));
        }

        [HttpDelete]
        [Route("DeleteContact/{contactId}")]
        public async Task<IActionResult> DeleteContact(int contactId)
        {
            return Ok(await _contactService.DeleteContact(contactId));
        }

    }
}
