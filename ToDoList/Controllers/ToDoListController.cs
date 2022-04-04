using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using ToDoList.Stores;

namespace ToDoList.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private IToDoStore _toDoStore;

        public ToDoListController(IToDoStore toDoStore)
        {
            _toDoStore = toDoStore;
        }

        [HttpPost]
        public int Create(Models.ToDoList value)
        {
            return _toDoStore.Create(value);
        }

        [HttpPut]
        public IActionResult Update(int id, Models.ToDoList value)
        {
            _toDoStore.Update(id, value);
            return Ok();
        }

        [HttpGet]
        [Route("{id:int?}")]
        public IActionResult Get(int id)
        {
            return Ok(_toDoStore.Get(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_toDoStore.GetAll());
        }

        [HttpDelete]
        public IActionResult Delete(Models.ToDoList value)
        {
            _toDoStore.Delete(value);
             return Ok();
        }
    }
}
