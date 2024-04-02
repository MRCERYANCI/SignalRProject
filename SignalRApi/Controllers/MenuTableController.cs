using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.MenuTableDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTableController : ControllerBase
	{
		private readonly IMenuTableService _menuTableService;
        private readonly IMapper _mapper;

        public MenuTableController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
        }

        [HttpGet("MenuTableCount")]
		public IActionResult MenuTableCount()
		{
			return Ok(_menuTableService.TMenuTableCount());
		}

        [HttpGet]
        public IActionResult MenuTableList()
        {
            return Ok(_mapper.Map<List<ResultMenuTableDto>>(_menuTableService.TGetAll()));
        }

        [HttpPost]
        public IActionResult AddMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            createMenuTableDto.MenuStatus = false;

            var values = _mapper.Map<MenuTable>(createMenuTableDto);
            _menuTableService.TAdd(values);
            return Ok("Masa Başarılı Bir Şekilde Eklenmiştir");
        }
        [HttpDelete]
        public IActionResult DeleteMenuTable(int id)
        {
            var values = _menuTableService.TGetById(id);
            _menuTableService.TDelete(values);
            return Ok("Masa Başarılı Bir Şekilde Silinmiştir");
        }

        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            var values = _mapper.Map<MenuTable>(updateMenuTableDto);
            _menuTableService.TUpdate(values);
            return Ok("Masa Alanı Başarılı Bir Şekilde Güncellenmiştir");
        }

        [HttpGet("GetMenuTable")]
        public IActionResult GetMenuTable(int MenuTableId)
        {
            var values = _menuTableService.TGetById(MenuTableId);
            return Ok(values);
        }
    }
}
