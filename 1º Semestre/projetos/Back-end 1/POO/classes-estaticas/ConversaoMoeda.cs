using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace classes_estaticas
{
    public static class ConversaoMoeda
    {
        public static float DolarParaReal(float quantia){
            return (float)(quantia * 4.99);
        }

        public static float RealParaDolar(float quantia){
            return (float)(quantia / 4.99);
        }
    }
}