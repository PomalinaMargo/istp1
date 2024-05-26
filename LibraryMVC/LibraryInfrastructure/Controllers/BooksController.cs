using LibraryDomain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LibraryInfrastructure.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id, string? name)
        {
            // Якщо id не передано, відображаємо усі книги
            if (id == null)
            {
                // Отримати всі книги з бази даних
                var allBooks = await _context.Books
                    .Include(b => b.Administrator)
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .ToListAsync();

                return View(allBooks);

            }
          
            ViewBag.Id = id;
            ViewBag.Title = name;

            var booksByAdministrator = await _context.Books
                .Where(b => b.Administratorid == id)
                .Include(b => b.Administrator)
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .ToListAsync();

            return View(booksByAdministrator);
        }


        /*    public async Task<IActionResult> Index(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var dbBooksContext = _context.Books.Include(f => f.Title).Include(f => f.Genre);

                return View(await dbBooksContext.ToListAsync()); 

            */

        //   var booksByAdministrator = await _context.Books
        //     .Where(b => b.Administratorid == id)
        //   .Include(b => b.Administrator)
        // .Include(b => b.Author)
        //  .Include(b => b.Genre)
        //   .ToListAsync();

        //       return View(booksByAdministrator);
        //   } 


        /*  public async Task<IActionResult> Index(int? id, string? name)
           {
               if (id == null)
               {
                   return RedirectToAction("Index", "Administrators");
               }

               // Знаходження книг за категорією
               ViewBag.Id = id;
               ViewBag.Title = name;

               var booksByAdministrator = await _context.Books
                   .Where(b => b.Administratorid == id)
                   .Include(b => b.Administrator)
                   .Include(b => b.Author)
                   .Include(b => b.Genre)
                   .ToListAsync();

               return View(booksByAdministrator);
           }
        */
        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Administrator)
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
       


        // GET: Books/Create
         public IActionResult Create(int administratorId)
         {

             ViewData["Administratorid"] = new SelectList(_context.Administrators, "Id", "Name");
             ViewData["Authorid"] = new SelectList(_context.Authors, "Id", "Name");
             ViewData["Genreid"] = new SelectList(_context.Genres, "Id", "GenreName");
             return View();
         }

         // POST: Books/Create
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create([Bind("Title,Genreid,Authorid,NumberOfPages,Description,Administratorid,Id")] Book book)
         {
             if (true)
             {
                 _context.Add(book);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             ViewData["Administratorid"] = new SelectList(_context.Administrators, "Id", "Name", book.Administratorid);
             ViewData["Authorid"] = new SelectList(_context.Authors, "Id", "Name", book.Authorid);
             ViewData["Genreid"] = new SelectList(_context.Genres, "Id", "GenreName", book.Genreid);
             return View(book);
         }

        // GET: Books/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["Administratorid"] = new SelectList(_context.Administrators, "Id", "Name", book.Administratorid);
            ViewData["Authorid"] = new SelectList(_context.Authors, "Id", "Name", book.Authorid);
            ViewData["Genreid"] = new SelectList(_context.Genres, "Id", "GenreName", book.Genreid);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Genreid,Authorid,NumberOfPages,Description,Administratorid,Id")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (true)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Administratorid"] = new SelectList(_context.Administrators, "Id", "Name", book.Administratorid);
            ViewData["Authorid"] = new SelectList(_context.Authors, "Id", "Name", book.Authorid);
            ViewData["Genreid"] = new SelectList(_context.Genres, "Id", "GenreName", book.Genreid);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Administrator)
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
