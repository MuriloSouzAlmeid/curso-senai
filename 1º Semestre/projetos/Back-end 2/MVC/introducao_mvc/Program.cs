using introducao_mvc.Model;
using introducao_mvc.Controller;

Produto p = new Produto();
ProdutoController produto = new ProdutoController();

Console.Clear();

produto.CadastrarProduto();

produto.ListarProdutos();