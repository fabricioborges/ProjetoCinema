using NUnit.Framework;
using Projeto_Cinema.Application.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Tests.Initializer
{
    [TestFixture]
    public class TestBase
    {
        [OneTimeSetUp]
        public void Initialize()
        {
            AutoMapperConfig.Reset();
            AutoMapperConfig.Initialize();
        }
    }
}
