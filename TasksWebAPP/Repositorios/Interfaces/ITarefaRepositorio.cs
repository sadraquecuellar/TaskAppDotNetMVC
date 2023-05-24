using TasksWebAPP.Models;

namespace TasksWebAPP.Repositorios.Interfaces
{
    public interface ITarefaRepositorio
    {
        List<TarefaModel> GetAll();
        TarefaModel GetOne(int id);
        TarefaModel Create(TarefaModel tarefa);
        TarefaModel Update(TarefaModel tarefa, int id);
        bool Delete(int id);

    }
}
