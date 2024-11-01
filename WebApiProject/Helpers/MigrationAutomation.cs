﻿using Microsoft.EntityFrameworkCore;
using TestWebApplication.Data;
using WebApiProject.Data;

namespace TestWebApplication.Helpers
{
    public static class MigrationAutomation
    {
        public static async Task ApplyMigration(WebApplication app) // apply new pending migration
        {
            using (var scope = app.Services.CreateScope()) // Get the services 
            {

                var _db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (_db.Database.GetPendingMigrations().Count() > 0) // apply all the pending migration
                {
                    _db.Database.Migrate();
                }
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await SeedingDb.InitUser(context);
            }
        }
    }
}
