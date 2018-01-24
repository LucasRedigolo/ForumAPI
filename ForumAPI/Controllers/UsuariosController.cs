using System;
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
            JsonResult rs;
            try
            {   
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }//IF para validar os data annotations

                rs = new JsonResult(dao.Cadastro(usuario));
                rs.ContentType = "aplication/json";
                if (!Convert.ToBoolean(rs.Value))
                {
                    rs.StatusCode = 404;
                    rs.Value = "OCORREU UM ERRO! TENTE NOVAMENTE";
                }
                else
                {
                    rs.StatusCode = 200;
                }

            }
            catch (System.Exception ex)
            {
                
                rs = new JsonResult("");
                rs.StatusCode = 204;
                rs.ContentType = "application/json";
                rs.Value = ex.Message;
            }
            return Json(rs);
        }
    }
}