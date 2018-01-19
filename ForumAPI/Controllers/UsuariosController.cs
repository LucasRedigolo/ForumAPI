using System.Collections.Generic;
using ForumAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumAPI.Controllers {
    public class UsuariosController : Controller {
        Usuarios usuario = new Usuarios ();
        DAOUsuarios dao = new DAOUsuarios ();
        
        [HttpGet]
        [Route ("api/GetAll")]
        public IEnumerable<Usuarios> Get () {
            return dao.Listar ();
        }
    }
}