using MyWebApiProject.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(); 
builder.Services.AddSingleton<IBooksService, BooksService>(); //З AddScoped не виконувалися запити, Singleton дозволила зберегти дані між запитами, оскільки це гарантує, що весь список жанрів (як глобальний стан) залишатиметься доступним і змінюваним протягом усього життєвого циклу програми.
builder.Services.AddSingleton<IGenresService, GenresService>(); //З AddScoped не виконувалися запити, Singleton дозволила зберегти дані між запитами, оскільки це гарантує, що весь список жанрів (як глобальний стан) залишатиметься доступним і змінюваним протягом усього життєвого циклу програми.
builder.Services.AddSingleton<IAuthorsService, AuthorsService>(); //З AddScoped не виконувалися запити, Singleton дозволила зберегти дані між запитами, оскільки це гарантує, що весь список жанрів (як глобальний стан) залишатиметься доступним і змінюваним протягом усього життєвого циклу програми.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Web API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
