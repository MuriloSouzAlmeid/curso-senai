using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maquina_de_cafe
{
    public class MaquinaCafe
    {
        // Atributos
        public float CafeDisponivel {get ; private set;} = 1000;

        // Métodos
        public void FazerCafe(string tipoCafe){
            if(tipoCafe == "1"){
                Console.WriteLine($"\nPreparando Café Sem Açúcar...");
                Thread.Sleep(2000);
            }else{
                this.CafeDisponivel = this.CafeDisponivel - 10f;
                Console.WriteLine($"\nPreparando Café Com Açúcar (10g)...");
                Thread.Sleep(2000);
            }
        }
        public void FazerCafe(float qtdAcucar){
            this.CafeDisponivel = this.CafeDisponivel - qtdAcucar;
            Console.WriteLine($"\nPreparando Café Com Açúcar ({qtdAcucar}g)...");
            Thread.Sleep(2000);
        }
    }
}