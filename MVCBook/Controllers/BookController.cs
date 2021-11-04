using MVCBook.Data;
using MVCBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBook.Controllers
{
    public class BookController : Controller
    {      
        //Crear instancia del dbcontext

        private BookDbContext context = new BookDbContext();

        // GET:Book  o /Book/Index
        public ActionResult Index()
        {
            //Traer todos los Books usando EF
            var books = context.Books.ToList();

            //el controller retorna una vista "Index" con la lista de books
            return View("Index", books);
        }

        //Creamos dos métodos para la inserción del book en la DB

        //primer create por GET para retornar la vista de registro
        [HttpGet]//El Get es implicito asi y todo lo podemos indicar
        public ActionResult Create()
        {
            //creamos la instancia con valores en las propiedades
            Book book = new Book();

            //retornamos la vista "Create" que tiene el objeto book
            return View("Create", book);
        }

        //Segundo Create es por Post para insertar el nuevo libro en la base
        //cuando el usuario en la vista Create hace click en enviar
        //Book/Create -->POST
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", book);
        }




    }
}
