using Fornec.Models;

namespace Fornec.Data
{
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppCont>();
                context.Database.EnsureCreated();

                //Criando Fornecedor
                if (!context.Fornecedor.Any())
                {
                    context.Fornecedor.AddRange(new List<Fornecedor>()
                    {
                        new Fornecedor()
                        {
                             RazaoSocial = "Ouro Fino S.A.",
                             NomeFantasia = "Ouro Fino Saúde Animal",
                             CNPJ = "12.345.678/0001-95",
                             Nome = "Thiago Feitosa",
                             Telefone = "(11) 99299-8955",
                             Email = "diretoria@ourofino.com.br",
                             Logradouro = "Rodovia Anhaguera",
                             Numero = "1000",
                             Complemento = "Km 330",
                             Bairro = "Distrito Industrial",
                             Cidade = "Cravinhos",
                             Estado = "SP",
                             CEP = "14000-000"

                        },
                        new Fornecedor()
                        {
                               RazaoSocial = "Base Quimica Ltda.",
                               NomeFantasia = "Base Quimica",
                               CNPJ = "98.765.432/0001-23",
                               Nome = "Solange Almeida Neves",
                               Telefone = "(19) 99712-4522",
                               Email = "financeiro1@basequimica.com.br",
                               Logradouro = "Rua ALiados",
                               Numero = "2230",
                               Complemento = "Unidade 1",
                               Bairro = "Vila Carvalho",
                               Cidade = "Ribeirão Preto",
                               Estado = "RJ",
                               CEP = "14080-200",
                        },
                    });

                    context.SaveChanges();

                }
            }

        }
    }
}




    

