using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoodtoGo.Models;

namespace GoodtoGo.Controllers
{
	public class SalesItem {
		public int ProductID { get; set; }
		public int Quantity{ get; set; }
	public int Price { get; set; }
	};

	public class sale
	{
		public DateTime date { get; set; }
		public int total { get; set; }
		public List<SalesItem> salesItem { get; set; }
	};
    public class SalesController : Controller
    {
        private Entities db = new Entities();

        // GET: Sales
        public ActionResult Index()
        {
            return View(db.Sales.ToList());
        }
		public ActionResult ADD(sale std)
		{
			int flag = 0;
			var dbContext = db.Database.BeginTransaction();
			try
			{
				Sale newSale = new Sale();
				newSale.Date = std.date;
				newSale.Total = std.total;
				db.Sales.Add(newSale);
				db.SaveChanges();
				var lastestId = db.Sales.Max(x => x.Id);
				foreach (var item in std.salesItem)
				{
					ProductSale anItem = new ProductSale();
					anItem.Price = item.Price;
					anItem.ProductId = item.ProductID;
					anItem.Quantity = item.Quantity;
					anItem.saleId = lastestId;
					db.ProductSales.Add(anItem);
					db.SaveChanges();
				}
				dbContext.Commit();
				flag = 1;
			}
			catch
			{
				dbContext.Rollback();
				ViewBag.Error = "Cannot Insert Data";
			}
			
			return Content(flag.ToString(),"plain/Text");
		}
        // GET: Sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
			ViewBag.ProductList = new SelectList(db.Products.Where(x => x.Quantity > 0), "ProductId", "Name");
			ViewBag.Date = DateTime.Now;
			return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Total")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Add(sale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sale);
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Total")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sale);
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sale sale = db.Sales.Find(id);
            db.Sales.Remove(sale);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
