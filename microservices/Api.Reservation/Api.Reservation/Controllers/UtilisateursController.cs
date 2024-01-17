using Api.Reservation.Business.Models;
using Api.Reservation.Business.Service;
using Api.Reservation.Datas.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        // TODO
        /// <summary>
        /// The utilisateur service
        /// </summary>
        private readonly IUtilisateurService _utilisateurService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilisateursController"/> class.
        /// </summary>
        /// <param name="utilisateurService">The utilisateur service.</param>
        public UtilisateursController(IUtilisateurService utilisateurService)
        {
            _utilisateurService = utilisateurService;
        }

        // GET: api/Utilisateurs
        [HttpGet]
        [ProducesResponseType(typeof(List<Datas.Entities.Utilisateur>), 200)]
        public async Task<IActionResult> GetUtilisateursAsync()
        {
            return Ok(await _utilisateurService.GetUtilisateursAsync());
        }

        //// GET api/<UtilisateursController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<Datas.Entities.Utilisateur>), 200)]
        public async Task<IActionResult> GetUtilisateurByIdAsync(int id)
        {
            return Ok(await _utilisateurService.GetUtilisateurByIdAsync(id));
        }

        // GET api/<UtilisateursController>/avet.tanguy38@gmail.com
        //[HttpGet]
        //[ProducesResponseType(typeof(List<Datas.Entities.Utilisateur>), 200)]
        //public async Task<IActionResult> GetUtilisateurByEmailAsync(string email)
        //{
        //    return Ok(await _utilisateurService.GetUtilisateurByEmailAsync(email));
        //}

        // POST api/<UtilisateursController>
        [HttpPost]
        [ProducesResponseType(typeof(List<Datas.Entities.Utilisateur>), 200)]
        public async Task<IActionResult> CreateUtilisateurAsync([FromBody] CreateUtilisateurDto utilisateur)
        {
            try
            {
                var utilisateurToCreate = new Datas.Entities.Utilisateur()
                {
                    Nom = utilisateur.Nom,
                    Prenom = utilisateur.Prenom,
                    Email = utilisateur.Email,
                    DateNaissance = utilisateur.DateNaissance,
                };

                return Ok(await _utilisateurService.CreateUtilisateurAsync(utilisateurToCreate));
            }
            catch (Exception e) { return Problem(e.Message, e.StackTrace); }
        }

        // PUT api/<UtilisateursController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(List<Datas.Entities.Utilisateur>), 200)]
        public async Task<IActionResult> UpdateUtilisateur(int id, [FromBody] Utilisateur utilisateur)
        {
            var checkUtilisateur = _utilisateurService.GetUtilisateurByIdAsync(id);

            if(checkUtilisateur != null)
            {
                return Ok(_utilisateurService.UpdateUtilisateur(utilisateur));
            }

            return NotFound();
        }

        // DELETE api/<UtilisateursController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        // DELETE api/<UtilisateursController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(List<Datas.Entities.Utilisateur>), 200)]
        public async Task<IActionResult> DeleteUtilisateurAsync(int id)
        {
            var checkUtilisateur = _utilisateurService.GetUtilisateurByIdAsync(id);

            if(checkUtilisateur != null)
            {
                return Ok(_utilisateurService.DeleteUtilisateurAsync(id));
            }

            return NotFound();
        }
    }
}
