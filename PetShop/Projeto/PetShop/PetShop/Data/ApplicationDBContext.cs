﻿using Microsoft.EntityFrameworkCore;
using PetShop.Models;

namespace PetShop.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<AnimalModel> Animais { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<PetShopModel> PetShops { get; set; }
        public DbSet<ServicoModel> Servicos { get; set; }
    }
}
