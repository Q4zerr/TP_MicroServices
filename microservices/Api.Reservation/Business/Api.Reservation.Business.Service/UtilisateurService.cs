
using Api.Reservation.Business.Models;
using Api.Reservation.Datas.Entities;
using Api.Reservation.Datas.Repository;
using Api.Reservation.Generals.Common;
using Refit;
using SQLitePCL;

namespace Api.Reservation.Business.Service
{
    public class UtilisateurService : IUtilisateurService
    {
        // TODO
        /// <summary>
        /// The reservation repository
        /// </summary>
        private readonly IReservationRepository _reservationRepository;

        /// <summary>
        /// The utilisateur repository
        /// </summary>
        private readonly IUtilisateurRepository _utilisateurRepository;

        /// <summary>
        /// The flights API
        /// </summary>
        private readonly IFlightsApi _flightsApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilisateurService"/> class.
        /// </summary>
        /// <param name="reservationRepository">The reservation repository.</param>
        /// <param name="utilisateurRepository">The utilisateur repository.</param>
        /// <param name="flightsApi">The flights API.</param>
        public UtilisateurService(IReservationRepository reservationRepository, IUtilisateurRepository utilisateurRepository, IFlightsApi flightsApi)
        {
            _reservationRepository = reservationRepository;
            _utilisateurRepository = utilisateurRepository;
            _flightsApi = flightsApi;
        }

        /// <summary>
        /// Cette méthode permet de faire un appel Http vers l'API des vols pour
        /// recupérer les informations d'un utilisateur
        /// </summary>
        /// <param name="email">L'email de l'utilisateur</param>
        /// <returns></returns>
        public async Task<Utilisateur> GetUtilisateurByEmailAsync(string email)
        {
            return await _utilisateurRepository.GetUtilisateurByEmailAsync(email)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Creer l'utilisateur de facon asynchrone
        /// </summary>
        /// <param name="utilisateur">L'utilisateur</param>
        /// <returns></returns>
        /// <exception cref="Api.Reservation.Generals.Common.BusinessException">Echec de création d'un utilisateur : L'utilisateur existe déjà</exception>
        public async Task<Datas.Entities.Utilisateur> CreateUtilisateurAsync(Datas.Entities.Utilisateur utilisateur)
        {
            var emailExist = await GetUtilisateurByEmailAsync(utilisateur.Email);

            if(emailExist != null)
            {
                throw new BusinessException("Echec de création d'un utilisateur : L'utilisateur existe déjà");
            }

            // L'utilisateur n'existe pas, procédez à la création
            return await _utilisateurRepository.CreateUtilisateurAsync(utilisateur)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de recupérer la liste des utilisateurs
        /// </summary>
        /// <returns></returns>
        public async Task <List<Datas.Entities.Utilisateur>> GetUtilisateursAsync()
        {
            return await _utilisateurRepository.GetUtilisateursAsync()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de recupérer l'utilisateur par son identifiant
        /// </summary>
        /// <param name="id">Identifiant utilisateur</param>
        /// <returns></returns>
        public async Task<Utilisateur> GetUtilisateurByIdAsync(int id)
        {
            return await _utilisateurRepository.GetUtilisateurByIdAsync(id)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de mettre à jour les informations de l'utilisateur
        /// </summary>
        /// <param name="utilisateur">L'utilisateur</param>
        /// <returns></returns>
        public async Task UpdateUtilisateur(Datas.Entities.Utilisateur utilisateur)
        {
             await _utilisateurRepository.UpdateUtilisateur(utilisateur)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de supprimer un utilisateur
        /// </summary>
        /// <param name="id">Identifiant utilisateur</param>
        /// <returns></returns>
        public async Task DeleteUtilisateurAsync(int id)
        {
            await _utilisateurRepository.DeleteUtilisateurAsync(id)
                .ConfigureAwait(false);
        }
    }
}
