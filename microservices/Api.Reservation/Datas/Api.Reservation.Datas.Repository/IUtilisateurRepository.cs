
namespace Api.Reservation.Datas.Repository
{
    public interface IUtilisateurRepository
    {
        // TODO

        /// <summary>
        /// Cette méthode permet de recupérer la liste des reservations
        /// </summary>
        /// <returns></returns>
        Task<List<Entities.Utilisateur>> GetUtilisateursAsync();
        
        /// <summary>
        /// Cette méthode permet de recupérer l'utilisateur par son identifiant
        /// </summary>
        /// <param name="id">L'id de l'utilisateur</param>
        /// <returns></returns>
        Task<Entities.Utilisateur> GetUtilisateurByIdAsync(int id);


        /// <summary>
        /// Cette méthode permet de recupérer l'utilisateur par son email
        /// </summary>
        /// <param name="email">L'email de l'utilisateur</param>
        /// <returns></returns>
        Task<Entities.Utilisateur> GetUtilisateurByEmailAsync(string email);


        /// <summary>
        /// Cette méthode permet de créer un nouvelle utilisateur
        /// </summary>
        /// <param name="utilisateur">Les informations du nouvelle utilisateur</param>
        /// <returns></returns>
        Task<Entities.Utilisateur> CreateUtilisateurAsync(Entities.Utilisateur utilisateur);


        /// <summary>
        /// Cette méthode permet de mettre à jour les informations d'un utilisateur
        /// </summary>
        /// <param name="utilisateur">Les informations modifié de l'utilisateur</param>
        /// <returns></returns>
        Task UpdateUtilisateur(Entities.Utilisateur utilisateur);


        /// <summary>
        /// Cette méthode permet de supprimer un utilisateur
        /// </summary>
        /// <param name="id">L'identifiant de l'utilisateur</param>
        /// <returns></returns>
        Task DeleteUtilisateurAsync(int id);


    }
}
