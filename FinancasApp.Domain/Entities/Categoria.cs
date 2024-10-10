using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Entities
{
    /// <summary>
    /// Modelo de entidade para categoria
    /// </summary>
    public class Categoria
    {
        #region Propriedades

        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public Guid? UsuarioId { get; set; }

        #endregion

        #region Relacionamentos

        public Usuario? Usuario { get; set; }
        public List<Conta>? Contas { get; set; }

        #endregion

    }
}
