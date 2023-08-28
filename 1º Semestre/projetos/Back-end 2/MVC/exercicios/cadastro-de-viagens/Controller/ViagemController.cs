using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cadastro_de_viagens.Model;
using cadastro_de_viagens.View;

namespace cadastro_de_viagens.Controller
{
    public class ViagemController
    {
        ViagemModel viagemModel = new ViagemModel();
        ViagemView viagemView = new ViagemView();
        public void ListarEventos(){
            viagemView.Listar(viagemModel.GerarListaViagens());
        }

        public void CadastrarEvento(){
            viagemModel.AdicionarAoCsv(viagemView.Cadastrar());
            
        }
    }
}