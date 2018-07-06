using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Infra.Metodo_Extensao;
using System;

namespace Pizzaria.Infra.Tests.Metodo_Extensao
{
    [TestFixture]
    public class AjudanteDataTest
    {
        [Test]
        public void Metodo_Extensao_AjudanteDataTest_CompararDataMenorQueAtual_Deve_passar_com_uma_data_maior_que_a_atual()
        {
            //Cenario
            DateTime data = DateTime.Now.AddDays(2);
            //Ação
            bool response = data.CompararDataMenorQueAtual();
            //Saída
            response.Should().BeFalse();
        }

        [Test]
        public void Metodo_Extensao_AjudanteDataTest_CompararDataMenorQueAtual_Deve_falhar_com_uma_data_menor_que_a_atual()
        {
            //Cenario
            DateTime data = DateTime.Now.AddDays(-2);
            //Ação
            bool response = data.CompararDataMenorQueAtual();
            //Saída
            response.Should().BeTrue();
        }
    }
}
