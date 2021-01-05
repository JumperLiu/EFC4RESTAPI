# 1、新增MySQL数据库依赖注入逻辑：（Startup.cs -> ConfigureServices(IServiceCollection services)）
~~~ C# source code
        var settings = Configuration.GetSection("DB_MySQL").Get<DBConnection>();
            services.AddDbContext<AppDBContext>(
                options => options
                .UseMySql(
                    settings.ConnString,
                    new MySqlServerVersion(new Version(8, 0, 22)),
                    mySqlOptions => mySqlOptions
                        .CharSetBehavior(CharSetBehavior.NeverAppend)
                    )
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
            );
        services.AddScoped<IDBContext, EFCRepository>();
~~~

# 2、新增MySQL数据库上下文对象构造函数：(AppDBContext.cs)
~~~ C# source code
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
~~~

# 3、根据需求新增MySQL数据库基表对应索引：(OnModelCreating(ModelBuilder modelBuilder))
~~~ C# source code
            modelBuilder.Entity<Permission>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Permission>().HasIndex(p => p.Score);
            modelBuilder.Entity<Config>().HasIndex(c => new { c.ParentId, c.Name }).IsUnique().HasDatabaseName("UIX_Configs_Pid_Name");
~~~

# 4、新增MySQL数据库EntityFrameworkCore依赖包：
~~~ dotnet cli
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 5.0.0-alpha.2
~~~

# 5、新增MySQL数据库EFC迁移依赖包：
~~~ dotnet cli
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.1
~~~

# 6、初始化MySQL数据库对象迁移：
~~~ dotnet cli
dotnet ef migrations add InitialCreate
~~~

# 7、应用MySQL数据库迁移脚本：
~~~ dotnet cli
dotnet ef migrations script
~~~