using System;
using MySql.Data.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
using System.ComponentModel.DataAnnotations;

namespace GeneralSite.Models
{
	using Microsoft.EntityFrameworkCore;

	/// <summary>
	/// The entity framework context with a Employees DbSet
	/// </summary>
	public class GeneralContext : DbContext
	{
		public GeneralContext(DbContextOptions<GeneralContext> options)
		: base(options)
		{ }

		public DbSet<Category> Categories { get; set; }
	}

	/// <summary>
	/// Factory class for EmployeesContext
	/// </summary>
	public static class GeneralContextFactory
	{
		public static GeneralContext Create(string connectionString)
		{
			var optionsBuilder = new DbContextOptionsBuilder<GeneralContext>();
			optionsBuilder.UseMySql(connectionString);

			//Ensure database creation
			var context = new GeneralContext(optionsBuilder.Options);
			context.Database.EnsureCreated();

			return context;
		}
	}

	/// <summary>
	/// A basic class for an Employee
	/// </summary>
	public class Category
	{
		public Category()
		{
		}

		public int Id { get; set; }

		[MaxLength(255)]
		public string Name { get; set; }

		[MaxLength(255)]
		public string Description { get; set; }
	}
}