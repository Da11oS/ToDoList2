using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Stores
{
    public interface IToDoStore
    {
        public int Create(Models.ToDoList value);
        public void Update(int id, Models.ToDoList value);
        public Models.ToDoList Get(int id);
        public Models.ToDoList[] GetAll();
        public void Delete(Models.ToDoList value);
    }
}