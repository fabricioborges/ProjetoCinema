using Projeto_Cinema.Application.Features.Snacks.Commands;
using Projeto_Cinema.Domain.Features.Snacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Common.Tests.Features
{
    public static partial class ObjectMother
    {
        public static Snack snackDefault
        {
            get
            {
                return new Snack
                {
                    Image = "urlImage",
                    Name = "snack",
                    Price = 10.5
                };
            }
        }

        public static List<Snack> snackListDefault
        {
            get
            {
                return new List<Snack>
                {
                    snackDefault,
                    snackDefault,
                    snackDefault
                };
            }
        }

        public static SnackAddCommand snackAddCommand
        {
            get
            {
                return new SnackAddCommand
                {
                    Image = "urlImage",
                    Name = "snack",
                    Price = 10.5
                };
            }
        }

        public static SnackUpdateCommand snackUpdateCommand
        {
            get
            {
                return new SnackUpdateCommand
                {
                    Id = 1,
                    Image = "urlImage",
                    Name = "snack",
                    Price = 10.5
                };
            }
        }

        public static SnackDeleteCommand snackDeleteCommand
        {
            get
            {
                return new SnackDeleteCommand
                {
                    Id = 1
                };
            }
        }
    }
}
