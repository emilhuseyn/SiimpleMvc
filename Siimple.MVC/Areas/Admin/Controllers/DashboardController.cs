using Microsoft.AspNetCore.Mvc;
using Siimple.BUSINESS.Helpers.FileManager;
using Siimple.BUSINESS.Services.Interfaces;
using Siimple.BUSINESS.ViewModels.Blog;
using Siimple.CORE.Models;

namespace Siimple.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IWebHostEnvironment _webHost;

      

        public DashboardController(IBlogService blogService, IWebHostEnvironment webHost)
        {
            _blogService = blogService;
            _webHost = webHost;
        }

        public async Task<IActionResult> Index()
        {
            IQueryable<Blog> no =await _blogService.GetAllAsync();
            return View(no.ToList());
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public  IActionResult Create(CreateBlog createBlog)
        {

            string path = createBlog.Image.Upload(_webHost.WebRootPath,"/BlogImages/");
             _blogService.CreateAsync(createBlog,path);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            Blog blog = await _blogService.FindByIdAsync(id);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateBlog updateBlog,Blog blog)
        {
            string path = updateBlog.Image.Upload(_webHost.WebRootPath, "/BlogImages/");
            _blogService.UpdateAsync(updateBlog, path,blog);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _blogService.DeleteByIdAsync(id);
            return RedirectToAction("Index");
        }
    }
}
