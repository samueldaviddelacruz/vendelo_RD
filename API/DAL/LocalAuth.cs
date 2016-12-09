using System;
using System.Threading.Tasks;
using API.Auth;
using API.Models;

namespace API.DAL
{
    public class LocalAuth
    {
        MongoDAL<Usuario> _mydal = new MongoDAL<Usuario>();

        public async Task RegisterUser(Usuario newUsuario)
        {
            var founduser = await FindUser(newUsuario.email);

            UserFoundHandler(founduser,() => {  throw new Exception("User already registered"); });

            newUsuario.password = Hashing.HashPassword(newUsuario.password);
            await _mydal.Insert(newUsuario);
        }

        private void UserFoundHandler(Usuario founduser,Action next)
        {
            if (founduser != null)
            {

                next();
            }
        }

        private async Task<Usuario> FindUser(string email)
        {
            Console.WriteLine(email);
            var founduser = await _mydal.FindByExpression(user => user.email == email);
            return founduser;
        }

        public async Task<bool> IsValidUser(string email,string password)
        {

            var founduser = await FindUser(email);
            var isValid = false;
            //Console.WriteLine(founduser.password);
            UserFoundHandler(founduser, () =>
            {
                isValid = Hashing.ValidatePassword(password, founduser.password);
            });
            return isValid;

        }


    }
}