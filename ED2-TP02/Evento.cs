using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ED2_TP02
{
    class Evento
    {
        private int id;
        private string descricao;
        private int qtdeMaxParticipantes;
        private Participante[] participantes;

        

        public Evento(int id, string descricao, int qtdeMaxParticipantes)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.QtdeMaxParticipantes = qtdeMaxParticipantes;
            this.Participantes = new Participante[this.QtdeMaxParticipantes];

            for(int i = 0; i < this.QtdeMaxParticipantes; i++)
            {
                this.Participantes[i] = new Participante();
            }
        }

        public Evento()
            :this(-1, " ", 1)
        {
        }

        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public int QtdeMaxParticipantes { get => qtdeMaxParticipantes; set => qtdeMaxParticipantes = value; }
        internal Participante[] Participantes { get => participantes; set => participantes = value; }

        public void inscreverParticipante(Participante p)
        {
            for(int i = 0; i < participantes.Length; i++)
            {
                if(participantes[i].Email.Equals(" "))
                {
                    participantes[i] = p;
                    break;
                }
            }
        }

        public int qtdeParticipantes()
        {
            int qtd = 0;
            foreach(Participante participante in participantes)
            {
                if(!participante.Email.Equals(" "))
                {
                    qtd++;
                }
            }
            return qtd;
        }
        
        public string listaParticipantes()
        {
            string participantesStrg = "";
            foreach(Participante participante in participantes)
            {
                if(!participante.Email.Equals(" "))
                {
                    participantesStrg += $"Nome: {participante.Nome}, Email: {participante.Email}";
                }
            }
            return participantesStrg;
        }

        public override bool Equals(object obj)
        {
            return obj is Evento evento &&
                id.Equals(evento.id);        
        }

        public override string ToString()
        {
            return $"Id: {id}, Descrição: {descricao}, Máximo de Participantes: {qtdeMaxParticipantes}, Participantes: [{listaParticipantes()}]\n";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, descricao, qtdeMaxParticipantes, participantes, Id, Descricao, QtdeMaxParticipantes, Participantes);
        }
    }
}
