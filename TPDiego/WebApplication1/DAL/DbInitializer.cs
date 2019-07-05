using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using System.Data.Entity;


namespace WebApplication1.DAL
{
    public class DbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LojaContext>
    {
        protected override void Seed(LojaContext context)
        {
            var clientes = new List<Cliente>
            {
                new Cliente{ID=1, Nome="Diego Medeiros",Email="diego@fhmtec.com.br",TelefoneId=1
                ,Telefones=new List<Telefone>{
                    new Telefone{ID=1, DDD=13,Numero="991794504" }
                } },
                new Cliente{ID=2, Nome="Raphael Soares",Email="raphael@k2partnering.com",TelefoneId=2
                ,Telefones=new List<Telefone>{
                    new Telefone{ID=1, DDD=13,Numero="991794504" }
                } }

            };
            clientes.ForEach(s => context.Clientes.Add(s));
            context.SaveChanges();

            var consultors = new List<Consultor>
            {
                new Consultor{ID=1, Nome="Thiago Holanda",TelefoneId=3 },
                new Consultor{ID=2, Nome="Bernardo Pierry",TelefoneId=4 }
            };
            consultors.ForEach(s => context.Consultors.Add(s));
            context.SaveChanges();


            var telefones = new List<Telefone>
            {
                new Telefone{ID=1, DDD=13,Numero="991794504"
                ,Cliente=new Cliente{ID=1, Nome="Diego Medeiros",Email="diego@fhmtec.com.br",TelefoneId=1
                ,Telefones=new List<Telefone>{
                    new Telefone{ID=1, DDD=13,Numero="991794504" }
                } } },
                new Telefone{ID=2, DDD=14,Numero="951653365"
                ,Cliente=new Cliente{ID=2, Nome="Raphael Soares",Email="raphael@k2partnering.com",TelefoneId=2
                ,Telefones=new List<Telefone>{
                    new Telefone{ID=2, DDD=14,Numero="991794504" }
                } } },
                new Telefone{ID=3, DDD=11,Numero="930042164" },
                new Telefone{ID=4, DDD=21,Numero="991073510" }
            };
            telefones.ForEach(s => context.Telefones.Add(s));
            context.SaveChanges();

        }
    }
}