using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Aula03Colecoes.Models;
using Aula03Colecoes.Models.Enuns;
using System.Linq;

namespace Aula03Colecoes
{
    public class Program
    {
        static List<Funcionario> lista = new List<Funcionario>();


        static void Main(string[] args)
        //Ativa os métodos do programa
        {
            CriarLista();
            ObterPorTipo();
            ValidarNome();
            ValidarSalarioAdmissao();
            ObterEstatistica();
            ObterFuncionarioRecente();
            ObterNome();//
            AdicionarFuncionario();//
        }

        public static void ObterPorTipo()
        {
            System.Console.WriteLine("Digite o tipo de funcionário: 1-CLT, 2-Aprendiz");
            int Escolha = int.Parse(Console.ReadLine());
            var tipoEscolhido = (TipoFuncionarioEnum)Escolha;
            var tipoFuncionario = lista.FindAll(f => f.TipoFuncionario == tipoEscolhido);

            string dados = "";
            foreach (var funcionario in tipoFuncionario)
            dados += string.Format("Nome: {0} | Tipo: {1}\n", funcionario.Nome, funcionario.TipoFuncionario);

            System.Console.WriteLine(dados);
        }

        public static void ValidarNome()
        //Método que valida nomes com mais de 2 caracteres
        {
            System.Console.WriteLine("Digite o nome: ");
            string nome = Console.ReadLine();

            if (nome.Length < 2)
            {
                System.Console.WriteLine("Nome incompleto");
                return;
            }
        }

        public static void ValidarSalarioAdmissao()
        //Método que define e valida o salario do funcionario cadastrado e permite apenas com condições especificas
        {

            System.Console.WriteLine("Registre o funcionario: ");
            System.Console.Write("Digite nome: ");
            string Nome = Console.ReadLine();

            System.Console.Write("Digite o salário: ");
            double Salario = double.Parse(System.Console.ReadLine());
            if (Salario < 1)
            {
                System.Console.WriteLine("Nao é possivel cadastrar um funcionario sem salario!");
                return;
            }

            System.Console.Write("Digite a data de admissão: ");
            DateTime DataAdmissao = DateTime.Parse(System.Console.ReadLine());
            if (DataAdmissao != DateTime.Today)
            {
                System.Console.WriteLine("Nao é possivel cadastrar o funcionario");
                return;
            }

            System.Console.Write("Digite o CPF: ");
            string Cpf = Console.ReadLine();

        }

        public static void ObterEstatistica()
        {
            int totalIds = lista.Count;
            System.Console.WriteLine($"Total de IDs na lista: {totalIds}");
            decimal somaSalario = lista.Sum(f => f.Salario);
            System.Console.WriteLine($"Soma dos salarios: {somaSalario}");
        }

        public static void ObterFuncionarioRecente()
        //Método que busca na lista os funcionarios recentemente cadastrados
        {

            var funcionariosRecentes = lista.FindAll(f => f.Id >= 4);

            if (funcionariosRecentes.Count == 0)
            {
                System.Console.WriteLine("Nenhum funcionário encontrado com ID 4 ou superior.");
                return;
            }
            string dados = "";
            foreach (var funcionario in funcionariosRecentes)
            {
                dados += "=======================================\n";
                dados += string.Format("Id: {0} \n", funcionario.Id);
                dados += string.Format("Nome: {0} \n", funcionario.Nome);
                dados += string.Format("CPF: {0} \n", funcionario.Cpf);
                dados += string.Format("Admissao: {0:dd/MM/yyyy} \n", funcionario.DataAdmissao);
                dados += string.Format("Salario: {0:c2} \n", funcionario.Salario);
                dados += string.Format("Tipo: {0} \n", funcionario.TipoFuncionario);
                dados += "=======================================\n";
            }
            System.Console.WriteLine(dados);

        }

        public static void MenuOpcoes()
        //Método que mostra um Menu e acha outros métodos a partir da seleção
        {
            System.Console.WriteLine("Escolha qual opção você quer acessar!");
            System.Console.WriteLine("=====================================");
            System.Console.WriteLine("{1} Obter Nome & Informações do Usuario");
            System.Console.WriteLine("{2} Funcionarios Recentes");
            System.Console.WriteLine("{3} Obter Estatisticas");
            System.Console.WriteLine("{4} Tipo Funcionario");
            System.Console.WriteLine("=====================================");
        }

        public static void ObterNome()
        {
            System.Console.WriteLine("Digite o nome do Funcionario: ");
            string Nome = Console.ReadLine();
            Funcionario fBusca = lista.Find(x => x.Nome == Nome);

            if (fBusca == null) 
            {
                System.Console.WriteLine("Funcionario não encontrado.");
                return;
            }
            else
            {
                System.Console.WriteLine($"Funcionario Encontrado!");
                System.Console.WriteLine($"Informações de: {fBusca.Nome} ");
                System.Console.WriteLine($"O Cpf é: {fBusca.Cpf}");
                System.Console.WriteLine($"A data de Admissao é: {fBusca.DataAdmissao}");
                System.Console.WriteLine($"O Id é: {fBusca.Id}");
                System.Console.WriteLine($"O Salario é:  {fBusca.Salario}");
                System.Console.WriteLine($"Ele é  {fBusca.TipoFuncionario}");
            }
        }

        public static void ObterPorSalario()
        {
            System.Console.Write("Digite o valor minimo: ");
            decimal salario = decimal.Parse(System.Console.ReadLine());
            lista = lista.FindAll(x => x.Salario >= salario);
            ExibirLista();
        }

        public static void ObterPorIdDigitado()
        //Método que permite a busca pelo Id digitado e verifica se o Id existe
        {
            System.Console.Write("Digite o ID: ");
            int id = int.Parse(Console.ReadLine());
            Funcionario fBusca = lista.Find(x => x.Id == id);

            if (fBusca == null)
            {
                System.Console.WriteLine("nao encontrado");
            }
            else
            {
                System.Console.WriteLine($"Funcionario encontrado: {fBusca.Nome}");
            }
        }

        public static void ObterPorId()
        //Método que permite a pesquisa a partir do objeto Id na lista
        {
            lista = lista.FindAll(x => x.Id == 1);
            ExibirLista();
        }

        public static void AdicionarFuncionario()
        //Método que permite o registro de um novo funcionário a partir dos objetos da classe, e caso algum requisito não seja preenchido retorna uma mensagem de erro
        {
            Funcionario f = new Funcionario();

            System.Console.Write("Digite nome: ");
            f.Nome = Console.ReadLine();

            System.Console.Write("Digite o salário: ");
            f.Salario = decimal.Parse(System.Console.ReadLine());

            System.Console.Write("Digite a data de admissão: ");
            f.DataAdmissao = DateTime.Parse(System.Console.ReadLine());

            System.Console.Write("Digite o CPF: ");
            f.Cpf = Console.ReadLine();

            if (string.IsNullOrEmpty(f.Nome))
            {
                System.Console.WriteLine("O nome deve ser preenchido");
                return;
            }
            else if (f.Salario == 0)
            {
                System.Console.WriteLine("Valor do salario nao pode ser 0");
                return;
            }
            else if (f.ValidarCpf() == false)
            {
                System.Console.WriteLine("CPF invalido");
                return;
            }
            else
            {
                lista.Add(f);
                ExibirLista();
            }
        }

        public static void ExibirLista()
        //Método que organiza e exibe a lista de funcionários, a partir dos objetos da classe
        {
            string dados = "";
            for (int i = 0; i < lista.Count; i++)
            {
                dados += "=======================================\n";
                dados += string.Format("Id: {0} \n", lista[i].Id);
                dados += string.Format("Nome: {0} \n", lista[i].Nome);
                dados += string.Format("CPF: {0} \n", lista[i].Cpf);
                dados += string.Format("Admissao: {0:dd/MM/yyyy} \n", lista[i].DataAdmissao);
                dados += string.Format("Salario: {0:c2} \n", lista[i].Salario);
                dados += string.Format("Tipo: {0} \n", lista[i].TipoFuncionario);
                dados += "=======================================\n";
            }
            System.Console.WriteLine(dados);
        }

        public static void CriarLista()
        //Método que cria a lista de funcionários
        {
            Funcionario f1 = new Funcionario();
            f1.Id = 1;
            f1.Nome = "Neymar";
            f1.Cpf = "12345678910";
            f1.DataAdmissao = DateTime.Parse("01/01/2000");
            f1.Salario = 100.000M;
            f1.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f1);

            Funcionario f2 = new Funcionario();
            f2.Id = 2;
            f2.Nome = "Cristiano Ronaldo";
            f2.Cpf = "01987654321";
            f2.DataAdmissao = DateTime.Parse("30/06/2002");
            f2.Salario = 150.000M;
            f2.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f2);

            Funcionario f3 = new Funcionario();
            f3.Id = 3;
            f3.Nome = "Messi";
            f3.Cpf = "135792468";
            f3.DataAdmissao = DateTime.Parse("01/11/2003");
            f3.Salario = 70.000M;
            f3.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f3);

            Funcionario f4 = new Funcionario();
            f4.Id = 4;
            f4.Nome = "Mbappe";
            f4.Cpf = "246813579";
            f4.DataAdmissao = DateTime.Parse("15/09/2005");
            f4.Salario = 80.000M;
            f4.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f4);

            Funcionario f5 = new Funcionario();
            f5.Id = 5;
            f5.Nome = "Lewa";
            f5.Cpf = "246813579";
            f5.DataAdmissao = DateTime.Parse("20/10/1998");
            f5.Salario = 90.000M;
            f5.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f5);

            Funcionario f6 = new Funcionario();
            f6.Id = 6;
            f6.Nome = "Roger Guedes";
            f6.Cpf = "246813579";
            f6.DataAdmissao = DateTime.Parse("13/12/1997");
            f6.Salario = 300.000M;
            f6.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f6);
        }

    }
}

