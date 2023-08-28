using introducao_mvc.Model;
using introducao_mvc.View;

namespace introducao_mvc.Controller
{
    public class ProdutoController
    {
        Produto produto = new Produto();
        ProdutoView produtoView = new ProdutoView();

        //Método controlador para acessar a listagem de produtos
        public void ListarProdutos(){
            //Método Simplificado
            produtoView.Listar(produto.Ler());

            //Método completo
            // List<Produto> lista = produto.Ler();
            // produtoView.Listar(lista);
        }

        public void CadastrarProduto(){
            //Método Simplificado
            produto.Inserir(produtoView.InformarProduto());

            //Método Completo
            // Produto produtoInformado = produtoView.InformarProduto();
            // produto.Inserir(produtoInformado);
        }
    }
}