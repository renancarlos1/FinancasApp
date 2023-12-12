using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Helpers;
using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Services
{
    /// <summary>
    /// Classe para implementar serviços de domínios de usuários
    /// </summary>
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly IUsuarioRepository? _usuarioRepository;

        public UsuarioDomainService(IUsuarioRepository? usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void CriarUsuario(Usuario usuario)
        {
            //verificar se já existe um usuário cadastrado com o email informado
            if (_usuarioRepository?.Get(usuario.Email) != null)
              throw new ApplicationException("O email informado já está cadastrado. Por favor verifique.");

            //gerando um id para o usuário
            usuario.Id = Guid.NewGuid();
            usuario.DataHoraCriacao = DateTime.Now;

            //criptografando a senha do usuário
            usuario.Senha = SHA1CryptoHelper.Encrypt(usuario.Senha);
            
            _usuarioRepository?.Add(usuario);
        }

        public Usuario Obter(string email, string senha)
        {
            //verificar se já existe um usuário cadastrado com o email informado
            //if (_usuarioRepository?.Get(email) == null)
            //    throw new ApplicationException("O email informado não está cadastrado. Por favor verifique.");

            //consultando o usuário no banco de dados através do email e da senha
            var usuario = _usuarioRepository?.Get(email, SHA1CryptoHelper.Encrypt(senha));

            //verificando se o usuário não foi encontrado
            if (usuario == null)
                throw new ApplicationException("Usuário inválido.");

            return usuario;

        }
    }
}
