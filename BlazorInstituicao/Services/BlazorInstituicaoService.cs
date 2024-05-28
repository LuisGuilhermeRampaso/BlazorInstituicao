using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorInstituicao.Models;

namespace BlazorInstituicao.Services
{
    public class BlazorInstituicaoService
    {
        private static IList<Instituicao> instituicoes = new List<Instituicao>()
        {
            new Instituicao { InstituicaoID = 1, Nome = "Instituicao 1", Endereco = "Endereco 1" },
            new Instituicao { InstituicaoID = 2, Nome = "Instituicao 2", Endereco = "Endereco 2" },
            new Instituicao { InstituicaoID = 3, Nome = "Instituicao 3", Endereco = "Endereco 3" }
        };

        public Task<IEnumerable<Instituicao>> GetInstituicoesAsync()
        {
            return Task.FromResult<IEnumerable<Instituicao>>(instituicoes);
        }

        public Task<Instituicao> GetInstituicaoAsync(string id)
        {
            if (!int.TryParse(id, out int instituicaoID))
            {
                throw new ArgumentException("ID da instituição inválido.", nameof(id));
            }

            var instituicao = instituicoes.FirstOrDefault(i => i.InstituicaoID == instituicaoID);
            return Task.FromResult(instituicao);
        }

        public Task CreateInstituicaoAsync(Instituicao instituicao)
        {
            if (instituicao == null)
            {
                throw new ArgumentNullException(nameof(instituicao));
            }

            if (instituicao.InstituicaoID != 0 || instituicoes.Any(i => i.InstituicaoID == instituicao.InstituicaoID))
            {
                throw new InvalidOperationException("ID da instituição já existe ou não é permitido.");
            }

            instituicao.InstituicaoID = instituicoes.Max(i => i.InstituicaoID) + 1;
            instituicoes.Add(instituicao);
            return Task.CompletedTask;
        }

        public Task UpdateInstituicaoAsync(Instituicao instituicao)
        {
            if (instituicao == null)
            {
                throw new ArgumentNullException(nameof(instituicao));
            }

            var existingInstituicao = instituicoes.FirstOrDefault(i => i.InstituicaoID == instituicao.InstituicaoID);
            if (existingInstituicao == null)
            {
                throw new InvalidOperationException("Instituição não encontrada.");
            }

            existingInstituicao.Nome = instituicao.Nome;
            existingInstituicao.Endereco = instituicao.Endereco;
            return Task.CompletedTask;
        }

        public Task DeleteInstituicaoAsync(int id)
        {
            var instituicao = instituicoes.FirstOrDefault(i => i.InstituicaoID == id);
            if (instituicao != null)
            {
                instituicoes.Remove(instituicao);
            }
            return Task.CompletedTask;
        }
    }
}
