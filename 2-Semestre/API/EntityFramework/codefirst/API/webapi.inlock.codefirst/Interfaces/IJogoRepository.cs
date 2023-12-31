﻿using webapi.inlock.codefirst.Domains;

namespace webapi.inlock.codefirst.Interfaces
{
    /// <summary>
    /// Interface que contem os métodos da entidade Jogo
    /// </summary>
    public interface IJogoRepository
    {
        //método que cadastra um novo jogo
        void CadastrarJogo(Jogo novoJogo);

        //método que lista todos os jogos
        List<Jogo> ListarJogos();

        //método que busca um jogo por seu id
        Jogo BuscarJogoPorId(Guid id);

        //método para atualizar um jogo pelo id
        void AtualizarJogoPorId(Guid id, Jogo jogoAtualizado);

        //método para deletar um jogo pelo seu id
        void DeletarJogoPorId(Guid id);
    }
}
