using GameCRUD.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace GameCRUD.Context
{
    public class GameContext : DbContext
    {
        // Your context has been configured to use a 'GameContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'GameCRUD.Context.GameContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'GameContext' 
        // connection string in the application configuration file.
        public GameContext()
            : base("name=GameContext")
        {
        }

        public DbSet<GameEntity> Games { get; set; }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}