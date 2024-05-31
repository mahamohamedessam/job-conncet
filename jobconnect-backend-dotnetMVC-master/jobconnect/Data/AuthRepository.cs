using jobconnect.Data;
using jobconnect.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace jobconnect.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _db;

        public AuthRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _db.User.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _db.User.AddAsync(user);
            await _db.SaveChangesAsync();

            return user;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExist(string email)
        {
            return await _db.User.AnyAsync(x => x.Email == email);
        }
    }
}

