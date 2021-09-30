using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;


namespace ED2_TP02
{
    class Participante
    {
        private string email;
        private string nome;

        public Participante(string email, string nome)
        {
            this.email = email;
            this.nome = nome;
        }
        public Participante()
            : this(" ", " ")
        {
        }

        public string Email
        {
            get => email; set => email = value;
        }

        public string Nome
        {
            get => nome; set => nome = value;
        }

        public bool podeInscrever(Evento[] e)
        {
            int eventoParticipantes = 0;

            foreach(Evento evento in e)
            {
                foreach(Participante participante in evento.Participantes)
                {
                    if(this.Equals(participante))
                    {
                        eventoParticipantes++;
                    }
                }
            }
            return eventoParticipantes < 2 ? true : false;
        }

        public override bool Equals(object obj)
        {
            return obj is Participante participante &&
                email.Equals(participante.email);
        }

        public override string ToString()
        {
            return $"Nome: {nome}, Email: {email}\n";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(email, nome, Email, Nome);
        }
    }
}
