using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.ContactDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            return Ok(_mapper.Map<List<ResultContactDto>>(_contactService.TGetAll()));
        }

        [HttpPost]
        public IActionResult AddContact(CreateContactDto createContactDto)
        {
            var values = _mapper.Map<Contact>(createContactDto);
            _contactService.TAdd(values);
            return Ok("Hakkımda Başarılı Bir Şekilde Eklenmiştir");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var values = _contactService.TGetById(id);
            _contactService.TDelete(values);
            return Ok("Hakkımda Başarılı Bir Şekilde Silinmiştir");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var values = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(values);
            return Ok("Hakkımda Alana Başarılı Bir Şekilde Güncellenmiştir");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int ContactId)
        {
            var values = _contactService.TGetById(ContactId);
            return Ok(values);
        }
    }
}
