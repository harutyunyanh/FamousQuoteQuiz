Initialization of the Database Tables:
	1. Use this command to auto-genarate the models:

	Scaffold-DbContext "Server=localhost;Database=FamousQuoteQuizDB;User Id=sa;Password=sa;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir FamousQuoteQuizDB/Models -Context "DataBaseContext" -f

		!NOTES:
			Make Sure to Unload all project that have referance on DataBaseAccessLibrary
			Make sure the Startup/Default project is the "DataBaseAccessLibrary"

	2. Update Database connection string:
		Change (with warning line):
				#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
				optionsBuilder.UseSqlServer("Server=csuser;Database=MegaFlexServerDb;user id=csuser;Password=VE214yiyWm4D9RSwb0Ye");
		To:
				optionsBuilder.UseSqlServer(DataBaseConfigurator.ConnectionString);
	
Initialization of the Stored Procedure:
	1. Add stored procedure's return type model file in "StoredProcedures" folder
		!NOTES:
			Make sure to change namespace, see SP_ExampleModel
			Make sure you save the Stored procedure core as well (to make it easy to track changes)
	2. Add property in DataBaseContext class file in "StoredProcedures" folder
		public virtual DbSet<SP_ExampleModel> SP_ExampleModelProperty { get; set; }
	3. Use it:
		using (DataBaseContext db = new DataBaseContext())
        {
            SP_ExampleModel em = db.SP_ExampleModelProperty.FromSql($"EXEC SP_ExampleModel_Get @ClientId={id}").FirstOrDefault();
            return em;
        }

To Integrate:
	1. Add "DataAccessLibrary" referance to project
	2. Add connection string to "appsettings.json" file:
		"ConnectionStrings": {
			"DefaultConnection": "Server=csuser;Database=MegaFlexServerDb;user id=csuser;Password=VE214yiyWm4D9RSwb0Ye;"
		},
	3. In "StartUp.cs" file at the end of "Configure" method add following:
		DataBaseConfigurator.ConnectionString = ConfigurationExtensions.GetConnectionString(Configuration, "DefaultConnection");
	4. Use it:
		using (DataBaseContext db = new DataBaseContext())
        {
            List<AccountTypes> at = db.AccountTypes.ToList();
        }