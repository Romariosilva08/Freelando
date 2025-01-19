using Freelando.Api.Converters;
using Freelando.Api.Requests;
using Freelando.Dados;
using Freelando.Dados.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Freelando.Api.Endpoints;

public static class ServicoExtensions
{
    public static void AddEndPointServicos(this WebApplication app)
    {
        app.MapGet("/servicos", async ([FromServices] ServicoConverter converter, [FromServices] IUnitOfWork unitOfWork) =>
        {
            var servico = converter.EntityListToResponseList(await unitOfWork.ServicoRepository.BuscarTodos());

            return Results.Ok(await Task.FromResult(servico));
        }).WithTags("Servicos").WithOpenApi();

        app.MapPost("/servico", async ([FromServices] ServicoConverter converter, [FromServices] IUnitOfWork unitOfWork, ServicoRequest servicoRequest) =>
        {
            var servico = converter.RequestToEntity(servicoRequest);

            await unitOfWork.ServicoRepository.Adicionar(servico);
            await unitOfWork.Commit();

            return Results.Created($"/servico/{servico.Id}", servico);
        }).WithTags("Servicos").WithOpenApi();

        app.MapPut("/servico/{id}", async ([FromServices] ServicoConverter converter, [FromServices] IUnitOfWork unitOfWork, Guid id, ServicoRequest servicoRequest) =>
        {
            var servico = await unitOfWork.ServicoRepository.BuscarPorId(x => x.Id==id);
            if (servico is null)
            {
                return Results.NotFound();
            }
            var servicoAtualizado = converter.RequestToEntity(servicoRequest);
            servico.Titulo = servicoAtualizado.Titulo;
            servico.Descricao = servicoAtualizado.Descricao;
            servico.Status = servicoAtualizado.Status;

            await unitOfWork.ServicoRepository.Atualizar(servico);
            await unitOfWork.Commit();

            return Results.Ok((servico));
        }).WithTags("Servicos").WithOpenApi();

        app.MapDelete("/servico/{id}", async ([FromServices] ServicoConverter converter, [FromServices] IUnitOfWork unitOfWork, Guid id) =>
        {
            var servico = await unitOfWork.ServicoRepository.BuscarPorId(x => x.Id==id);
            if (servico is null)
            {
                return Results.NotFound();
            }

            await unitOfWork.ServicoRepository.Deletar(servico);
            await unitOfWork.Commit();

            return Results.NoContent();
        }).WithTags("Servicos").WithOpenApi();
    }
}
