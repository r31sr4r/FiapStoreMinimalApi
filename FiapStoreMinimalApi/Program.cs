using FiapStoreMinimalApi.Entidade;
using FiapStoreMinimalApi.Interface;
using FiapStoreMinimalApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/usuario", (IUsuarioRepository repository) => repository.ObterTodosUsuarios());

app.MapGet("/usuario/{id}", (IUsuarioRepository repository, int id) => repository.ObterUsuarioPorId(id));

app.MapPost("/usuario", (IUsuarioRepository repository, Usuario usuario) =>
{
    repository.CadastrarUsuario(usuario);
    return Results.Created($"/usuario/{usuario.Id}", usuario);
});

app.MapPut("/usuario/{id}", (IUsuarioRepository repository, int id, Usuario usuario) =>
{
    if (id != usuario.Id)
    {
        return Results.BadRequest();
    }

    repository.AtualizarUsuario(usuario);
    return Results.Ok();
});

app.MapDelete("/usuario/{id}", (IUsuarioRepository repository, int id) =>
{
    repository.RemoverUsuario(id);
    return Results.Ok();
});

app.Run();

