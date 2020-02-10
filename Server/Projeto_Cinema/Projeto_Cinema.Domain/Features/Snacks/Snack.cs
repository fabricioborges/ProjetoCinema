using Projeto_Cinema.Domain.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Snacks
{
    public class Snack : Identity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        
    }
}
