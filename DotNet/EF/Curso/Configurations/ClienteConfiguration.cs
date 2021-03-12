using DominadoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominadoEFCore.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.OwnsOne(p => p.Endereco, end =>
                {
                    end.Property(prop => prop.Bairro).HasColumnName("Bairro");

                    end.ToTable("ClienteEndereco");
                });

            builder
                .HasOne(p => p.Profissao)
                .WithOne(p => p.Cliente)
                .HasForeignKey<Profissao>(p => p.ClienteFK)
                .HasConstraintName("FK__Cliente__Profissao");
        }
    }
}
