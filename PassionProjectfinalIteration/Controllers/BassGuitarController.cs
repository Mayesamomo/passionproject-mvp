using PassionProjectfinalIteration.Models;
using PassionProjectfinalIteration.ViewModels;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PassionProjectfinalIteration.Controllers
{
    public class BassGuitarController : Controller
    {
        readonly
        private ApplicationDbContext _context;

        public BassGuitarController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: https://localhost:44332/BassGuitar
        public ActionResult Index()
        {
            var bassGuitars = _context.BassGuitars.Include("Category").ToList();
            return View(bassGuitars);
        }

        // GET: https://localhost:44332/BassGuitar/Create
        public ActionResult Create()
        {
            var viewModel = new BassGuitarViewModel
            {
                AvailableCategories = _context.Categories.ToList()
            };

            return View(viewModel);
        }

        // POST: BassGuitar/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BassGuitarViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.AvailableCategories = _context.Categories.ToList();
                return View(viewModel);
            }

            var bassGuitar = new BassGuitar
            {
                Color = viewModel.Color,
                NumberOfStrings = viewModel.NumberOfStrings,
                Model = viewModel.Model,
                Manufacturer = viewModel.Manufacturer,
                CategoryID = viewModel.CategoryID
            };

            _context.BassGuitars.Add(bassGuitar);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: BassGuitar/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bassGuitar = _context.BassGuitars.SingleOrDefault(c => c.ID == id);

            if (bassGuitar == null)
            {
                return HttpNotFound();
            }

            var viewModel = new BassGuitarViewModel
            {
                Color = bassGuitar.Color,
                NumberOfStrings = bassGuitar.NumberOfStrings,
                Model = bassGuitar.Model,
                Manufacturer = bassGuitar.Manufacturer,
                CategoryID = bassGuitar.CategoryID,
                AvailableCategories = _context.Categories.ToList()
            };

            return View(viewModel);
        }


        // POST: BassGuitar/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BassGuitarViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.AvailableCategories = _context.Categories.ToList();
                return View(viewModel);
            }

            var bassGuitar = _context.BassGuitars.SingleOrDefault(c => c.ID == viewModel.CategoryID); // Use viewModel.ID instead of viewModel.CategoryID

            if (bassGuitar == null)
            {
                return HttpNotFound();
            }

            bassGuitar.Color = viewModel.Color;
            bassGuitar.NumberOfStrings = viewModel.NumberOfStrings;
            bassGuitar.Model = viewModel.Model;
            bassGuitar.Manufacturer = viewModel.Manufacturer;
            bassGuitar.CategoryID = viewModel.CategoryID;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: BassGuitar/Delete/5
        public ActionResult Delete(int id)
        {
            var bassGuitar = _context.BassGuitars.SingleOrDefault(c => c.ID == id);

            if (bassGuitar == null)
                return HttpNotFound();

            _context.BassGuitars.Remove(bassGuitar);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}