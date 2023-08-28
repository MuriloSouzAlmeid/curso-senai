using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_produto_interface
{
    public interface ICarrinho
    {
        //Regras de "Contrato" (métodos que serão obrigatórios a serem implementados na casse que referenciar essa interface)
        // Métodos apenas declarados e sem assinatura
        // CRUD

        // Create
        void AdicionarProduto(Produto _produto);

        // Read
        void ListarProdutos();

        // Update
        void AtualizarProduto(int _codigo);

        // Delete
        void DeletarProduto(int _codigo);

    }
}