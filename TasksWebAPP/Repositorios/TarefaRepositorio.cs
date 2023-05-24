using Newtonsoft.Json;
using System.Text;
using TasksWebAPP.Models;
using TasksWebAPP.Repositorios.Interfaces;

namespace TasksWebAPP.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {

        private readonly string urlApi = "https://localhost:7107/api/";
        static HttpClient client = new HttpClient();

        public List<TarefaModel> GetAll()
        {
            var tarefas = new List<TarefaModel>();
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(urlApi + "Tarefa");
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var retorno = response.Result.Content.ReadAsStringAsync();
                        tarefas = JsonConvert.DeserializeObject<TarefaModel[]>(retorno.Result).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return tarefas;
        }
        public TarefaModel GetOne(int id)
        {
            var tarefaBuscada = new TarefaModel();
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(urlApi + "Tarefa/"+id);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var retorno = response.Result.Content.ReadAsStringAsync();
                        tarefaBuscada = JsonConvert.DeserializeObject<TarefaModel>(retorno.Result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return tarefaBuscada;
        }
        public TarefaModel Create(TarefaModel tarefa)
        {
            var tarefaCriada = new TarefaModel();

            try
            {
                using (var client = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(tarefa);
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response =  client.PostAsync(urlApi+"Tarefa", content);
                    response.Wait();
                    if(response.Result.IsSuccessStatusCode)
                    {
                        var retorno = response.Result.Content.ReadAsStringAsync();
                        tarefaCriada = JsonConvert.DeserializeObject<TarefaModel>(retorno.Result);
                    }
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return tarefaCriada;
        }
        public TarefaModel Update(TarefaModel tarefa, int id)
        {
            var tarefaAtualizada = new TarefaModel();

            try
            {
                using (var client = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(tarefa);
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var response = client.PutAsync(urlApi + "Tarefa/"+id, content);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var retorno = response.Result.Content.ReadAsStringAsync();
                        tarefaAtualizada = JsonConvert.DeserializeObject<TarefaModel>(retorno.Result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return tarefaAtualizada;
        }
        public bool Delete(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.DeleteAsync(urlApi + "Tarefa/" + id);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var retorno = response.Result.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return true;
        }

        
    }
}
