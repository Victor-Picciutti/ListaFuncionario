using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula03Colecoes.Models.Enuns;

//um comentario qualquer pra deixar no git

namespace Aula03Colecoes.Models
{
    public class Funcionario
    {
        public int Id { get; set; }//prop é o atalho
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataAdmissao { get; set; }
        public decimal Salario { get; set; }
        public TipoFuncionarioEnum TipoFuncionario { get; set; }
        

        public void ReajustarSalario()
        {
            Salario = Salario + (Salario * 10/100);
        }
        
        public string ExibirPeriodoExperiencia()
        {
            string periodoExperiencia = string.Format("Periodo de Experiencia: {0} ate {1}", DataAdmissao, DataAdmissao.AddMonths(3));
            return periodoExperiencia;
        }

        public decimal CalcularDecontoVT(Decimal percentual)
        {
            decimal desconto = this.Salario * percentual/100;
            return desconto;
        }

        private int ContarCaracteres(string dado)
        {
            return dado.Length;
        }
        public bool ValidarCpf()
        {
            if(ContarCaracteres(Cpf) == 11)
                return true;
            else
                return false;
        }
    }
}