using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Web.Helpers;
using TasksWebAPP.Models;
using TasksWebAPP.Repositorios;
using TasksWebAPP.Repositorios.Interfaces;

namespace TasksWebAPP.Controllers
{
  public class TarefaController : Controller
  {
    private readonly ITarefaRepositorio _tarefaRepositorio;

    public TarefaController(ITarefaRepositorio tarefaRepositorio) { 
        _tarefaRepositorio = tarefaRepositorio;
    }

    public IActionResult Index()
    {
      var r = _tarefaRepositorio.GetAll();
      return View(_tarefaRepositorio.GetAll());
    }

    public IActionResult Details(int id)
    {
        return View(_tarefaRepositorio.GetOne(id));
    }

    public IActionResult Criar()
    {
        return View();
    }
    [HttpPost]
    public IActionResult CriarTarefa(TarefaModel tarefa)
    {
        var tarefaCriada = _tarefaRepositorio.Create(tarefa);
        return Json(new { objeto= tarefaCriada, erro = false });
    }

    public IActionResult Editar(int id)
    {
        return View(_tarefaRepositorio.GetOne(id));

    }
    [HttpPut]
    public IActionResult EditarTarefa(TarefaModel tarefa, int id)
    {
        var tarefaAtualizada = _tarefaRepositorio.Update(tarefa, id);
        return Json(new { tarefaAtualizada });
        }

    public IActionResult Delete(int id)
    {
        return View(_tarefaRepositorio.GetOne(id));
    }

    [HttpDelete]
    public IActionResult DeletarTarefa(int id)
    {
        var deletado = _tarefaRepositorio.Delete(id);
        return Json(new { deletado });
    }
    }
}
