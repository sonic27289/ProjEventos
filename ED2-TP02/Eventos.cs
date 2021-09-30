using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ED2_TP02
{
    class Eventos
    {
        private Evento[] osEventos;

        internal Evento[] OsEventos { get => osEventos; }

        public Eventos()
        {
            osEventos = new Evento[7];
            for(int i = 0; i < 7; i++)
            {
                osEventos[i] = new Evento();
            }
        }
        public Eventos(Evento[] osEventos)
        {
            this.osEventos = osEventos;
        }

        public void adicionarEvento(Evento e, int day)
        {
            if (day >= 1 && day <= 7)
            {
                osEventos[day - 1] = e;
            }
            else
            {
                Console.WriteLine("Dia Inválido.\n Evento não Adicionado ! Desconsiderar mensagem abaixo.");
            }
        }
        
        public string pesquisarParticipante(Participante p)
        {
            string participanteNome = "";
            string participanteEventos = "";
            foreach(Evento evento in osEventos)
            {
                foreach(Participante participante in evento.Participantes)
                {
                    if(participante.Equals(p))
                    {
                        participanteEventos += $"Evento: {evento.Descricao}\n";
                        if(participante.Nome.Equals(""))
                        {
                            participanteNome = $"Nome: {participante.Nome}\n";
                        }
                    }
                }
            }
            return participanteNome + participanteEventos;
        }

        public string pesquisarEvento(int id)
        {
            string eventoString = "";
            foreach(Evento evento in osEventos)
            {
                if(evento.Id.Equals(id))
                {
                    eventoString = evento.ToString();
                    break;
                }
            }
            return eventoString;
        }
        
        public int qtdeParticipantes()
        {
            int qtd = 0;
            foreach(Evento evento in osEventos)
            {
                qtd += evento.qtdeParticipantes();
            }
            return qtd;
        }

        public string listaEventos()
        {
            string eventosStrg = "";
            foreach(Evento evento in osEventos)
            {
                if(!evento.Id.Equals(-1))
                {
                    eventosStrg += $"ID: {evento.Id}, Descrição: {evento.Descricao}, Quantidade de Participantes: {evento.qtdeParticipantes()}\n";
                }
            }
            return eventosStrg;
        }

        public int inscreverParticipante(int day, Participante p)
        {
            if (!p.podeInscrever(osEventos))
            {
                return 2;
            }

            if (osEventos[day - 1].qtdeParticipantes() >= osEventos[day - 1].QtdeMaxParticipantes)
            {
                return 1;
            }

            osEventos[day - 1].inscreverParticipante(p);
            return 0;
        }
    }
}
