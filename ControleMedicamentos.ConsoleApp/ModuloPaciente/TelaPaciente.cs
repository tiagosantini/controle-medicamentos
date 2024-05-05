﻿using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    internal class TelaPaciente : TelaBase
    {
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Pacientes...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -15}",
                "Id", "Nome", "Telefone", "Cartão do SUS"
            );

            EntidadeBase[] pacientesCadastrados = repositorio.SelecionarTodos();

            foreach (Funcionario paciente in pacientesCadastrados)
            {
                if (paciente == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -15}",
                    paciente.Id, paciente.Nome, paciente.Telefone, paciente.CartaoSus
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome do paciente: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o telefone do paciente: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o cartão do SUS do paciente: ");
            string cartaoSus = Console.ReadLine();

            Funcionario novoPaciente = new Funcionario(nome, telefone, cartaoSus);

            return novoPaciente;
        }

        public void CadastrarEntidadeTeste()
        {
            Funcionario paciente = new Funcionario("Bobby Tables", "49 9999-9521", "12321313122");

            repositorio.Cadastrar(paciente);
        }
    }
}
