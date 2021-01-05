using EFC4RESTAPI.Controllers.Super;
using EFC4RESTAPI.Dtos;
using EFC4RESTAPI.Models;
using EFC4RESTAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFC4RESTAPI.Controllers
{
    [ApiController]
    [Route("/[Controller]")]
    public class PermissonController : SuperController<Permission, Permission, UngetPermission>
    {
        public PermissonController(IDBContext dBContext) : base(dBContext) { }
    }
}