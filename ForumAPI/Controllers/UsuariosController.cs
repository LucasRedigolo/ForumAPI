using System.Collections.Generic;
using System.Linq;
using ForumAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumAPI.Controllers {
    public class UsuariosController : Controller {
        Usuarios usuario = new Usuarios ();
        DAOUsuarios dao = new DAOUsuarios ();

        [HttpGet]
        [Route ("api/ShowUsuarios")]
        public IEnumerable<Usuarios> Get () {
                return dao.Listar ();
            }
        
        [HttpGet ("{ID}", Name = "UsuarioAtual")]
        [Route ("api/ShowUsuarios/{ID}")]
        public Usuarios Get (int id) {
             return dao.Listar ().Where (x => x.ID == id).FirstOrDefault ();
        }
        
        [HttpPost]
        [Route ("api/AddUsuarios")]
        public IActionResult Post ([FromBody] Usuarios usuarios) {
            dao.Cadastro (usuarios);
            return CreatedAtRoute ("UsuarioAtual", new { id = usuarios.ID }, usuarios);

        }
    }
}