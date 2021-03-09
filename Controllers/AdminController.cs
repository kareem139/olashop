using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using olashop.Data;
using olashop.Models;
using olashop.Viewmodels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace olashop.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHostingEnvironment _hosting;

        public AdminController(ApplicationDbContext dbContext,IHostingEnvironment hosting)
        {
            _dbContext = dbContext;
            _hosting = hosting;
        }
        // GET: AdminController


        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult CategoryIndex()
        {
            var cats = _dbContext.Categories.ToList();
            return View(cats);
        }

        // GET: AdminController/Details/5
        [HttpGet]
        public ActionResult CategoryDetails(int id)
        {
            var res = _dbContext.Categories.FirstOrDefault(e => e.Id == id);
            return View(res);
        }

        // GET: AdminController/Create
        [HttpGet]
        public ActionResult CategoryCreate()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CategoryCreate(CategoryVM vM)
        {
            try
            {
                
                var cat = new Category
                    {
                        Name = vM.Name,
                        IsActive = vM.IsActive,
                        Products = vM.Products
                    };
                    _dbContext.Categories.Add(cat);
                _dbContext.SaveChanges();
                
                return RedirectToAction(nameof(CategoryIndex));
            }
            catch
            {
                return View(vM);
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult CategoryEdit(int id)
        {
            var a = _dbContext.Categories.FirstOrDefault(e => e.Id == id);
            return View(a);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CategoryEdit(int id, CategoryVM vM)
        {
            try
            {
                var a = _dbContext.Categories.FirstOrDefault(e => e.Id == id);

                a.IsActive = vM.IsActive;
                a.Name = vM.Name;
                a.Products = vM.Products;
                _dbContext.Categories.Update(a);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(CategoryIndex));
            }
            catch
            {
                return View(vM);
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult CategoryDelete(int id)
        {
            var cat = _dbContext.Categories.FirstOrDefault(e => e.Id == id);
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CategoryDelete(int id, CategoryVM vM)
        {
            try
            {
                var cat = _dbContext.Categories.FirstOrDefault(e => e.Id == id);
                _dbContext.Categories.Remove(cat);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(CategoryIndex));
            }
            catch
            {
                return View(vM);
            }
        }



        //produuuuusssssssssssccccccccccccccccctttttttttttttttttt


        public ActionResult ProductIndex()
        {
            var pros = _dbContext.Products.ToList();
            return View(pros);
        }

        // GET: AdminController/Details/5
        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            var res = _dbContext.Products.FirstOrDefault(e => e.Id == id);
            return View(res);
        }

        // GET: AdminController/Create
        [HttpGet]
        public ActionResult ProductCreate()
        {
            var a = new ProductVM
            {
                Category = _dbContext.Categories.ToList(),
                Brands=_dbContext.Brands.ToList()
                
            };
            return View(a);
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductCreate(ProductVM vM)
        {
            try
            {
                string filename = string.Empty;
                if (vM.File!=null)
                {

                    string uploads = Path.Combine(_hosting.WebRootPath, "uploads");

                    filename = vM.File.FileName;
                    string fullpath = Path.Combine(uploads, filename);
                    vM.File.CopyTo(new FileStream(fullpath, FileMode.Create));
                }

                var pro = new Product
                {
                    Name = vM.Name,
                    IsActive = vM.IsActive,
                    ImgUrl = vM.File.FileName,
                    Price=vM.Price,
                    Quantity=vM.Quantity,
                    Description=vM.Description,
                    CategoryId=vM.CategoryId,
                    Adddate=vM.Adddate,
                    BrandName=vM.BrandName

                };
                _dbContext.Products.Add(pro);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(ProductIndex));
            }
            catch
            {
                return View(vM);
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult ProductEdit(int id)
        {
            var a = _dbContext.Products.FirstOrDefault(e => e.Id == id);

            var vm = new ProductVM
            {
                Id=a.Id,
                Name = a.Name,
                IsActive = a.IsActive,
                imgurl = a.ImgUrl,
                Description = a.Description,
                CategoryId = a.CategoryId,
                Price = a.Price,
                Quantity = a.Quantity,
                Adddate = a.Adddate,
                BrandName=a.BrandName,
                Brands=_dbContext.Brands.ToList(),
                Category = _dbContext.Categories.ToList()
                
            };
            return View(vm);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductEdit(int id, ProductVM vM)
        {
            try
            {
                string filename = string.Empty;
                if (vM.File != null)
                {

                    string uploads = Path.Combine(_hosting.WebRootPath, "uploads");

                    filename = vM.File.FileName;
                    string fullpath = Path.Combine(uploads, filename);
                    string oldfilename = _dbContext.Products.Find(id).ImgUrl;
                    string oldpath = Path.Combine(uploads, oldfilename);

                    if (oldpath!=fullpath)
                    {
                        System.IO.File.Delete(oldpath);
                        vM.File.CopyTo(new FileStream(fullpath, FileMode.Create));

                    }
                  
                }
                var a = _dbContext.Products.FirstOrDefault(e => e.Id == id);

                a.IsActive = vM.IsActive;
                a.Name = vM.Name;
                a.ImgUrl = vM.File.FileName;
                a.Price = vM.Price;
                a.Quantity = vM.Quantity;
                a.CategoryId = vM.CategoryId;
                a.Description = vM.Description;
                a.Adddate = vM.Adddate;
                a.Id = vM.Id;
                a.BrandName = vM.BrandName;
                _dbContext.Products.Update(a);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(ProductIndex));
            }
            catch
            {
                return View(vM);
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult ProductDelete(int id)
        {
            var pro = _dbContext.Products.FirstOrDefault(e => e.Id == id);
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductDelete(int id, ProductVM vM)
        {
            try
            {
                var pro = _dbContext.Products.FirstOrDefault(e => e.Id == id);
                _dbContext.Products.Remove(pro);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(ProductIndex));
            }
            catch
            {
                return View(vM);
            }
        }


        // brrrrrrrrrrraaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaannnnnnnnnnnnnnnnnnnnnndddddddddddddddd



        public ActionResult BrandIndex()
        {
            var brands = _dbContext.Brands.ToList();
            return View(brands);
        }

        // GET: AdminController/Details/5
        [HttpGet]
        public ActionResult BrandDetails(int id)
        {
            var res = _dbContext.Brands.FirstOrDefault(e => e.Id == id);
            return View(res);
        }

        // GET: AdminController/Create
        [HttpGet]
        public ActionResult BrandCreate()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BrandCreate(BrandVM vM)
        {
            try
            {

                var brand = new Brand
                {
                    Name = vM.Name,
                    
                    Products = vM.Products
                };
                _dbContext.Brands.Add(brand);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(BrandIndex));
            }
            catch
            {
                return View(vM);
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult BrandEdit(int id)
        {
            var a = _dbContext.Brands.FirstOrDefault(e => e.Id == id);
            return View(a);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BrandEdit(int id, BrandVM vM)
        {
            try
            {
                var a = _dbContext.Brands.FirstOrDefault(e => e.Id == id);

                
                a.Name = vM.Name;
                a.Products = vM.Products;
                _dbContext.Brands.Update(a);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(BrandIndex));
            }
            catch
            {
                return View(vM);
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult BrandDelete(int id)
        {
            var cat = _dbContext.Brands.FirstOrDefault(e => e.Id == id);
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BrandDelete(int id, BrandVM vM)
        {
            try
            {
                var brand = _dbContext.Brands.FirstOrDefault(e => e.Id == id);
                _dbContext.Brands.Remove(brand);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(BrandIndex));
            }
            catch
            {
                return View(vM);
            }
        }

    }
}
