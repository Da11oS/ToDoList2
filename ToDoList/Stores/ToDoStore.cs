using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Stores
{
    public class ToDoStore : IToDoStore
    {
        private MyContext _ctx;

        public ToDoStore(MyContext ctx)
        {
            _ctx = ctx;
        }

        public int Create(Models.ToDoList value)
        {
             var result = _ctx.ToDoLists.Add(value).Entity.Id;
             _ctx.SaveChanges();
             return result;
        }

        public void Update(int id, Models.ToDoList value)
        {
            _ctx.ToDoLists.Update(value);
            _ctx.SaveChanges();
        }

        public Models.ToDoList Get(int id)
        {
            var result = _ctx.ToDoLists.FirstOrDefault(x => x.Id == id);
            _ctx.SaveChanges();
            return result;
        }

        public Models.ToDoList[] GetAll()
        {
            var result = _ctx.ToDoLists.ToArray();
            _ctx.SaveChanges();
            return result;
        }

        public void Delete(Models.ToDoList value)
        {
             _ctx.ToDoLists.Remove(value);
            _ctx.SaveChanges();
        }
    }
}
