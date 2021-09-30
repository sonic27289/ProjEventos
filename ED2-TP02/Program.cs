using System;

namespace ED2_TP02
{
    class Program
    {
        static void Main(string[] args)
        {
            bool sair = false;
            int opcao;

            Eventos eventos = new Eventos();

            while(!sair)
            {
               Console.WriteLine(" 0 - Sair\n 1 - Adicionar evento\n 2 - Pesquisar Evento\n 3 - Listar Eventos\n 4 - Adicionar Participante\n 5 - Pesquisar Participante\n 6 - Informar quantidade total de Participantes nos eventos da semana\n");
               opcao = int.Parse(Console.ReadLine());


               switch(opcao)
                {
                    case 0:
                        sair = true;
                        break;
                    case 1:
                        adicionarEvento(eventos);
                        break;
                    case 2:
                        pesquisarEvento(eventos);
                        break;
                    case 3:
                        listarEvento(eventos);
                        break;
                    case 4:
                        adicionarParticipante(eventos);
                        break;
                    case 5:
                        pesquisarParticipante(eventos);
                        break;
                    case 6:
                        informarParticipantes(eventos);
                        break;
                    default:
                        Console.WriteLine("Opção Inválida !");
                        break;
                }

                void adicionarEvento(Eventos eventos)
                {
                    Console.WriteLine("Digite o Dia do Evento: (1 = Segunda, 2 = Terça, ..., 7 = Domingo)");
                    int day = int.Parse(Console.ReadLine());

                    Console.WriteLine("ID do Evento: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Descrição do Evento: ");
                    string descricao = Console.ReadLine();

                    Console.WriteLine("Quantidade Máxima de Participantes: ");
                    int qtdMax = int.Parse(Console.ReadLine());

                    eventos.adicionarEvento(new Evento(id, descricao, qtdMax), day);
                    Console.WriteLine("Evento Adicionado !");
                }

                void pesquisarEvento(Eventos eventos)
                {
                    Console.WriteLine("Digite o ID do evento que você quer pesquisar: ");
                    int id = int.Parse(Console.ReadLine());

                    string idDoEvento = eventos.pesquisarEvento(id);
                    if (idDoEvento.Equals(""))
                    {
                        Console.WriteLine("Não foi possível encontrar o Evento !");
                    }
                    else
                    {
                        Console.WriteLine(idDoEvento);
                    }
                }

                void listarEvento(Eventos eventos)
                {
                    string idDoEvento = eventos.listaEventos();

                    if (idDoEvento.Equals(""))
                    {
                        Console.WriteLine("Nenhum Evento registrado. ");
                    }
                    else
                    {
                        Console.WriteLine(idDoEvento);
                    }
                }

                void adicionarParticipante(Eventos eventos)
                {
                    Console.WriteLine("Digite o Dia do Evento: (1 = Segunda, 2 = Terça, ..., 7 = Domingo) ");
                    int day = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o email do participante: ");
                    string email = Console.ReadLine();

                    Console.WriteLine("Digite o nome do participante: ");
                    string nome = Console.ReadLine();

                    switch (eventos.inscreverParticipante(day, new Participante(email, nome)))
                    {
                        case 0:
                            Console.WriteLine("Inscrição Registrada !");
                            break;
                        case 1:
                            Console.WriteLine("Evento Lotado !");
                            break;
                        case 2:
                            Console.WriteLine("Máximo de Inscrições permitida para o Participante ultrapassada !");
                            break;
                    }
                }

                void pesquisarParticipante(Eventos eventos)
                {
                    Console.WriteLine("Informe o e-mail do participante para efetuar a pesquisa: ");
                    string email = Console.ReadLine();

                    string dadosParticipante = eventos.pesquisarParticipante(new Participante(email, " "));
                    if (dadosParticipante.Equals(""))
                    {
                        Console.WriteLine("Participante não cadastrado !");
                    }
                    else
                    {
                        Console.WriteLine(dadosParticipante);
                    }
                }

                void informarParticipantes(Eventos eventos)
                {
                    Console.WriteLine($"Total de Participantes: {eventos.qtdeParticipantes()}");
                }
            }
        }
    }
}
