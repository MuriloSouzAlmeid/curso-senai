using System.Globalization;
using System;

namespace Projeto_loja_virtual
{
    public class Boleto : Pagamento
    {
        //Propriedades
        Random CodigoDeBarras = new Random();

        //Métodos
        private string CodigoBarras()
        {
            //Código de barras
            return $"0339{CodigoDeBarras.Next(9).ToString()}.{CodigoDeBarras.Next(9000).ToString()}5 {CodigoDeBarras.Next(90000).ToString()}.{CodigoDeBarras.Next(9000).ToString()}5 {CodigoDeBarras.Next(90000).ToString()}.{CodigoDeBarras.Next(9000).ToString()}5 {CodigoDeBarras.Next(9).ToString()} {CodigoDeBarras.Next(90000).ToString()}.{CodigoDeBarras.Next(90000).ToString()}";
        }


        public void Registrar()
        {
            this.ValorFinal = this.ValorInicial * 0.88f;

            Console.WriteLine($"\n");
            Console.WriteLine($"Compras efetuadas no boleto têm 12% de desconto!!");

            Console.WriteLine(@$"
            ____________________________________________________________________________
            
            Beneficiário: Projeto Loja Virtual
            Valor do boleto: {this.ValorFinal:C2}
            Código de barras: {CodigoBarras()}
            ____________________________________________________________________________
            ");
        }
    }
}