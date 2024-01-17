using Api.Reservation.Datas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Reservation.Business.Service
{
    public interface IUtilisateurService
    {
        // TODO
        /// <summary>
        /// Cette méthode permet de faire un appel Http vers l'API des vols pour
        /// recupérer les informations d'un utilisateur
        /// </summary>
        /// <param name="email">L'email de l'utilisateur</param>
        /// <returns></returns>
        Task<Utilisateur> GetUtilisateurByEmailAsync(string email);

        /// <summary>
        /// Creer l'utilisateur de facon asynchrone
        /// </summary>
        /// <param name="utilisateur">L'utilisateur</param>
        /// <returns></returns>
        /// <exception cref="Api.Reservation.Generals.Common.BusinessException">Echec de création d'un utilisateur : L'utilisateur existe déjà</exception>
        Task<Datas.Entities.Utilisateur> CreateUtilisateurAsync(Datas.Entities.Utilisateur utilisateur);

        /// <summary>
        /// Cette méthode permet de mettre à jour les informations de l'utilisateur
        /// </summary>
        /// <param name="utilisateur">L'utilisateur</param>
        /// <returns></returns>
        Task UpdateUtilisateur(Datas.Entities.Utilisateur utilisateur);

        /// <summary>
        /// Cette méthode permet de supprimer un utilisateur
        /// </summary>
        /// <param name="id">Identifiant utilisateur</param>
        /// <returns></returns>
        Task DeleteUtilisateurAsync(int id);

        /// <summary>
        /// Cette méthode permet de recupérer la liste des utilisateurs
        /// </summary>
        /// <returns></returns>
        Task<List<Datas.Entities.Utilisateur>> GetUtilisateursAsync();

        /// <summary>
        /// Cette méthode permet de recupérer l'utilisateur par son identifiant
        /// </summary>
        /// <param name="id">Identifiant utilisateur</param>
        /// <returns></returns>
        Task<Datas.Entities.Utilisateur> GetUtilisateurByIdAsync(int id);
    }
}
