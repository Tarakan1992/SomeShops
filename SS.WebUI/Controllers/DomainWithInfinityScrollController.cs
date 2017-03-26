using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SS.Entities;
using SS.Interfaces.Data;
using SS.WebUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SS.WebUI.Controllers
{
    public abstract class DomainWithInfinityScrollController<TEntity, TIRepository> : DomainController<TEntity, TIRepository>
        where TIRepository : class, IRepository<TEntity>
        where TEntity : class, IEntity
    {
        #region [Fields]
        /// <summary>
        /// Default number of items in one upload block.
        /// </summary>
        protected int BlockSize { get; set; } = 50;

        /// <summary>
        /// Default partial view for items list.
        /// </summary>
        protected string ItemsListViewName { get; set; } = "_ItemsListPartial";
            
        /// <summary>
        /// Item details's view name.
        /// Should be implemented for each controller
        /// </summary>
        protected abstract string ItemViewName { get; }


        /// <summary>
        /// Service provider.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="serviceProvider"></param>
        protected IServiceProvider _serviceProvider;

        #endregion

        #region [Constructors]

        public DomainWithInfinityScrollController(TIRepository repository, IServiceProvider serviceProvider) : base(repository)
        {
            _serviceProvider = serviceProvider;
        }

        #endregion

        #region [Actions]

        public IActionResult ItemsList(ListModel model)
        {
            return PartialView(ItemsListViewName, model);
        }

        public override IActionResult Index()
        {
            var model = new ListModel
            {
                Items = GetBlockItems(),
                ItemViewName = ItemViewName
            };

            return View(model);
        }

        [HttpPost]
        public virtual IActionResult InfinateScroll(int blockNumber)
        {
            var model = new ListModel
            {
                Items = GetBlockItems(blockNumber),
                ItemViewName = ItemViewName
            };

            var jsonModel = new JsonModel()
            {
                NoMoreData = _repository.All.Count() < blockNumber * BlockSize,
                HTMLString = RenderPartialViewToString(ItemsListViewName, model)
            };

            return Json(jsonModel);
        }

        #endregion

        #region [NonAction Methods]

        [NonAction]
        protected virtual IEnumerable<TEntity> GetBlockItems(int blockNumber, IQueryable<TEntity> items)
        {
            return items.Skip((blockNumber - 1) * BlockSize).Take(BlockSize).ToList();
        }

        [NonAction]
        protected IEnumerable<TEntity> GetBlockItems(int blockNumber = 1)
        {
            return GetBlockItems(blockNumber, _repository.All);
        }

        [NonAction]
        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.DisplayName;

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                var engine = _serviceProvider.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine; // Resolver.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult viewResult = engine.FindView(ControllerContext, viewName, false);

                ViewContext viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    ViewData,
                    TempData,
                    sw,
                    new HtmlHelperOptions() //Added this parameter in
                );

                //Everything is async now!
                var t = viewResult.View.RenderAsync(viewContext);
                t.Wait();

                return sw.GetStringBuilder().ToString();
            }

        }

        #endregion
    }
}