
using Api.Reservation.Datas.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Reservation.Datas.Repository
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        // TODO
        /// <summary>
        /// The context
        /// </summary>
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UtilisateurRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UtilisateurRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Cette méthode permet de recupérer la liste des utilisateurs
        /// </summary>
        /// <returns></returns>
        public async Task<List<Entities.Utilisateur>> GetUtilisateursAsync()
        {
            return await _context.Utilisateurs
                .ToListAsync()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de recupérer l'utilisateur par son identifiant
        /// </summary>
        /// <param name="id">L'identifiant de l'utilisateur</param>
        /// <returns></returns>
        public async Task<Entities.Utilisateur> GetUtilisateurByIdAsync(int id)
        {
            return await _context.Utilisateurs
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync(u => u.Id == id)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette méthode permet de recupérer l'utilisateur par son email
        /// </summary>
        /// <param name="email">L'email de l'utilisateur</param>
        /// <returns></returns>
        public async Task<Entities.Utilisateur> GetUtilisateurByEmailAsync(string email)
        {
            return await _context.Utilisateurs
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync(u => u.Email == email)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Cette methode permet de créer un nouvelle utilisateur
        /// </summary>
        /// <param name="utilisateur">Les informations du nouvelle utilisateur</param>
        /// <returns></returns>
        public async Task<Entities.Utilisateur> CreateUtilisateurAsync(Entities.Utilisateur utilisateur)
        {
            await _context.Utilisateurs.AddAsync(utilisateur);
            await _context.SaveChangesAsync();
            return utilisateur;
        }

        /// <summary>
        /// Cette méthode permet de mettre à jour les informations de l'utilisateur
        /// </summary>
        /// <param name="utilisateur">les informations modifié d'un utilisateur</param>
        public async Task UpdateUtilisateur(Entities.Utilisateur utilisateur)
        {
            //_context.Utilisateurs.Update(utilisateur);
            //await _context.SaveChangesAsync();
            var existingEntity = await _context.Utilisateurs.FindAsync(utilisateur.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }
            _context.Utilisateurs.Update(utilisateur);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Cette méthode permet de supprimer un utilisateur
        /// </summary>
        /// <param name="id">Identifiant de l'utilisateur</param>
        public async Task DeleteUtilisateurAsync(int id)
        {
            var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if(utilisateur != null)
            {
                _context.Utilisateurs.Remove(utilisateur);
                await _context.SaveChangesAsync();
            }
        }
    }
}
