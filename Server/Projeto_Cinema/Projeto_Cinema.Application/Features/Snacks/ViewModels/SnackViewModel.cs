using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Snacks.ViewModels
{
    public class SnackViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
    }
}
