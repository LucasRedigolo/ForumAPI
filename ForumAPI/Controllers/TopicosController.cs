using System.Collections.Generic;
using System.Linq;
using ForumAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumAPI.Controllers {
    public class TopicosController : Controller {
        Topicos topicos = new Topicos ();
        DAOTopicos dao = new DAOTopicos ();

        [HttpGet]
        [Route ("api/ShowTopicos")]
        public IEnumerable<Topicos> Get () {
            return dao.Listar ();
        }

        [HttpGet ("{ID}", Name = "TopicosAtual")]
        [Route ("api/ShowTopicos/{ID}")]
        public Topicos Get (int id) {
            return dao.Listar ().Where (x => x.ID == id).FirstOrDefault ();
        }

        [HttpPost]
        [Route ("api/AddTopicos")]
        public IActionResult Post ([FromBody] Topicos topicos) {
            dao.Cadastro (topicos);
            return CreatedAtRoute ("TopicosAtual", new { id = topicos.ID }, topicos);

        }
    }
}