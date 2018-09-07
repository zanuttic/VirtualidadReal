using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualidadReal_WebAPP.Services
{
    public class PaisesEnMomorias : IPaisesEnMomorias
    {
        public List<string> ObtenerPais()
        {
            return new List<string> { "Argentina", "Venezuela", "Peru" };
        }

        
    }
}
