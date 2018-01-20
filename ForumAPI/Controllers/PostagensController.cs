using System.Collections.Generic;
using System.Linq;
using ForumAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumAPI.Controllers {
    public class PostagensController : Controller {
        Postagens postagens = new Postagens ();
        DAOPostagens dao = new DAOPostagens ();

        [HttpGet]
        [Route ("api/ShowPostagens")]
        public IEnumerable<Postagens> Get () {
                return dao.Listar ();
            }
            [HttpGet ("{ID}", Name = "PostagemAtual")]
            [Route ("api/ShowPostagens/{ID}")]
        public Postagens Get (int id) {
            return dao.Listar ().Where (x => x.ID == id).FirstOrDefault ();
        }

        [HttpPost]
        [Route ("api/AddPostagens")]
        public IActionResult Post ([FromBody] Postagens postagens) {
            dao.Cadastro (postagens);
            return CreatedAtRoute ("PostagemAtual", new { id = postagens.ID }, postagens);

        }
    }
}